﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishTracker.Data.Lure;

namespace FishTracker.Models.Lure
{
    public class LureListItem
    {
        [Key]
        public int LureId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public LureType TypeOfLure { get; set; }
    }
}
