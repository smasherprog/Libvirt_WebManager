using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Validators
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly uint _maxFileSize;
        public MaxFileSizeAttribute(uint maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
            var size = Convert.ToUInt32(file.ContentLength);
            return size <= _maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }
    }
}