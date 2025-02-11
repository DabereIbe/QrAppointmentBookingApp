using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class QRVerification
    {
        //[Key]
        public int Id { get; set; }
        public string AppointmentId { get; set; }

        //[ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
        
        
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
