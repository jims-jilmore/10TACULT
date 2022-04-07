using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MinLength(1, ErrorMessage = "Must Enter At Least 1 Character")]
        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        public string DevName { get; set; } 

        //[ForeignKey("Game")]
        //[InverseProperty(nameof(Game.GameID))]
        public virtual ICollection<Game> Games { get; set; }

        //Developer Can Be Tied To Publisher Depending On Game
    }
}
