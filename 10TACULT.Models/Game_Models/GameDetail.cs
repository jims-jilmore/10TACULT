using _10TACULT.Data.Entities;
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

        public Publisher Publisher { get; set; } //virtual Publisher?

        public Developer Developer { get; set; } //virtual Developer?

        public ICollection<Platform> Platforms { get; set; }  //virtual?
        public ICollection<Tag> Tags { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
