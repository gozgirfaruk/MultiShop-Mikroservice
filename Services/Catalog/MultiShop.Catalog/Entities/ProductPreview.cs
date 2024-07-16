using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductPreview
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductPreviewID { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
