﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.BrandDtos
{
    public class GetBrandByIdDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
    }
}