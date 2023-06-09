﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Models
{
    public class Furniture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumCategory Category { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }
        public virtual User Owner { get; set; }
    }
}
