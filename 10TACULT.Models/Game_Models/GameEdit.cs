using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Game_Models
{
    public class GameEdit
    {
        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ESRB { get; set; }

    }
}
