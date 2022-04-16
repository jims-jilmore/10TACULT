﻿using _10TACULT.Data;
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
                entity.Members = model.Members.ToList(); // Not 100% Sure On This <<<----<<<
                
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
                ApplicationUser newMember = ctx.Users
                    .Single(m => m.Id == memberID);

                Clan clanToJoin = ctx.Clans
                    .Single(m => m.ClanID == clanID);

                clanToJoin.Members.Add(newMember);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
