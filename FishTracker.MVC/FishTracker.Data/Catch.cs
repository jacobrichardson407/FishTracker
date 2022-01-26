using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static FishTracker.Data.Lure;

namespace FishTracker.Data
{
    public class Catch
    {
        [Key]
        [Display(Name = "Catch Id")]
        public int CatchId { get; set; }
        public int SpeciesId { get; set; }
        public List<FishSpecies> SpeciesList { get; set; }
        [Display(Name = "Species Name")]
        public string SpeciesName { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime CatchDate { get; set; }
        public int LureId { get; set; }
        [Display(Name = "Types of Lures")]
        public LureType LureTypes { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        [Required]
        public double Temperature { get; set; }
        public Guid AnglerId { get; set; }
        public enum Weather
        {
            Sunny = 1,
            [Display(Name = "Partly Cloudy")]
            PartlyCloudy,
            Cloudy,
            Fog,
            Rain,
            Snow,
            Hail,
            Sleet
        }
    }
}
