using _10TACULT.Data;
using _10TACULT.Data.Entities;
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
                        CreatedUTC = d.CreatedUTC
                    });
                    return query.ToArray();
            }
        }

        public DevDetail GetDevByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers
                    .Single(d => d.DevID == id);
                return
                    new DevDetail
                    {
                        DevID = entity.DevID,
                        DevName = entity.DevName,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool CreateDev(DevCreate model)
        {
            var entity = new Developer()
            {
                CreatorID = _userID,
                DevName = model.DevName,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateDev(DevEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers
                    .Single(d => d.DevID == model.DevID);

                entity.DevName = model.DevName;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteDev(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers
                    .Single(d => d.DevID == id);

                ctx.Developers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
