using _10TACULT.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Publisher_Models
{
    public class PublisherDetail
    {
        public int PublisherID { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }

        public ICollection<Game> Games { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
