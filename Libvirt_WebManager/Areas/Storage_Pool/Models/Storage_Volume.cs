using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Libvirt_WebManager.Areas.Storage_Pool.Models
{
    public class Storage_Volume : ViewModels.BaseViewModel, IValidatableObject
    {
        public Storage_Volume()
        {
         
        }
        [Display(Name = "Volume Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string name { get; set; }

        [Display(Name = "Volume Type")]
        [Required]
        public Libvirt.Models.Concrete.Storage_Volume.Volume_Types Volume_Type { get; set; }
        [Display(Name = "Advanced Allocation")]
        [Required]
        public Int64 allocation { get; set; }
        [Display(Name = "Total Capacity")]
        [Required]
        public Int64 capacity { get; set; }
        [Display(Name = "Seed File")]
        public System.Web.HttpPostedFileBase File { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (allocation > capacity)
            {
                yield return new ValidationResult("Cannot allocate more than the total capacity!", new[] { "allocation" });
            }
        }
    }
}