using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.FishSpecies;

namespace FishTracker.Models.Species
{
    public class SpeciesDetail
    {
        [Key]
        public int SpeciesId { get; set; }
        [Display(Name = "Species")]
        public string SpeciesName { get; set; }
        [Display(Name = "Average Length")]
        public double AverageLength { get; set; }
        [Display(Name = "Average Weight")]
        public double AverageWeight { get; set; }
        public string Description { get; set; }
        [Display(Name = "Preferred Lures")]
        public string PreferredLures { get; set; }
    }
}
