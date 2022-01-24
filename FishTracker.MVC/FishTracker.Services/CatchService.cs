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
                    SpeciesName = model.SpeciesName,
                    LureInfo = model.LureInfo,
                    Length = model.Length,
                    Weight = model.Weight,
                    CatchDate = model.CatchDate,
                    WeatherType = model.WeatherType,
                    Location = model.Location,
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
                            SpeciesName = e.SpeciesName,
                            LureInfo = e.LureInfo.ToList(),
                            Length = e.Length,
                            Weight = e.Weight,
                            CatchDate = e.CatchDate,
                            WeatherType = e.WeatherType,
                            Location = e.Location,
                            Temperature = e.Temperature
                        }
                        );
                return query.ToList();
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
                        SpeciesName = entity.SpeciesName,
                        LureInfo = entity.LureInfo,
                        Length = entity.Length,
                        Weight = entity.Weight,
                        CatchDate = entity.CatchDate,
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

                entity.SpeciesName = model.SpeciesName;
                entity.LureInfo = model.LureInfo;
                entity.Length = model.Length;
                entity.Weight = model.Weight;
                entity.CatchDate = model.CatchDate;
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
