using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos
{
    public class UpdateProductDetailDto
    {
        public string ProductPreviewID { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductID { get; set; }
    }
}
