using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        [Required]
        public string SessionTitle { get; set; }

        [Required]
        public string SessionDesc { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        //Session Will Have A Creator

        //Session Will Have A Game

        //Session Will Have A Clan


        public ICollection<ApplicationUser> Members { get; set; }
        //Session Can Have Many Members

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }


    }
}
