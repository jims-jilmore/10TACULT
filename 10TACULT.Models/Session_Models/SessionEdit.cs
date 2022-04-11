using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Session_Models
{
    public class SessionEdit
    {
        public int SessionID { get; set; }

        [Display(Name = "Title")]
        public string SessionTitle { get; set; }

        [Display(Name = "Description")]
        public string SessionDesc { get; set; }

        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
    }
}
