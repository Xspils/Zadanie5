using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie7.Models
{
    public class CountryTrip
    {
        [Key]
        [Column(Order = 1)]
        public int CountryId { get; set; }  
        [Key]
        [Column(Order = 2)]
        public int TripId { get; set; }  
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }  

        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set; } 
    }
}
