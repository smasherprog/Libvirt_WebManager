﻿using Libvirt.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Models.Concrete
{
    public class Storage_Pool_Dir : Interface.IStorage_Pool_Item
    {
        public Storage_Pool_Dir()
        {
            _Pool_Type = Concrete.Storage_Pool.Pool_Types.dir;
        }
        public override string To_XML()
        {
            var ret = "";

            return ret;
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {

        }
        public override void Validate(IValdiator v)
        {

        }
    }
    public class Storage_Pool_Iscsi : Interface.IStorage_Pool_Item
    {
        public string host { get; set; }
        public string device_path { get; set; }
        public Storage_Pool_Iscsi()
        {
            _Pool_Type = Concrete.Storage_Pool.Pool_Types.iscsi;
            target_path = "/dev/disk/by-id";//this should always be the case
        }
        public override string To_XML()
        {
            return "<source><host name='" + host + "'/><device path='" + device_path + "'/></source>";
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {

        }
        public override void Validate(IValdiator v)
        {

        }
    }
    public class Storage_Pool_Netfs : Interface.IStorage_Pool_Item
    {
        public enum Pool_Format_Types { auto, nfs, glusterfs, cifs};
        public string host_name { get; set; }
        public string dir_path { get; set; }
        public Pool_Format_Types Pool_Format_Type { get; set; }
        public Storage_Pool_Netfs()
        {
            _Pool_Type = Concrete.Storage_Pool.Pool_Types.netfs;
            Pool_Format_Type = Pool_Format_Types.auto;
        }
        public override string To_XML()
        {
            return "<source><host name='" + host_name + "'/><dir path='" + dir_path + "'/><format type='" + Pool_Format_Type.ToString() + "'/></source>";
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {

        }
        public override void Validate(IValdiator v)
        {

        }
    }
    public class Storage_Pool_Disk : Interface.IStorage_Pool_Item
    {
        public enum Pool_Format_Types { dos, dvh, gpt, mac, bsd, pc98, sun, lvm2};
        public string device_path { get; set; }
        public Pool_Format_Types Pool_Format_Type { get; set; }
        public Storage_Pool_Disk()
        {
            _Pool_Type = Concrete.Storage_Pool.Pool_Types.netfs;
            Pool_Format_Type = Pool_Format_Types.gpt;
        }
        public override string To_XML()
        {
            return "<source><device path='" + device_path + "'/><format type='" + Pool_Format_Type.ToString() + "'/></source>";
        }
        public override void From_XML(System.Xml.Linq.XElement xml)
        {

        }
        public override void Validate(IValdiator v)
        {

        }
    }
}
