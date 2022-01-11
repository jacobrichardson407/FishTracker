using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Data
{
    public class Catch
    {
        public enum Weather { Sunny, PartlySunny, PartlyCloudy, Cloudy, Fog, Rain, Snow, Hail, Sleet }
        [Key]
        public int CatchId { get; set; }
        [Required]
        [ForeignKey("FishSpecies")]
        public FishSpecies Species { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTime CatchDate { get; set; }
        [Required]
        public Lure Name { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        [Required]
        public double Temperature { get; set; }
    }
}
