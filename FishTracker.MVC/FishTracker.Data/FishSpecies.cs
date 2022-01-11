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
        public enum SpeciesName
        { 
            LargemouthBass = 1, 
            SmallmouthBass, 
            Pike,
            Bluegill, 
            Sunfish,
            Catfish,
            Bowfin,
            Crappie,
            Walleye,
            Carp,
        }
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public SpeciesName Name { get; set; }
        [Required]
        public double AverageLength { get; set; }
        [Required]
        public double AverageWeight { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PreferredLures { get; set; }
    }
}
