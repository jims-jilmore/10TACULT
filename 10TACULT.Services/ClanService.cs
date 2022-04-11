using _10TACULT.Data;
using _10TACULT.Models.Clan_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class ClanService
    {
        private readonly string _userID;

        public ClanService(string userID)
        {
            _userID = userID;
        }

        public IEnumerable<ClanListItem> GetAllClans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Clans
                    .Select(c => new ClanListItem()
                    {
                        ClanID = c.ClanID,
                        ClanName = c.ClanName,
                        //CreatedUTC = c.Created
                    });
                return query.ToArray();
            }
        }
    }
}
