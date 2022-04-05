using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Data.Entities
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        [Required]
        public string TagName { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        //Tie Tag To User Who Created It

        //Tags Are Directly Linked To A Specific Game?



    }
}
