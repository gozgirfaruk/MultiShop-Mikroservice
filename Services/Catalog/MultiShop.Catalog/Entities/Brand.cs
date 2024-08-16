﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
    }
}
