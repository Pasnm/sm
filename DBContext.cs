using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


           /* if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=SMDB; User ID=pasan; password=chess3252; TrustServerCertificate=True;");
            }*/
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Students>()
                .HasKey(s => s.SId);

            modelBuilder.Entity<Lecturer>()
                .HasKey(l => l.LId);

            modelBuilder.Entity<Class>()
                .HasKey(c => c.CId);
            
            //modelBuilder.Entity<Enrollment>()
                //.HasKey(e => new { e.SId, e.CId });

           /* modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SId);*/

            /*modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CId);*/



            /*modelBuilder.Entity<Lecturer>()
                .HasOne(l => l.Class)
                .WithMany(c => c.Lecturer)
                .HasForeignKey(l => l.CId);*/


            /*modelBuilder.Entity<Class>()
            .HasOne(c => c.Lecturer)
            .WithMany(l => l.Class)
            .HasForeignKey(c => c.LecturerId)
            .OnDelete(DeleteBehavior.Restrict);*/
            
            
            modelBuilder.Entity<Class>().HasData(
            new Class
            {
                CId = 1,
                ClassName = "Mathematics"
                
            },
            new Class
            {
                CId = 2,
                ClassName = "Physics"
            },
            new Class
             {
                 CId = 3,
                 ClassName = "Chemistry"
             }
            );

            _ = modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    SId = 1000,
                    CId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Email = "johndoe@example.com",
                    
                },
                new Students
                {
                    SId = 1001,
                    CId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(2002, 2, 2),
                    Email = "janedoe@example.com",
                    
                },
                new Students
                {
                    SId = 1003,
                    CId = 3,
                    FirstName = "Charlie",
                    LastName = "Brown",
                    DateOfBirth = new DateTime(2002, 3, 3),
                    Email = "charlie.brown@example.com"
                },
                new Students
                {
                    SId = 1004,
                    CId = 1,
                    FirstName = "David",
                    LastName = "Davis",
                    DateOfBirth = new DateTime(2003, 4, 4),
                    Email = "david.davis@example.com"
                },
                new Students
                {
                    SId = 1005,
                    CId = 2,
                    FirstName = "Emily",
                    LastName = "Moore",
                    DateOfBirth = new DateTime(2004, 5, 5),
                    Email = "emily.moore@example.com"
                },
                new Students
                {
                    SId = 1006,
                    CId = 3,
                    FirstName = "Frank",
                    LastName = "Adams",
                    DateOfBirth = new DateTime(2005, 6, 6),
                    Email = "frank.adams@example.com"
                },
                new Students
                {
                    SId = 1007,
                    CId = 1,
                    FirstName = "Grace",
                    LastName = "Wright",
                    DateOfBirth = new DateTime(2006, 7, 7),
                    Email = "grace.wright@example.com"
                },
                new Students
                {
                    SId = 1008,
                    CId = 2,
                    FirstName = "Henry",
                    LastName = "Scott",
                    DateOfBirth = new DateTime(2007, 8, 8),
                    Email = "henry.scott@example.com"
                },
                new Students
                {
                    SId = 1009,
                    CId = 3,
                    FirstName = "Isabella",
                    LastName = "Taylor",
                    DateOfBirth = new DateTime(2008, 9, 9),
                    Email = "isabella.taylor@example.com"
                }
                );

            modelBuilder.Entity<Lecturer>().HasData(
                new List<Lecturer>
                {
                    new Lecturer
                    {
                        LId = 11,
                        CId = 1,
                        Name = "John Doe",
                        Email = "john.doe@example.com"
                    },
                    new Lecturer
                    {
                        LId = 12,
                        CId = 2,
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com"
                    },
                    new Lecturer
                    {
                        LId = 13,
                        CId = 3,
                        Name = "Bob Johnson",
                        Email = "bob.johnson@example.com"
                    }
                });


        }


        //public DbSet<StudentManagement.Models.Enrollment>? Enrollment { get; set; }



    }
}
