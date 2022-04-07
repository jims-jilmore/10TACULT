using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Must Enter At Least 1 Character")]
        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        public string PublisherName { get; set; }

        //Publisher Can Have Many Games
        [ForeignKey("Game")]
        //[InverseProperty(nameof(Game.GameID))]
        public virtual ICollection<Game> Games { get; set; }

        //Publisher Can Have Many Developers
        //i.e. Activision (Sledgehammer, Treyarch, RavenSoftware)
        //[ForeignKey("Developer")]
        //[InverseProperty(nameof(Developer.DevID))]
        // public virtual ICollection<Developer> Developers { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

    }
}
