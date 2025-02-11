using System;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Staff> Staff { get; set; }

        public DbSet<ComplaintType> ComplaintTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

             builder.Entity<ComplaintType>().HasData(
                new ComplaintType { Id = "1", Name = "Network Issue" },
                new ComplaintType { Id = "2", Name = "Portal Login Problem" },
                new ComplaintType { Id = "3", Name = "Course Registration Error" },
                new ComplaintType { Id = "4", Name = "Result Upload Delay" },
                new ComplaintType { Id = "5", Name = "Missing Course on Portal" },
                new ComplaintType { Id = "6", Name = "Email Verification Failure" },
                new ComplaintType { Id = "7", Name = "Tuition Payment Issue" },
                new ComplaintType { Id = "8", Name = "Library Access Problem" },
                new ComplaintType { Id = "9", Name = "Hostel Allocation Issue" },
                new ComplaintType { Id = "10", Name = "ID Card Printing Delay" }
            );

            // builder.Entity<Staff>()
            // .Property(s => s.ComplaintLimit)
            // .HasDefaultValue(5);
        }
    }
