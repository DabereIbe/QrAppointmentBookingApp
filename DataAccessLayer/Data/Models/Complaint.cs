using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class Complaint
{
    // public int Id { get; set; }
    // public string StudentId { get; set; }
    // public string Type { get; set; }
    // public string Description { get; set; }
    // public DateTime CreatedAt { get; set; } = DateTime.Now;
    // public int? StaffId { get; set; } // Assigned Staff
    // public string AssignedStaffId { get; set; }
    // public DateTime AssignedTimeFrame { get; set; }
    // public bool IsResolved { get; set; }

    // // Navigation Property
    // public virtual User Student { get; set; }
    //[Key]
    public int Id { get; set; }
    public string StudentId { get; set; } = string.Empty; // Foreign key for Student

    // [ForeignKey("StudentId")]
    public User Student { get; set; } // Navigation property

    public string AssignedStaffId { get; set; } // Foreign key for assigned Staff

    //[ForeignKey("AssignedStaffId")]
    public Staff AssignedStaff { get; set; } // Navigation property

    public string Type { get; set; } = string.Empty;

    //[ForeignKey("ComplaintTypeId")]
    //public ComplaintType ComplaintType { get; set; }
    
    
    public string Description { get; set; } = string.Empty;
    
    public DateTime AssignedTimeFrame { get; set; } // Appointment Timeframe
    public DateTime LoggedAt { get; set; } = DateTime.Now;

    
}
