using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int LureId { get; set; }
        public string LureBrand { get; set; }
        public string LureName { get; set; }
        public string Color { get; set; }
        public LureType TypeOfLure { get; set; }
        public Guid AnglerId { get; set; }

    }
}
