using _10TACULT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Models.Tag_Models
{
    public class TagCreate
    {
        public string TagName { get; set; }
        public virtual Game Game { get; set; }
    }
}
