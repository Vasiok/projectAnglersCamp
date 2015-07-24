using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class AWLevelValidation
    {

        [Required]        
        public string Name { get; set; }
        
        [Required]
        public string County { get; set; }
        [Required]
        [Display(Name="Water body")]
        public string WaterBody { get; set; }
        [Required]
        public string Level { get; set; }

          
    }

    [MetadataType(typeof(AWLevelValidation))]
    public partial class ALevelRport
    {

    }
    
}
