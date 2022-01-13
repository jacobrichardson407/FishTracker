using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.Lure;

namespace FishTracker.Data
{
    public class Catch
    {
        [Key]
        public int CatchId { get; set; }
        [Required]
        [ForeignKey("FishSpecies")]
        public int SpeciesId { get; set; }
        public virtual FishSpecies FishSpecies { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTime CatchDate { get; set; }
        public virtual List<LureType> TypeOfLure { get; set; }
        public virtual List<Lure> LureBrand { get; set; }
        public virtual List<Lure> LureName { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        [Required]
        public double Temperature { get; set; }
        public Guid AnglerId { get; set; }
        public enum Weather { Sunny =1, PartlySunny, PartlyCloudy, Cloudy, Fog, Rain, Snow, Hail, Sleet }
    }
}
