using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Publisher_Models
{
    public class PublisherListItem
    {
        public int PublisherID { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
