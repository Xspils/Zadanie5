using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie7.Models
{
    public class ClientTrip
    {
        [Key]
        [Column(Order = 1)]
        public int ClientId { get; set; }  
        [Key]
        [Column(Order = 2)]
        public int TripId { get; set; }  
        [ForeignKey("ClientId")]
        public Client Client { get; set; }  
        [ForeignKey("TripId")]
        public Trip Trip { get; set; }  
        public DateTime RegisteredAt { get; set; }  
        public DateTime? PaymentDate { get; set; }  
        public double? Price { get; set; } 
    }
}
