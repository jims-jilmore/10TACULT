using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Dev_Models
{
    public class DevListItem
    {
        public int DevID { get; set; }

        [Display(Name = "Developer")]
        public string DevName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

    }
}
