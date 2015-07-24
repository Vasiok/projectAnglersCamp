using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ReportValidation
    {
        [Required]
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime ReportDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Tactics { get; set; }

        [Required]
        public string Species { get; set; }

        //[Required]
        //[RegularExpression(@"(^PRIV$)|(^PUB$)", ErrorMessage = "Enter PRIV if you dont want to share your report and PUB otherwise")]
        //public string Visibility { get; set; }        
    }

    [MetadataType(typeof(ReportValidation))]
    public partial class Report
    {

    }
}
