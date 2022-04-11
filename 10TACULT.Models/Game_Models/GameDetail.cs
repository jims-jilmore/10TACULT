using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Game_Models
{
    public class GameDetail
    {
        public int GameID { get; set; }

        [Display(Name = "Title")]
        public string GameTitle { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "ESRB Rating")]
        public string ESRB { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset Created { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? Modified { get; set; }
    }
}
