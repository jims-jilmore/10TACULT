using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Session_Models
{
    public class SessionCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Title Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Title Not To Exceed 50 Characters")]
        [Display(Name = "Title")]
        public string SessionTitle { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Description Must Be At Least 1 Character")]
        [MaxLength(200, ErrorMessage = "Description Not To Exceed 200 Characters")]
        [Display(Name = "Description")]
        public string SessionDesc { get; set; }

        [Required]
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }

    }
}
