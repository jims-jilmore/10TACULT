using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Platform_Models
{
    public class PlatformListItem
    {
        public int PlatformID { get; set; }
        
        [Display(Name = "Platform")]
        public string PlatformName { get; set; }

        public DateTimeOffset Created { get; set; }

    }
}
