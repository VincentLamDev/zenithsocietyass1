using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ZenithDataLib.Models
{
    [MetadataType(typeof(ActivityMetaData))]
    public partial class Activity { }

    class ActivityMetaData
    {
        [Required(ErrorMessage = "Must enter a description of the event")]
        [DisplayName("Activity")]
        public string Description { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
