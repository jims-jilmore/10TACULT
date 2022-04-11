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

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string PlatformName { get; set; }

        [Required]
        public string PlatformDeveloper { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
 
        public virtual ICollection<Game> Games { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
