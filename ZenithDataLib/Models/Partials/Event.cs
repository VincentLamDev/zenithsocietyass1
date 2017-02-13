using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithDataLib.Validation;

namespace ZenithDataLib.Models
{
    [MetadataType(typeof(EventMetaData))]
    public partial class Event { }
    class EventMetaData
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Must enter a start time and date")]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Must enter a end time and date")]
        [DisplayName("End Date")]
        [EndDateValidationAttribute]
        public DateTime End { get; set; }

        [DisplayName("Username")]
        public string CreatedBy { get; set; }

        [Required]
        [DisplayName("Activity")]
        [UIHint("ActivityDropDownList")]
        public int ActivityId { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }


    }
}
