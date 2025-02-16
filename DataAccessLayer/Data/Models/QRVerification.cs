using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Data.Models;

public class QRVerification
    {
        public int Id { get; set; }
        public string AppointmentId { get; set; }

        public Appointment Appointment { get; set; }
        
        
        public string QRCodeData { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
