using FishTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static FishTracker.Data.Catch;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Catch
{
    public class CatchCreate
    {
        public int SpeciesId { get; set; }
        public virtual List<FishSpecies> SpeciesName { get; set; }
        public IEnumerable<SelectListItem> CaughtSpecies
        {
            get
            {
                var items = new List<FishSpecies>();
                return (IEnumerable<SelectListItem>)items;
            }
        }
        public double Length { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTime CatchDate { get; set; }
        [Required]
        public virtual List<FishTracker.Data.Lure> LureInfo { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        [Required]
        public double Temperature { get; set; }
    }
}
