using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Platform_Models
{
    public class PlatformDetail
    {
        public int PlatformID { get; set; }

        [Display(Name = "Platform")]
        public string PlatformName { get; set; }

        [Display(Name = "Developer")]
        public string PlatformDeveloper { get; set; }

        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
