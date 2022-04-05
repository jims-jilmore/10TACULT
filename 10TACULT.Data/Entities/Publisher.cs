using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PublisherName { get; set; }

        public ICollection<Game> Games { get; set; }
        //Publisher Can Have Many Games

        //Publisher Can Be Tied To Developer Depending On Game

    }
}
