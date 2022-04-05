using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Developer
    {
        [Key]
        public int DevID { get; set; }

        [Required]
        public string DevName { get; set; }

        public ICollection<Game> Games { get; set; }

        //Developer Can Be Tied To Publisher Depending On Game
    }
}
