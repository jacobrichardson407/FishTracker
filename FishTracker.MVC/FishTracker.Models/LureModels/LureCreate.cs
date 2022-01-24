using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Lure
{
    public class LureCreate
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [Display(Name="Lure Type")]
        public LureType TypeOfLure { get; set; }
    }
}
