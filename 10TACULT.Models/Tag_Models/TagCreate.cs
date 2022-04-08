using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Tag_Models
{
    public class TagCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Tag Must Be At Least 1 Character")]
        [MaxLength(25, ErrorMessage = "Tag Not To Exceed 25 Characters")]
        public string TagName { get; set; }
    }
}
