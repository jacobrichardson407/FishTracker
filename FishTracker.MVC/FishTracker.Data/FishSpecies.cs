using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Data
{
    public class FishSpecies
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        [Display(Name = "Species Name")]
        public string SpeciesName { get; set; }
        [Required]
        [Display(Name = "Average Length")]
        public double AverageLength { get; set; }
        [Required]
        [Display(Name = "Average Weight")]
        public double AverageWeight { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Preferred Lures")]
        public string PreferredLures { get; set; }
        public Guid AnglerId { get; set; }

    }
}
