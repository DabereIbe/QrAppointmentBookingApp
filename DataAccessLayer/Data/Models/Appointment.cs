using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class Appointment
    {
        // [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StaffId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsCompleted { get; set; }

        // [ForeignKey("StudentId")]
        // public virtual User User { get; set; }

        // [ForeignKey("StaffId")]
        // public virtual Staff Staff { get; set; }
    }
