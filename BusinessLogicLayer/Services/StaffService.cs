using System;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services;

public class StaffService : IStaffService
    {
        private readonly AppDbContext _context;

        public StaffService(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Get a list of all available staff members
        public async Task<List<Staff>> GetAvailableStaffAsync()
        {
            return await _context.Staff.Where(s => Convert.ToBoolean(s.IsAvailable)).ToListAsync();
        }

        // 🔹 Set staff availability status
        public async Task<bool> SetStaffAvailabilityAsync(string staffId, bool isAvailable)
        {
            var staff = await _context.Staff.FindAsync(staffId);
            if (staff == null) return false;

            staff.IsAvailable = isAvailable;
            _context.Staff.Update(staff);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Staff> GetStaffById(string staffId)
        {
            var staff = await _context.Staff.FindAsync(staffId);
            return staff;
        }

        public List<SelectListItem> GetComplaintTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _context.ComplaintTypes.ToList();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            return list;
        }
    }
