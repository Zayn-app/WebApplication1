using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entity
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal TicketPrice { get; set; }

        public int TotalTickets { get; set; }

        public int AvaliableTickets { get; set; }

        public string ImagePath { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
