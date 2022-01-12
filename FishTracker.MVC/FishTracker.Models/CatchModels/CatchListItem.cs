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
    public class CatchListItem
    {
        [Key]
        public int CatchId { get; set; }
        public virtual FishSpecies Name { get; set; }
        public LureType TypeOfLure { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public DateTime CatchDate { get; set; }
        public string Location { get; set; }
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        public double Temperature { get; set; }
    }
}
