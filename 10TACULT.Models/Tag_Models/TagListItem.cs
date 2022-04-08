using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Tag_Models
{
    public class TagListItem
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
