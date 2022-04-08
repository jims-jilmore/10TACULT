using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        //Session Will Have A Creator
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string SessionTitle { get; set; }

        [Required]
        public string SessionDesc { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        //Session Will Have A Game
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        //Session Will Have A Clan
        [ForeignKey("Clan")]
        public int ClanID { get; set; }
        public virtual Clan Clan { get; set; }

        //Session Will Have Clan Members
        public virtual ICollection<ApplicationUser> Members { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }


    }
}
