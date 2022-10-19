using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILicence.Models
{
    public class APITransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        public string ServiceName { get; set; }
        public string ConsumedServiceID { get; set; }
        public string BearerToken { get; set; }
        public string ServiceInformation { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
