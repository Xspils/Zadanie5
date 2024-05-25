using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie7.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        [Required]
        [StringLength(100)]
        public string Name { get; set; }  
        [StringLength(3)]
        public string Code { get; set; } 
        [StringLength(100)]
        public string Capital { get; set; }  
        public long? Population { get; set; }  
        public ICollection<Trip> Trips { get; set; }  
        public Country()
        {
            Trips = new HashSet<Trip>();
        }
    }
}
