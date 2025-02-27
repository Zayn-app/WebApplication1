
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace WebApplication1.Models.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public DateTime DateCreated { get; set; }


        public List<Ticket> Tickets { get; set; }

        public List<UserRole> UserRoles { get; set; }


    }
}
