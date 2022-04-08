using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Session_Models
{
    public class SessionEdit
    {
        public int SessionID { get; set; }
        public string SessionTitle { get; set; }
        public string SessionDesc { get; set; }
        public DateTime SessionDate { get; set; }
    }
}
