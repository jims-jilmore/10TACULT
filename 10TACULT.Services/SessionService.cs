using _10TACULT.Data;
using _10TACULT.Data.Entities;
using _10TACULT.Models.Publisher_Models;
using _10TACULT.Models.Session_Models;
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

        public IEnumerable<SessionListItem> GetAllSessions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Sessions
                    .Select(s => new SessionListItem()
                    {
                        SessionID = s.SessionID,
                        SessionTitle = s.SessionTitle,
                        SessionDate = s.SessionDate,
                        CreatedUTC = s.CreatedUTC
                    });
                return query.ToArray();
            }
        }

        public SessionDetail GetSessionByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sessions
                    .Single(s => s.SessionID == id && s.UserID == _userID);
                return new SessionDetail()
                {
                    SessionID = entity.SessionID,
                    SessionTitle = entity.SessionTitle,
                    SessionDesc = entity.SessionDesc,
                    SessionDate = entity.SessionDate,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool CreateSession(SessionCreate model)
        {
            var entity = new Session()
            {
                SessionTitle = model.SessionTitle,
                SessionDesc = model.SessionDesc,
                SessionDate = model.SessionDate,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            //Need the association with a Clan

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateSession(SessionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sessions
                    .Single(s => s.SessionID == model.SessionID && s.UserID == _userID);

                entity.SessionTitle = model.SessionTitle;
                entity.SessionDesc = model.SessionDesc;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSession(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sessions
                    .Single(s => s.SessionID == id && s.UserID == _userID);

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
