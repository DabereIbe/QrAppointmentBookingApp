using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data.Models;

public class Staff
{
    public string Id { get; set; } = string.Empty;
    public string? FullName { get; set; } = string.Empty;
    public string? Expertise { get; set; } = string.Empty;
    public bool? IsAvailable { get; set; } = true;
    public int? ComplaintLimit { get; set; } = 3; // Maximum complaints before unavailable
    public int? CurrentComplaints { get; set; } = 0; // Track current complaints
}
