using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Lure
{
    public class LureEdit
    {
        [Key]
        public int LureId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        [Display(Name = "Lure Type")]
        public LureType TypeOfLure { get; set; }
    }
}
