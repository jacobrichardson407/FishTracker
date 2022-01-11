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
        public enum Weather { Sunny =1, PartlySunny, PartlyCloudy, Cloudy, Fog, Rain, Snow, Hail, Sleet }
        [Key]
        public int CatchId { get; set; }
        [Required]
        [ForeignKey(nameof(FishSpecies))]
        public int SpeciesId { get; set; }
        public virtual FishSpecies Species { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTime CatchDate { get; set; }
        [Required]
        [ForeignKey("Lure")]
        public int LureId { get; set; }
        public virtual Lure Lure { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        [Required]
        public double Temperature { get; set; }
    }
}
