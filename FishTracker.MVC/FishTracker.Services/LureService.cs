using FishTracker.Data;
using FishTracker.Models.Lure;
using FishTracker.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Services
{
    public class LureService
    {
        private readonly Guid _userId;
        public LureService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLure(LureCreate model)
        {
            var entity =
                new Lure()
                {
                    AnglerId = _userId,
                    LureBrand = model.Brand,
                    LureName = model.Name,
                    Color = model.Color,
                    TypeOfLure = model.TypeOfLure
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LureListItem> GetLures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Lures
                    .Where(e => e.AnglerId == _userId)
                    .Select(
                        e =>
                        new LureListItem()
                        {
                            LureId = e.LureId,
                            Brand = e.LureBrand,
                            Name = e.LureName,
                            Color = e.Color,
                            TypeOfLure = e.TypeOfLure
                        }
                        );
                return query.ToArray();
            }
        }
        public LureDetail GetLureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lures
                    .Single(e => e.LureId == id && e.AnglerId == _userId);
                return
                    new LureDetail()
                    {
                        LureId = entity.LureId,
                        Brand = entity.LureBrand,
                        Name = entity.LureName,
                        Color = entity.Color,
                        TypeOfLure = entity.TypeOfLure
                    };
            }
        }
        public bool UpdateLure(LureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lures
                    .Single(e => e.LureId == model.LureId && e.AnglerId == _userId);

                entity.LureBrand = model.Brand;
                entity.LureName = model.Name;
                entity.Color = model.Color;
                entity.TypeOfLure = model.TypeOfLure;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLure(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lures
                    .Single(e => e.LureId == id && e.AnglerId == _userId);
                ctx.Lures.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
