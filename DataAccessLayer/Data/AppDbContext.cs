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
                new ComplaintType { Id = "1", Name = "Networking" },
                new ComplaintType { Id = "2", Name = "Software Development" },
                new ComplaintType { Id = "3", Name = "Database Administration" },
                new ComplaintType { Id = "4", Name = "Cybersecurity" },
                new ComplaintType { Id = "5", Name = "Hardware Repairs" },
                new ComplaintType { Id = "6", Name = "Technical Support" },
                new ComplaintType { Id = "7", Name = "Networking" },
                new ComplaintType { Id = "8", Name = "Software Development" },
                new ComplaintType { Id = "9", Name = "System Analysis" },
                new ComplaintType { Id = "10",Name = "IT Consulting" }
            );

            builder.Entity<Staff>()
            .Property(s => s.ComplaintLimit)
            .HasDefaultValue(5);
        }
    }
