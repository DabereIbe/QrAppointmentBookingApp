using System.Security.Claims;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Staff")] // Only allow staff members
    public class StaffController : Controller
    {
        private readonly IComplaintService _complaintService;
        private readonly IStaffService _staffService;

        public StaffController(IComplaintService complaintService, IStaffService staffService)
        {
            _complaintService = complaintService;
            _staffService = staffService;
        }

        //  View Unassigned Complaints
        public async Task<IActionResult> Assignments()
        {
            var complaints = await _complaintService.GetUnassignedComplaintsAsync();
            return View(complaints);
        }

        //  Assign Complaint
        [HttpPost]
        public async Task<IActionResult> AssignComplaint(int complaintId)
        {
            var staffId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _complaintService.AssignComplaintAsync(complaintId, staffId, DateTime.Now.AddHours(2));
            return RedirectToAction("Assignments");
        }
    }
}
