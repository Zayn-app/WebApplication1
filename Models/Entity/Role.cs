using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace WebApplication1.Models.Entity

{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName{ get; set; }

        public List<UserRole>UserRoles { get; set; }
    }
}
