using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.ViewModels.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class HostNameAttribute : ValidationAttribute
    {
        public HostNameAttribute(bool check_if_host_is_reachable = true)
        {
            _check_if_host_is_reachable = check_if_host_is_reachable;
        }
        private bool _check_if_host_is_reachable { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var host_or_ip = value as string;
            if (string.IsNullOrWhiteSpace(host_or_ip)) host_or_ip = "";

            var addrtype = Uri.CheckHostName(host_or_ip);
            if (addrtype == UriHostNameType.Unknown)
            {
                return new ValidationResult("Address is not an IP address or Hostname!", new string[] { validationContext.MemberName });
            }
            else if (addrtype == UriHostNameType.IPv4)
            {

                if (Libvirt_WebManager.Utilities.IPVHelper.CheckIPValid(host_or_ip))
                {
                    if (_check_if_host_is_reachable)
                    {
                        if (!Libvirt.Utilities.Network.IsAvailable(host_or_ip))
                        {
                            return new ValidationResult("Address is valid, but not reachable!", new string[] { validationContext.MemberName });
                        }
                    }
                }
                else
                {
                    return new ValidationResult("Address is not a valid IP address!", new string[] { validationContext.MemberName });
                }
            }
            else if (_check_if_host_is_reachable)
            {
                if (!Libvirt.Utilities.Network.IsAvailable(host_or_ip))
                {
                    return new ValidationResult("Address is valid, but not reachable!", new string[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }

    }
}
