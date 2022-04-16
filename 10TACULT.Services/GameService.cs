using _10TACULT.Data;
using _10TACULT.Data.Entities;
using _10TACULT.Models.Game_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TACULT.Services
{
    public class GameService
    {
        private readonly string _userID;

        public GameService(string userID)
        {
            _userID = userID;
        }

        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games
                    .Select(g => new GameListItem()
                    {
                        GameID = g.GameID,
                        GameTitle = g.GameTitle,
                        CreatedUTC = g.CreatedUTC
                    });
                return query.ToArray();
            }
        }

        public GameDetail GetGameByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games
                    .Single(g => g.GameID == id && g.UserID == _userID);
                return new GameDetail
                {
                    GameID = entity.GameID,
                    GameTitle = entity.GameTitle,
                    Genre = entity.Genre,
                    ReleaseDate = entity.ReleaseDate,
                    ESRB = entity.ESRB,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                UserID = _userID,
                GameTitle = model.GameTitle,
                Genre = model.Genre,
                ReleaseDate = model.ReleaseDate,
                ESRB = model.ESRB,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            //Need the Association with a Developer
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games
                    .Single(g => g.GameID == model.GameID && g.UserID == _userID);

                entity.GameTitle = model.GameTitle;
                entity.Genre = model.Genre;
                entity.ReleaseDate = model.ReleaseDate;
                entity.ESRB = model.ESRB;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games
                    .Single(g => g.GameID == id && g.UserID == _userID);

                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
