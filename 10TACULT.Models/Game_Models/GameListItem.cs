using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Game_Models
{
    public class GameListItem
    {
        public int GameID { get; set; }

        [Display(Name = "Title")]
        public string GameTitle { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset Created { get; set; }
    }
}
