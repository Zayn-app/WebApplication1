using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(ur => new
            {
                ur.UserId, ur.RoleId
            });


            modelBuilder.Entity<UserRole>().HasOne(u => u.User).WithMany(ur => ur.UserRoles).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserRole>().HasOne(r => r.Role).WithMany(r => r.UserRoles).HasForeignKey(r => r.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket>Tickets { get; set; }
        public DbSet<Event>Events { get; set; }
        public DbSet<Role> Roles { get; set; }



    

  }
}
