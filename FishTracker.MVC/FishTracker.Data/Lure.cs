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
            Sinking = 1,
            Live,
            Floating,
            [Display(Name = "Soft Plastic")]
            SoftPlastic,
            Crankbait,
            Spoon,
            Jig
        }
        [Key]
        public int LureId { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public string LureBrand { get; set; }
        [Required]
        [Display(Name = "Lure Name")]
        public string LureName { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [Display(Name = "Lure Type")]
        public LureType TypeOfLure { get; set; }
        public Guid AnglerId { get; set; }

    }
}
