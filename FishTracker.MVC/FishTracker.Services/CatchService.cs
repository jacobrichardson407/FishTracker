using FishTracker.Data;
using FishTracker.Models.Catch;
using FishTracker.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Services
{
    public class CatchService
    {
        private readonly Guid _userId;
        public CatchService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCatch(CatchCreate model)
        {
            var entity =
                new Catch()
                {
                    AnglerId = _userId,
                    FishSpecies = model.FishSpecies,
                    Length = model.Length,
                    Weight = model.Weight,
                    CatchDate = model.CatchDate,
                    TypeOfLure = model.TypeOfLure,
                    Location = model.Location,
                    WeatherType = model.WeatherType,
                    Temperature = model.Temperature
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Catches.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CatchListItem> GetCatches()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Catches
                    .Where(e => e.AnglerId == _userId)
                    .Select(
                        e =>
                        new CatchListItem()
                        {
                            CatchId = e.CatchId,
                            Name = e.FishSpecies,
                            TypeOfLure = e.TypeOfLure,
                            Length = e.Length,
                            Weight = e.Weight,
                            CatchDate = e.CatchDate,
                            Location = e.Location,
                            WeatherType = e.WeatherType,
                            Temperature = e.Temperature
                        }
                        );
                return query.ToArray();
            }
        }
        public CatchDetail GetCatchById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catches
                    .Single(e => e.CatchId == id && e.AnglerId == _userId);
                return
                    new CatchDetail()
                    {
                        CatchId = entity.CatchId,
                        FishSpecies = entity.FishSpecies,
                        Length = entity.Length,
                        Weight = entity.Weight,
                        CatchDate = entity.CatchDate,
                        TypeOfLure = entity.TypeOfLure,
                        Location = entity.Location,
                        WeatherType = entity.WeatherType,
                        Temperature = entity.Temperature
                    };
            }
        }
        public bool UpdateCatch(CatchEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catches
                    .Single(e => e.CatchId == model.CatchId && e.AnglerId == _userId);

                entity.FishSpecies = model.FishSpecies;
                entity.Length = model.Length;
                entity.Weight = model.Weight;
                entity.CatchDate = model.CatchDate;
                entity.TypeOfLure = model.TypeOfLure;
                entity.Location = model.Location;
                entity.WeatherType = model.WeatherType;
                entity.Temperature = model.Temperature;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCatch(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catches
                    .Single(e => e.CatchId == id && e.AnglerId == _userId);
                ctx.Catches.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
