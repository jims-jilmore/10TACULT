using _10TACULT.Data;
using _10TACULT.Data.Entities;
using _10TACULT.Models.Tag_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class TagService
    {
        private readonly string _userID;

        public TagService(string userID)
        {
            _userID = userID;
        }

        public IEnumerable<TagListItem> GetAllTags()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tags
                    .Select(t => new TagListItem()
                    {
                        TagID = t.TagID,
                        TagName = t.TagName,
                        CreatedUTC = t.CreatedUTC
                    });
                return query.ToArray();
            }
        }

        public TagDetail GetTagByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags
                    .Single(t => t.TagID == id && t.UserID == _userID);

                return new TagDetail
                {
                    TagID = entity.TagID,
                    TagName = entity.TagName,
                    CreatedUTC = entity.CreatedUTC
                };
            }
        }

        public bool CreateTag(TagCreate model)
        {
            var entity = new Tag()
            {
                TagName = model.TagName,
                CreatedUTC = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tags.Add(entity);
                return ctx.SaveChanges() == 1; 
            }
        }

        public bool UpdateTag(TagEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags
                    .Single(t => t.TagID == model.TagID && t.UserID == _userID);

                entity.TagName = model.TagName;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTag(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tags
                    .Single(t => t.TagID == id && t.UserID == _userID);

                ctx.Tags.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
