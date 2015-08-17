using Libvirt_WebManager.ViewModels.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Areas.Network.Models
{
    public class Create_Network_Down : ViewModels.BaseViewModel, IValidatableObject
    {
        public Create_Network_Down()
        {
            Configuration = new Create_Network_Configuration();
        }
        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Enable ipv6")]
        public bool ipv6 { get; set; }

        [Display(Name = "Guid")]
        public string uuid { get; set; }

        [Required]
        [Display(Name = "Network Type")]
        public Libvirt.Models.Concrete.Network.Forward_Types Forward_Type { get; set; }

        public Create_Network_Configuration Configuration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Forward_Type == Libvirt.Models.Concrete.Network.Forward_Types.nat)
            {
                if (!Utilities.IPVHelper.CheckIPValid(Configuration.default_gateway_address))
                    yield return new ValidationResult("Default Gateway Address is not a valid IPV4 address", new string[] { "Configuration.default_gateway_address" });
                if (!Utilities.IPVHelper.CheckIPValid(Configuration.netmask))
                    yield return new ValidationResult("Subnet Mask is not a valid IPV4 address", new string[] { "Configuration.netmask" });
                if (!Utilities.IPVHelper.CheckIPValid(Configuration.dhcp_range_start))
                    yield return new ValidationResult("DHCP Start Address is not a valid IPV4 address", new string[] { "Configuration.dhcp_range_start" });
                if (!Utilities.IPVHelper.CheckIPValid(Configuration.dhcp_range_end))
                    yield return new ValidationResult("DHCP End Address is not a valid IPV4 address", new string[] { "Configuration.dhcp_range_end" });
            }
        }
    }
    public class Create_Network_Configuration
    {
        [Display(Name = "Default Gateway")]
        public string default_gateway_address { get; set; }

        [Display(Name = "Network Mask")]
        public string netmask { get; set; }

        [Display(Name = "dhcp start address")]
        public string dhcp_range_start { get; set; }

        [Display(Name = "dhcp end address")]
        public string dhcp_range_end { get; set; }

    }
}