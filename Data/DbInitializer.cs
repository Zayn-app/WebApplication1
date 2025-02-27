using Microsoft.AspNetCore.SignalR;
using WebApplication1.Models.Entity;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.EnsureCreated();

                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                         new Event()
                        {
                            EventName = "Music Concert",
                            Description = "An exciting music concert featuring top artists.",
                            Location = "New York City, NY",
                            Date = new DateTime(2024, 9, 15),
                            TicketPrice = 49.99m,
                            TotalTickets = 1000,
                            AvaliableTickets = 1000,
                            ImagePath = "images/concert.jpg",
                            DateCreated = DateTime.Now
                        },
                        new Event()
                        {
                            EventName = "Tech Conference",
                            Description = "Annual tech conference with keynote speakers and workshops.",
                            Location = "San Francisco, CA",
                            Date = new DateTime(2024, 10, 20),
                            TicketPrice = 199.99m,
                            TotalTickets = 500,
                            AvaliableTickets = 500,
                            ImagePath = "images/tech-conference.jpg",
                            DateCreated = DateTime.Now
                        },
                        new Event()
                        {
                            EventName = "Art Exhibition",
                            Description = "A display of modern art from around the world.",
                            Location = "Paris, France",
                            Date = new DateTime(2024, 11, 5),
                            TicketPrice = 25.00m,
                            TotalTickets = 300,
                            AvaliableTickets = 300,
                            ImagePath = "images/art-exhibition.jpg",
                            DateCreated = DateTime.Now
                        },
                    });
                    context.SaveChanges();
                }

                //Roles
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new List<Role>()
                     {
                          new Role
                        {
                            RoleName = "Admin",
                            UserRoles = new List<UserRole>() // Yeni UserRole ilişkileri eklenebilir
                        },
                          new Role
                        {
                            RoleName = "User",
                            UserRoles = new List<UserRole>()
                        },
                          new Role
                        {
                            RoleName = "Manager",
                            UserRoles = new List<UserRole>()
                        },
                });

                    context.SaveChanges();
                }


                //Tickets
                if (!context.Tickets.Any())
                {
                    // Kullanıcı ID'lerinin mevcut olup olmadığını kontrol edin
                    var existingUser1 = context.Users.Find(1);
                    var existingUser2 = context.Users.Find(2);

                    if (existingUser1 != null && existingUser2 != null)
                    {
                        context.Tickets.AddRange(new List<Ticket>()
        {
            new Ticket()
            {
                EventId = 1, // Buraya mevcut EventId'leri eklemelisiniz
                UserId = 1,  // Buraya mevcut UserId'leri eklemelisiniz
                PurchaseDate = DateTime.Now,
                TicketNumber = "A12345"
            },
            new Ticket()
            {
                EventId = 2,
                UserId = 2,
                PurchaseDate = DateTime.Now,
                TicketNumber = "B67890"

            },
        });
                        context.SaveChanges();
                    }
                    else
                    {
                        // Hangi UserId'lerin mevcut olmadığını bildir
                        if (existingUser1 == null)
                            Console.WriteLine("UserId 1 mevcut değil.");
                        if (existingUser2 == null)
                            Console.WriteLine("UserId 2 mevcut değil.");
                    }
                }

                //Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                       {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        PasswordHash = "hashed_password_here", // Bu, gerçek bir hash edilmiş şifre olmalı
                        Role = "Admin",
                        DateCreated = DateTime.Now
                        //Tickets = new List<Ticket>(),  // Henüz bilet eklenmemiş
                        //UserRoles = new List<UserRole>() // Henüz rol eklenmemiş
                       },
                         new User()
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane.smith@example.com",
                        PasswordHash = "hashed_password_here", // Bu, gerçek bir hash edilmiş şifre olmalı
                        Role = "User",
                        DateCreated = DateTime.Now
                        //Tickets = new List<Ticket>(),  // Henüz bilet eklenmemiş
                        //serRoles = new List<UserRole>() // Henüz rol eklenmemiş
                     },
                  });

                    context.SaveChanges();
                }
                //UserRole
                if (!context.UserRoles.Any())
                {
                    // Kullanıcı ID'lerinin ve Rol ID'lerinin mevcut olup olmadığını kontrol edin
                    var existingUser2 = context.Users.Find(2);
                    var existingUser3 = context.Users.Find(3);
                    var existingRole3 = context.Roles.Find(3);
                    var existingRole8 = context.Roles.Find(8);

                    if (existingUser2 != null && existingUser3 != null && existingRole3 != null && existingRole8 != null)
                    {
                        context.UserRoles.AddRange(new List<UserRole>()
        {
            new UserRole()
            {
                UserId = 2, // Mevcut UserId
                RoleId = 3  // Mevcut RoleId
            },
            new UserRole()
            {
                UserId = 3, // Mevcut UserId
                RoleId = 8  // Mevcut RoleId
            },
        });
                        context.SaveChanges();
                    }
                    else
                    {
                        // Hangi UserId veya RoleId'lerin mevcut olmadığını bildir
                        if (existingUser2 == null)
                            Console.WriteLine("UserId 2 mevcut değil.");
                        if (existingUser3 == null)
                            Console.WriteLine("UserId 3 mevcut değil.");
                        if (existingRole3 == null)
                            Console.WriteLine("RoleId 3 mevcut değil.");
                        if (existingRole8 == null)
                            Console.WriteLine("RoleId 8 mevcut değil.");
                    }
                }


            }
        }


    }
}
