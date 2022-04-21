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
                    .Single(c => c.ClanID == id);
                return
                    new ClanDetail
                    {
                        ClanID = entity.ClanID,
                        ClanName = entity.ClanName,
                        ClanDesc = entity.ClanDesc,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC,
                        Members = entity.Members
                    };
            }
        }

        public bool CreateClan(ClanCreate model)
        {
            var entity = new Clan()
            {
                FounderID = _userID,
                ClanName = model.ClanName,
                ClanDesc = model.ClanDesc,
                CreatedUTC = DateTimeOffset.UtcNow,
                Members = new List<ApplicationUser>()
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
                    .Single(c => c.ClanID == model.ClanID && c.FounderID == _userID);

                entity.ClanName = model.ClanName;
                entity.ClanDesc = model.ClanDesc;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                entity.Members = model.Members;
                
                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteClan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clans
                    .Single(c => c.ClanID == id && c.FounderID == _userID);

                ctx.Clans.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool AddClanMember(string memberID, int clanID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var member = ctx.Users
                    .Single(m => m.Id == memberID);

                var clan = ctx.Clans
                    .Single(m => m.ClanID == clanID);

                clan.Members.Add(member);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveClanMember(string memberID, int clanID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var member = ctx.Users.Single(m => m.Id == memberID);
                var clan = ctx.Clans.Single(c => c.ClanID == clanID);

                clan.Members.Remove(member);

                return ctx.SaveChanges() == 1;
            }
        }

        //public ICollection<ApplicationUser> GetClanMembers(int clanID)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Clans
        //            .Single(c => c.ClanID == clanID);
        //        return entity.Members.ToList();
        //    }
        //}

        public IEnumerable<ClanMemberListItem> GetAllClanMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Clans
                    .Select(c => new ClanMemberListItem()
                    {
                        MemberID = c.ApplicationUser.Id,
                        MemberName = c.ApplicationUser.ProfileName
                    });
                return query.ToArray();
            }
        }
    }
}
