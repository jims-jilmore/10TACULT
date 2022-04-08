using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Dev_Models
{
    public class DevCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name Must Be At Least 1 Character")]
        [MaxLength(50, ErrorMessage = "Name Not To Exceed 50 Characters")]
        public string DevName { get; set; }

    }
}
