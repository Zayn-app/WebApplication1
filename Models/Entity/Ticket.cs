
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
namespace WebApplication1.Models.Entity
{
    public class Ticket
    {
        [Key]
        public int TicketId{ get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string TicketNumber { get; set; }

        
       // public int UserId { get; set; }
       //user
        [ForeignKey("UserId")]
        public User User { get; set; }

        //event
        [ForeignKey(" EventId")]
        public Event Event { get; set; }
       



    }
}
