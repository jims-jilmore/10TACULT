using _10TACULT.Data;
using _10TACULT.Models.Dev_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class DevService
    {
        private readonly string _userID;

        public DevService(string userID)
        {
            _userID = userID;
        }

        public IEnumerable<DevListItem> GetAllDevs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Developers
                    .Select(d => new DevListItem()
                    {
                        DevID = d.DevID,
                        DevName = d.DevName,
                        //Created = d.
                    });
                    return query.ToArray();
            }
        }
    }
}
