using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Publisher_Models
{
    public class PublisherCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name Must Be At Least 1 Character")]
        [MaxLength(50, ErrorMessage = "Name Not To Exceed 50 Characters")]
        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }
    }
}
