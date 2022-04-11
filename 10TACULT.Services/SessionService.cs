using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class SessionService
    {
        private readonly string _userID;

        public SessionService(string userID)
        {
            _userID = userID;
        }
    }
}
