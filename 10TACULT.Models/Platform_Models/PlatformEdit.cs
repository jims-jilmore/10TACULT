using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Platform_Models
{
    public class PlatformEdit
    {
        public int PlatformID { get; set; }

        [Display(Name = "Platform")]
        public string PlatformName { get; set; }
        public string PlatformDeveloper { get; set; }

        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }
    }
}
