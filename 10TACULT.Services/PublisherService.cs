using _10TACULT.Data;
using _10TACULT.Data.Entities;
using _10TACULT.Models.Publisher_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class PublisherService
    {
        private readonly string _userID;

        public PublisherService(string userID)
        {
            _userID = userID;
        }

        public IEnumerable<PublisherListItem> GetAllPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Publishers
                    .Select(p => new PublisherListItem()
                    {
                        PublisherID = p.PublisherID,
                        PublisherName = p.PublisherName,
                        CreatedUTC = p.CreatedUTC
                    });
                return query.ToArray();
            }
        }

        public PublisherDetail GetPublisherByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers
                    .Single(p => p.PublisherID == id);
                return new PublisherDetail
                {
                    PublisherID = entity.PublisherID,
                    PublisherName = entity.PublisherName,
                    Games = entity.Games,
                    CreatedUTC = entity.CreatedUTC
                };
            }
        }

        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                PublisherName = model.PublisherName,
                Games = new List<Game>(),
                CreatedUTC = DateTimeOffset.UtcNow,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers
                    .Single(p => p.PublisherID == model.PublisherID);

                entity.PublisherName = model.PublisherName;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers
                    .Single(p => p.PublisherID == id && p.CreatorID == _userID);

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
