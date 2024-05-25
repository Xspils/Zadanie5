using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie7.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        public DateTime StartDate { get; set; } 
        [Required]
        public DateTime EndDate { get; set; } 
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } 
        public ICollection<CountryTrip> CountryTrips { get; set; } 
        public ICollection<ClientTrip> ClientTrips { get; set; } 
        public Trip()
        {
            CountryTrips = new HashSet<CountryTrip>();
            ClientTrips = new HashSet<ClientTrip>();
        }
    }
}
