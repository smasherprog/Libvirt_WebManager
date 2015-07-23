using Libvirt_WebManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Service.Nodes
{

    public class NodeBuilder
    {
        private class nodehelper
        {
            public Libvirt.CS_Objects.Host host { get; set; }
            public string currentpath { get; set; }
            public string hostname { get; set; }
        }
        public static List<Libvirt_WebManager.ViewModels.TreeViewModel> Build(List<string> path_parts, Libvirt.CS_Objects.Host host)
        {
            var ret = new List<Libvirt_WebManager.ViewModels.TreeViewModel>();
            var nodeh = new nodehelper { currentpath = "", host = host, hostname = path_parts[0].ToLower() };

            Libvirt_WebManager.ViewModels.TreeViewModel.Node_Types node_type = TreeViewModel.Node_Types.Host;
            if (path_parts.Count >= 2)
            {
                if (!Enum.TryParse(path_parts[1], out node_type)) return ret;
                nodeh.currentpath = "/" + nodeh.hostname + "/" + node_type.ToString() + "/";
            }

            if (path_parts.Count == 3)
            {
                nodeh.currentpath += path_parts[2] + "/";
                if (node_type == TreeViewModel.Node_Types.Domains)
                {

                }
                else if (node_type == TreeViewModel.Node_Types.Interfaces)
                {

                }
                else if (node_type == TreeViewModel.Node_Types.Storage_Pools)
                {
                    return Populate_StorageVolumes(nodeh, path_parts[2]);
                }
            }
            else if (path_parts.Count == 2)
            {
                if (node_type == TreeViewModel.Node_Types.Domains)
                {
                    return Populate_Domains(nodeh);
                }
                else if (node_type == TreeViewModel.Node_Types.Interfaces)
                {

                }
                else if (node_type == TreeViewModel.Node_Types.Storage_Pools)
                {
                    return Populate_StoragePools(nodeh);
                }
            }
            else if (path_parts.Count == 1)
            {
                nodeh.currentpath = "/" + nodeh.hostname + "/";
                ret.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Domains, Name = "Domains", Path = nodeh.currentpath + "Domains/", Host = nodeh.hostname });
                ret.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Interfaces, Name = "Interfaces", Path = nodeh.currentpath + "Interfaces/", Host = nodeh.hostname });
                ret.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Storage_Pools, Name = "Storage_Pools", Path = nodeh.currentpath + "Storage_Pools/", Host = nodeh.hostname });
            }
            else
            {
                ret.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Host, Name = nodeh.hostname, Path = nodeh.currentpath + "/" + nodeh.hostname + "/", Host = nodeh.hostname });
            }
            return ret;
        }
        private static List<Libvirt_WebManager.ViewModels.TreeViewModel> Populate_StorageVolumes(nodehelper nodeh, string poolname)
        {
            var ret = new List<Libvirt_WebManager.ViewModels.TreeViewModel>();
            Libvirt.CS_Objects.Storage_Volume[] p;
            try
            {
                using (var pool = nodeh.host.virStoragePoolLookupByName(poolname))
                {
                    if (pool.virStoragePoolListAllVolumes(out p) > -1)
                    {
                        foreach (var volume in p)
                        {
                            var dname = volume.virStorageVolGetName();
                            ret.Add(new TreeViewModel { IsDirectory = false, Node_Type = TreeViewModel.Node_Types.Storage_Volume, Name = dname, Path = nodeh.currentpath + dname + "/", Host = nodeh.hostname });
                            volume.Dispose();
                        }
                    }

                }


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return ret;
        }
        private static List<Libvirt_WebManager.ViewModels.TreeViewModel> Populate_StoragePools(nodehelper nodeh)
        {
            var ret = new List<Libvirt_WebManager.ViewModels.TreeViewModel>();
            Libvirt.CS_Objects.Storage_Pool[] p;
            try
            {

                if (nodeh.host.virConnectListAllStoragePools(out p, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_AUTOSTART) > -1)
                {
                    foreach (var pool in p)
                    {
                        var dname = pool.virStoragePoolGetName();
                        ret.Add(new TreeViewModel { IsDirectory = true, Node_Type = TreeViewModel.Node_Types.Storage_Pool, Name = dname, Path = nodeh.currentpath + dname + "/", Host = nodeh.hostname });
                        pool.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return ret;
        }
        private static List<Libvirt_WebManager.ViewModels.TreeViewModel> Populate_Domains(nodehelper nodeh)
        {
            var ret = new List<Libvirt_WebManager.ViewModels.TreeViewModel>();
            Libvirt.CS_Objects.Domain[] d;
            if (nodeh.host.virConnectListAllDomains(out d, Libvirt.virConnectListAllDomainsFlags.VIR_DEFAULT) > -1)
            {
                try
                {
                    foreach (var domain in d)
                    {
                        var dname = domain.virDomainGetName();
                        Libvirt.virDomainState state = Libvirt.virDomainState.VIR_DOMAIN_NOSTATE;
                        int reason = 0;
                        domain.virDomainGetState(out state, out reason);
                        ret.Add(new TreeViewModel
                        {
                            Status = (Libvirt_WebManager.ViewModels.TreeViewModel.Node_Status_Types)Enum.Parse(typeof(Libvirt_WebManager.ViewModels.TreeViewModel.Node_Status_Types), state.ToString()),
                            IsDirectory = false,
                            Node_Type = TreeViewModel.Node_Types.Domain,
                            Name = dname,
                            Path = nodeh.currentpath + dname + "/",
                            Host = nodeh.hostname
                        });


                        domain.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

            }
            return ret;
        }
    }
}