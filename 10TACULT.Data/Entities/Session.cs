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

        [ForeignKey("ApplicationUser")]
        public string CreatorID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string SessionTitle { get; set; }

        [Required]
        public string SessionDesc { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("Clan")]
        public int ClanID { get; set; }
        public virtual Clan Clan { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }


    }
}
