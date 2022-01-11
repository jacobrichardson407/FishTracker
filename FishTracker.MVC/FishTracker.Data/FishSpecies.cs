using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Data
{
    public class FishSpecies
    {
        public enum SpeciesName
        { 
            LargemouthBass, 
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
        public int SpeciesId { get; set; }
        public SpeciesName Species { get; set; }
        public double AverageLength { get; set; }
        public double AverageWeight { get; set; }
        public string Description { get; set; }
        public string PreferredLures { get; set; }
    }
}
