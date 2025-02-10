using System;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLogicLayer.Interfaces;

public interface IStaffService
    {
        Task<List<Staff>> GetAvailableStaffAsync();
        Task<bool> SetStaffAvailabilityAsync(string staffId, bool isAvailable);
        Task<Staff> GetStaffById(string staffId);
        List<SelectListItem> GetComplaintTypes();
    }
