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
    public class CatchCreate
    {
        public virtual FishSpecies FishSpecies { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public DateTime CatchDate { get; set; }
        public virtual List<LureType> TypeOfLure { get; set; }
        public virtual List<FishTracker.Data.Lure> LureBrand { get; set; }
        public virtual List<FishTracker.Data.Lure> LureName { get; set; }
        public string Location { get; set; }
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        public double Temperature { get; set; }
    }
}
