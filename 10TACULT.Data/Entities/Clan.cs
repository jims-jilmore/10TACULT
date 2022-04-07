using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Clan
    {
        [Key]
        public int ClanID { get; set; }

        //Clan Will Have A Creator
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string ClanName { get; set; }

        [Required]
        public string ClanDesc { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

    }
}
