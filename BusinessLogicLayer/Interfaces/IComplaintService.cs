using System;
using DataAccessLayer.Data.Models;

namespace BusinessLogicLayer.Interfaces;

public interface IComplaintService
    {
        Task<Complaint> LogComplaintAsync(string studentId, string type, string description);
        Task<bool> CompleteComplaintAsync(int complaintId);
        Task<List<Complaint>> GetComplaintsByStudentAsync(string studentId);
        Task<List<Complaint>> GetUnassignedComplaintsAsync();
        Task<bool> AssignComplaintAsync(int complaintId, string staffId, DateTime assignedTimeFrame);
        Task<Complaint> GetComplaintByIdAsync(int complaintId);
        Task<ComplaintType> GetComplaintTypeByIdAsync(string complaintTypeId);
    }
