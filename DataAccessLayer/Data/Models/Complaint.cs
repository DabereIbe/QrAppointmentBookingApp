using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class Complaint
{
    public int Id { get; set; }
    public string StudentId { get; set; } = string.Empty; // Foreign key for Student

    public User Student { get; set; } // Navigation property

    public string AssignedStaffId { get; set; } // Foreign key for assigned Staff

    public Staff AssignedStaff { get; set; } // Navigation property

    public string Type { get; set; } = string.Empty;
    
    
    public string Description { get; set; } = string.Empty;
    
    public DateTime AssignedTimeFrame { get; set; } // Appointment Timeframe
    public DateTime LoggedAt { get; set; } = DateTime.Now;

    
}
