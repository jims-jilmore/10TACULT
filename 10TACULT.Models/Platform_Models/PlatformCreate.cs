using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Platform_Models
{
    public class PlatformCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Name Not To Exceed 25 Characters")]
        [Display(Name = "Platform")]
        public string PlatformName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Name Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Name Not To Exceed 25 Characters")]
        [Display(Name = "Developer")]
        public string PlatformDeveloper { get; set; }

        [Required]
        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }
    }
}
