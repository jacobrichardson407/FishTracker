using FishTracker.Data;
using FishTracker.Models.Catch;
using FishTracker.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
                    SpeciesName = model.SpeciesName.ToString(),
                    LureTypes = model.LureType,
                    Length = model.Length,
                    Weight = model.Weight,
                    CatchDate = model.CatchDate.Date,
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
                    .OrderByDescending(date => date.CatchDate).Take(10).ToList()
                    .Select(
                        e =>
                        new CatchListItem()
                        {
                            CatchId = e.CatchId,
                            SpeciesName = e.SpeciesName,
                            LureType = e.LureTypes,
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
                        SpeciesName = new FishTracker.Models.Species.SpeciesListItem().SpeciesName,
                        LureType = entity.LureTypes,
                        Length = entity.Length,
                        Weight = entity.Weight,
                        CatchDate = entity.CatchDate.Date,
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

                entity.SpeciesName = model.SpeciesName.ToString();
                entity.LureTypes = model.LureType;
                entity.Length = model.Length;
                entity.Weight = model.Weight;
                entity.CatchDate = model.CatchDate.Date;
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
