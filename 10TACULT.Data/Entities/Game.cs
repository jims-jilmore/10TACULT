using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Must Enter At Least 1 Character")]
        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        public string GameTitle { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string ESRB { get; set; }

        //Game Has Publisher (i.e. BANDAI NAMCO)
        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }

        //Game Has Developer (i.e. FROM SOFTWARE)
        [ForeignKey("Developer")]
        public int DevID { get; set; }
        public virtual Developer Developer { get; set; }

        //Game Can Have Many Platforms
        //[ForeignKey("Platform")]
        public virtual ICollection<Platform> Platforms { get; set; }

        //Game Can Have Many Tags
        //[ForeignKey("Tag")]
        //[InverseProperty(nameof(Tag.Game))]
        public virtual ICollection<Tag> Tags { get; set; }


        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

    }
}
