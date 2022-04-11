using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Game_Models
{
    public class GameCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Title Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Name Not To Exceed 50 Characters")]
        [Display(Name = "Title")]
        public string GameTitle { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Genre Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Genre Not To Exceed 25 Characters")]
        public string Genre { get; set; }
        
        [Required]
        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "ESRB Rating")]
        public string ESRB { get; set; }
    }
}
