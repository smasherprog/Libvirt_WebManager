using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Libvirt_WebManager.ViewModels.Storage
{
    public class Storage_Volume_Details : BaseViewModel
    {
        public Libvirt.CS_Objects.Storage_Volume Volume { get; set; }
    }
}