using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTracker.Data
{
    public class Lure
    {
        public enum LureType
        {
            Sinking =1,
            Live,
            Floating,
            SoftPlastic,
            Crankbait,
            Spoon,
            Jig
        }
        public int LureId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public LureType TypeOfLure { get; set; }
    }
}
