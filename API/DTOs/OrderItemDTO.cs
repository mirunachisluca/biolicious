﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class OrderItemDTO
    {
        public int ProductItemId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }
}
