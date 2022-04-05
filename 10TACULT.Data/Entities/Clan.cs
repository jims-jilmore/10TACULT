using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Clan
    {
        [Key]
        public int ClanID { get; set; }

        [Required]
        public string ClanName { get; set; }

        [Required]
        public string ClanDesc { get; set; }

        //Clan Will Have A Creator

        public ICollection<ApplicationUser> Members { get; set; }
        //Clan Can Have Many Members

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }


    }
}
