using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Platform
    {
        [Key]
        public int PlatformID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Must Enter At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Too Many Characters")]
        public string PlatformName { get; set; }

        [Required]
        public string PlatformDeveloper { get; set; } //Join with Developer Entity?

        [Required]
        public DateTime ReleaseDate { get; set; }

        //Platforms Have Many Games 
        //[ForeignKey("Game")]
        // [InverseProperty(nameof(Game.Platform))]
        public virtual ICollection<Game> Games { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
