using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libvirt_WebManager.Models
{
    public class Validator : Libvirt.Models.Interface.IValdiator
    {
        private ModelStateDictionary _ModelStateDictionary;
        public Validator(ModelStateDictionary m)
        {
            _ModelStateDictionary = m;
        }
        public void AddError(string key, string message)
        {
            _ModelStateDictionary.AddModelError(key, message);
        }

        public bool IsValid()
        {
            return _ModelStateDictionary.IsValid;
        }
    }
}