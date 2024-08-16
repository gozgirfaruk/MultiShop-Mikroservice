using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos
{
    public class ResultProductImageDto
    {
        public string ProductImageID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductID { get; set; }
    }
}
