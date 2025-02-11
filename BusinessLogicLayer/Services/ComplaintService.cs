using System;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services;

public class ComplaintService : IComplaintService
{
    private readonly AppDbContext _context;

    public ComplaintService(AppDbContext context)
    {
        _context = context;
    }

    //  Log a new complaint
    public async Task<Complaint> LogComplaintAsync(string studentId, string type, string description)
{
    // Find an available staff member
    var staff = await _context.Staff
        .Where(s => s.Expertise == type && Convert.ToBoolean(s.IsAvailable) && s.CurrentComplaints < s.ComplaintLimit)
        .FirstOrDefaultAsync();

    if (staff == null)
    {
        throw new Exception("No available staff found for this complaint type.");
    }

    var complaint = new Complaint
    {
        StudentId = studentId,
        Type = type,
        Description = description,
        AssignedStaffId = staff.Id,
        AssignedStaff = staff,
        AssignedTimeFrame = DateTime.Now.AddDays(1), // Example: Set an appointment for the next day
        LoggedAt = DateTime.Now
    };

    _context.Complaints.Add(complaint);

    // Update staff workload
    staff.CurrentComplaints++;
    if (staff.CurrentComplaints >= staff.ComplaintLimit)
    {
        staff.IsAvailable = false;
    }

    await _context.SaveChangesAsync();

    return complaint;
}


    public async Task<bool> CompleteComplaintAsync(int complaintId)
    {
        var complaint = await _context.Complaints.Include(c => c.AssignedStaff).FirstOrDefaultAsync(c => c.Id == complaintId);
        if (complaint == null || complaint.AssignedStaff == null)
        {
            return false;
        }

        // 📌 Reduce the complaint count for the assigned staff
        complaint.AssignedStaff.CurrentComplaints--;

        // ✅ If the staff was unavailable and now has slots, mark them available
        if (complaint.AssignedStaff.CurrentComplaints < complaint.AssignedStaff.ComplaintLimit)
        {
            complaint.AssignedStaff.IsAvailable = true;
        }

        _context.Complaints.Remove(complaint); // Remove or mark the complaint as resolved
        await _context.SaveChangesAsync();

        return true;
    }


    //  Get complaints by a specific student
    public async Task<List<Complaint>> GetComplaintsByStudentAsync(string studentId)
    {
        return await _context.Complaints
            .Where(c => c.StudentId == studentId)
            .ToListAsync();
    }

    //  Get complaints that haven't been assigned to staff
    public async Task<List<Complaint>> GetUnassignedComplaintsAsync()
    {
        return await _context.Complaints
            .Where(c => string.IsNullOrEmpty(c.AssignedStaffId.ToString()))
            .ToListAsync();
    }

    //  Assign complaint to an available staff member
    public async Task<bool> AssignComplaintAsync(int complaintId, string staffId, DateTime assignedTimeFrame)
    {
        var complaint = await _context.Complaints.FindAsync(complaintId);
        if (complaint == null) return false;

        complaint.AssignedStaffId = staffId;
        complaint.AssignedTimeFrame = assignedTimeFrame;

        _context.Complaints.Update(complaint);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Complaint> GetComplaintByIdAsync(int complaintId)
    {
        return await _context.Complaints.FindAsync(complaintId);
    }

    public async Task<ComplaintType> GetComplaintTypeByIdAsync(string complaintTypeId)
    {
        var complaintType = _context.ComplaintTypes.Find(complaintTypeId);
        return complaintType;
    }
}
