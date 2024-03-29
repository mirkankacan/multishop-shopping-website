﻿using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductID{ get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice{ get; set; }

        public string ProductImageURL{ get; set; }
        public string ProductDescription{ get; set; }
        public string CategoryID{ get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

    }
}
