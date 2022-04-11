using _10TACULT.Data;
using _10TACULT.Data.Entities;
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
                        CreatedUTC = c.CreatedUTC
                    });
                return query.ToArray();
            }
        }
        public ClanDetail GetClanByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clans
                    .Single(c => c.ClanID == id && c.UserID == _userID);
                return
                    new ClanDetail
                    {
                        ClanID = entity.ClanID,
                        ClanName = entity.ClanName,
                        ClanDesc = entity.ClanDesc,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool CreateClan(ClanCreate model)
        {
            var entity = new Clan()
            {
                UserID = _userID,
                ClanName = model.ClanName,
                ClanDesc = model.ClanDesc,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateClan(ClanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clans
                    .Single(c => c.ClanID == model.ClanID && c.UserID == _userID);

                entity.ClanName = model.ClanName;
                entity.ClanDesc = model.ClanDesc;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteClan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clans
                    .Single(c => c.ClanID == id && c.UserID == _userID);

                ctx.Clans.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
