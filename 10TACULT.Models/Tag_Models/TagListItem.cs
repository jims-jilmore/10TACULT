using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Tag_Models
{
    public class TagListItem
    {
        public int TagID { get; set; }

        [Display(Name = "Tag")]
        public string TagName { get; set; }

        [Display(Name = "Created" )]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
