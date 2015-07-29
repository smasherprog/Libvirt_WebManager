using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.ViewModels.Domain
{
    public enum NewDomain_OS_Options { Local, Network, PXE, Import };
    public class New_Domain_VM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]       
        [Display(Name = "Ram")]
        public int Ram { get; set; }
        [Required]
        [Display(Name = "Cpus")]
        public int Cpus { get; set; }
        [Required]
        [Display(Name = "OS Pool")]
        public string OS_Pool { get; set; }
        [Required]
        [Display(Name = "OS Volume")]
        public string OS_Volume { get; set; }
        [Required]
        [Display(Name = "HD Pool")]
        public string HD_Pool { get; set; }
        [Required]
        [Display(Name = "HD Volume")]
        public string HD_Volume { get; set; }
    }
    public class New_Domain_Down_VM
    {
    
        public New_Domain_Down_VM(){
            InstallOptions = new List<SelectListItem>{
                new SelectListItem { Text = "Local install media (ISO image or CDROM)", Value = NewDomain_OS_Options.Local.ToString()},
                new SelectListItem { Text = "Network Install (HTTP, FTP, or NFS)", Value = NewDomain_OS_Options.Network.ToString()},
                new SelectListItem { Text = "Network Boot (PXE)", Value = NewDomain_OS_Options.PXE.ToString()},
                new SelectListItem { Text = "Import exisiting disk image", Value = NewDomain_OS_Options.Import.ToString()}
            };
            Domain = new New_Domain_VM();
        }
        public New_Domain_VM Domain { get; set; }
        public Libvirt.CS_Objects.Host Host { get; set; }

        public List<SelectListItem> InstallOptions { get; set; }
    }
}