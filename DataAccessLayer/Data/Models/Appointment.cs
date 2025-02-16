using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class Appointment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StaffId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsCompleted { get; set; }
    }
