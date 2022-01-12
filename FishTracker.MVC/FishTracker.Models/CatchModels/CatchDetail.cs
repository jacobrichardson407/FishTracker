using FishTracker.Data;
using System;
using System.Collections.Generic;
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
        public FishSpecies FishSpecies { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public DateTime CatchDate { get; set; }
        public LureType TypeOfLure { get; set; }
        public string Location { get; set; }
        public Weather WeatherType { get; set; }
        public double Temperature { get; set; }
    }
}
