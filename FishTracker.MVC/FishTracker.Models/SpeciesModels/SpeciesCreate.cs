using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.FishSpecies;

namespace FishTracker.Models.Species
{
    public class SpeciesCreate
    {
        public SpeciesName Name { get; set; }
        public double AverageLength { get; set; }
        public double AverageWeight { get; set; }
        public string Description { get; set; }
        public string PreferredLures { get; set; }
    }
}
