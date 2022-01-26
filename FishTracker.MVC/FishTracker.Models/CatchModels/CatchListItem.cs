using FishTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static FishTracker.Data.Catch;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Catch
{
    public class CatchListItem
    {
        [Key]
        public int CatchId { get; set; }
        [Display(Name = "Species")]
        public string SpeciesName { get; set; }
        [NotMapped]
        public List<SelectListItem> SpeciesList { get; set; }
        [Display(Name ="Type of Lure")]
        public LureType LureType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        [Display(Name = "Date")]
        public DateTime CatchDate { get; set; }
        public string Location { get; set; }
        [Display(Name = "Weather Type")]
        public Weather WeatherType { get; set; }
        public double Temperature { get; set; }
    }
}
