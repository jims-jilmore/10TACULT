using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Clan_Models
{
    public class ClanDetail
    {
        public int ClanID { get; set; }

        [Display(Name = "Clan")]
        public string ClanName { get; set; }

        [Display(Name = "Description")]
        public string ClanDesc { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
