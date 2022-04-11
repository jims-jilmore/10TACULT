using _10TACULT.Data;
using _10TACULT.Data.Entities;
using _10TACULT.Models.Platform_Models;
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

        public IEnumerable<PlatformListItem> GetAllPlatforms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Platforms
                    .Select(p => new PlatformListItem()
                    {
                        PlatformID = p.PlatformID,
                        PlatformName = p.PlatformName,
                        CreatedUTC = p.CreatedUTC
                    });
                return query.ToArray();
            }
        }

        public PlatformDetail GetPlatformByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Platforms
                    .Single(p => p.PlatformID == id && p.UserID == _userID);
                return new PlatformDetail
                {
                    PlatformID = entity.PlatformID,
                    PlatformName = entity.PlatformName,
                    PlatformDeveloper = entity.PlatformDeveloper,
                    ReleaseDate = entity.ReleaseDate,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool CreatePlatform(PlatformCreate model)
        {
            var entity = new Platform()
            {
                PlatformName = model.PlatformName,
                PlatformDeveloper = model.PlatformDeveloper,
                ReleaseDate = model.ReleaseDate,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Platforms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePlatform(PlatformEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Platforms
                    .Single(p => p.PlatformID == model.PlatformID && p.UserID == _userID);

                entity.PlatformName = model.PlatformName;
                entity.PlatformDeveloper = model.PlatformDeveloper;
                entity.ReleaseDate = model.ReleaseDate;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlatform(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Platforms
                    .Single(p => p.PlatformID == id && p.UserID == _userID);

                ctx.Platforms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
