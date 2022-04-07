using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Clan_Models
{
    public class ClanCreate
    {
        [Required]
        public string ClanName { get; set; }
        [Required]
        public string ClanDesc { get; set; }

    }
}
