using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class WaterlLevelValidation
    {
        [Display(Name = "Fishable")]
        public string AWaterLevel { get; set; }

        [Display(Name = "Water Body")]
        public string WaterBody { get; set; }

        [Display(Name="Current Level")]
        public string WaterLevel1 { get; set; }

    }

    [MetadataType(typeof (WaterlLevelValidation))]
    public partial class WaterLevel
    {
       
    }
}
