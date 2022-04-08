using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        //Tag Creator
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string TagName { get; set; } //i.e. Coop, Crossplay, SinglePlayer

        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }

        //Tag Linked To Specific Game
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
