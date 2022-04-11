using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Session_Models
{
    public class SessionListItem
    {
        public int SessionID { get; set; }

        [Display(Name = "Title")]
        public string SessionTitle { get; set; }

        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
