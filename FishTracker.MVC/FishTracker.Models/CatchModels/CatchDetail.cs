using FishTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.Catch;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Catch
{
    public class CatchDetail
    {
        public int CatchId { get; set; }
        [Display(Name = "Species")]
        public virtual List<FishSpecies> SpeciesName { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        [Display(Name = "Date")]
        public DateTime CatchDate { get; set; }
        public virtual List<FishTracker.Data.Lure> LureInfo { get; set; }
        public string Location { get; set; }
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        public double Temperature { get; set; }
    }
}
