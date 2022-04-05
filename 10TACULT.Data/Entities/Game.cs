using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string GameTitle { get; set; }

        [Required]
        public string Genre { get; set; }

        //Game Has Publisher (i.e. BANDAI NAMCO)

        //Game Has Developer (i.e. FROM SOFTWARE)

        public ICollection<Platform> Platforms { get; set; }
        //Game Can Have Many Platforms

        public ICollection<Tag> Tags { get; set; }
        //Game Can Have Many Tags

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string ESRB { get; set; } // US RATINGS FOR NOW

        [Required]
        public DateTimeOffset Created { get; set; }

    }
}
