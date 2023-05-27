using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MovieBookingApp.API.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("TicketID")]
        public ObjectId TicketID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string TheatreName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Required]
        public string SeatNumber { get; set; }
    }
}
