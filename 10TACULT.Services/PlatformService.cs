using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class PlatformService
    {
        private readonly string _userID;

        public PlatformService(string userID)
        {
            _userID = userID;
        }
    }
}
