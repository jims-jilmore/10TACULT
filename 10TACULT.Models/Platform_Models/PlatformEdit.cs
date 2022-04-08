using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Platform_Models
{
    public class PlatformEdit
    {
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public string PlatformDeveloper { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
