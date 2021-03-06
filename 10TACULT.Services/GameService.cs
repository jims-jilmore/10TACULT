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
                    .Single(g => g.GameID == id && g.CreatorID == _userID);
                return new GameDetail
                {
                    GameID = entity.GameID,
                    GameTitle = entity.GameTitle,
                    Genre = entity.Genre,
                    ReleaseDate = entity.ReleaseDate,
                    ESRB = entity.ESRB,
                    Publisher = entity.Publisher,
                    Developer = entity.Developer,
                    Platforms = entity.Platforms,
                    Tags = entity.Tags,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool CreateGame(GameCreate model)
        {
            var ctx = new ApplicationDbContext();
            var entity = new Game()
            {
                CreatorID = _userID,
                GameTitle = model.GameTitle,
                Genre = model.Genre,
                ReleaseDate = model.ReleaseDate,
                ESRB = model.ESRB,
                CreatedUTC = DateTimeOffset.UtcNow,
                Publisher = model.Publisher,
                Developer = model.Developer,
                Tags = new List<Tag>(),
                Platforms = new List<Platform>() // Will Probably Change Once Platform Is Updated
            };

            ctx.Games.Add(entity);

            return ctx.SaveChanges() == 1;
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games
                    .Single(g => g.GameID == model.GameID && g.CreatorID == _userID);

                entity.GameTitle = model.GameTitle;
                entity.Genre = model.Genre;
                entity.ReleaseDate = model.ReleaseDate;
                entity.ESRB = model.ESRB;
                entity.Publisher = model.Publisher;
                entity.Developer = model.Developer;
                entity.Platforms = model.Platforms.ToList();
                entity.Tags = model.Tags.ToList();
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games
                    .Single(g => g.GameID == id && g.CreatorID == _userID);

                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1; 
            }
        }

    }
}
