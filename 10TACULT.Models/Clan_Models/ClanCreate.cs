using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Clan_Models
{
    public class ClanCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Name Not To Exceed 25 Characters")]
        [Display(Name = "Clan")]
        public string ClanName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Description Not To Exceed 200 Characters")]
        [Display(Name = "Description")]
        public string ClanDesc { get; set; }
    }
}
