using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie7.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        [Required]
        [StringLength(11, ErrorMessage = "PESEL must be 11 characters long", MinimumLength = 11)]
        public string PESEL { get; set; }  
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } 
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }  

        [Phone]
        public string Phone { get; set; }  

        public ICollection<Trip> Trips { get; set; }  

        public Client()
        {
            Trips = new HashSet<Trip>();
        }
    }
}
