using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MovieBookingApp.API.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("MovieID")]
        public string MovieID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string TheatreName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Total_Tickets_Allotted { get; set; }
    }
}
