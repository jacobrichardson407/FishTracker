using FishTracker.Data;
using FishTracker.Models.Species;
using FishTracker.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Services
{
    public class SpeciesService
    {
        private readonly Guid _userId;
        public SpeciesService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSpecies(SpeciesCreate model)
        {
            var entity =
                new FishSpecies()
                {
                    AnglerId = _userId,
                    SpeciesName = model.SpeciesName,
                    AverageLength = model.AverageLength,
                    AverageWeight = model.AverageWeight,
                    Description = model.Description,
                    PreferredLures = model.PreferredLures
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Species.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SpeciesListItem> GetSpecies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Species
                    .Where(e => e.AnglerId == _userId)
                    .Select(
                        e =>
                        new SpeciesListItem()
                        {
                            SpeciesId = e.SpeciesId,
                            SpeciesName = e.SpeciesName,
                            AverageLength = e.AverageLength,
                            AverageWeight = e.AverageWeight,
                            Description = e.Description,
                            PreferredLures = e.PreferredLures
                        }
                        );
                return query.ToArray();
            }
        }
        public SpeciesDetail GetSpeciesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Species
                    .Single(e => e.SpeciesId == id && e.AnglerId == _userId);
                return
                    new SpeciesDetail()
                    {
                        SpeciesId = entity.SpeciesId,
                        SpeciesName = entity.SpeciesName,
                        AverageLength = entity.AverageLength,
                        AverageWeight = entity.AverageWeight,
                        Description = entity.Description,
                        PreferredLures = entity.PreferredLures
                    };
            }
        }
        public bool UpdateSpecies(SpeciesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Species
                    .Single(e => e.SpeciesId == model.SpeciesId && e.AnglerId == _userId);

                entity.SpeciesName = model.SpeciesName;
                entity.AverageLength = model.AverageLength;
                entity.AverageWeight = model.AverageWeight;
                entity.Description = model.Description;
                entity.PreferredLures = model.PreferredLures;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSpecies(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Species
                    .Single(e => e.SpeciesId == id && e.AnglerId == _userId);
                ctx.Species.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
