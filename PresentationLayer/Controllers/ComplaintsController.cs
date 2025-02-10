using System.Security.Claims;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;


namespace PresentationLayer.Controllers
{
    [Authorize]
    public class ComplaintsController : Controller
    {
        private readonly IComplaintService _complaintService;
        private readonly IStaffService _staffService;
        private readonly IQRCodeService _qrCodeService;
        private readonly IPdfService _pdfService;
        private readonly UserManager<User> _userManager;

        public ComplaintsController(IComplaintService complaintService, IStaffService staffService, IQRCodeService qrCodeService, IPdfService pdfService, UserManager<User> userManager)
        {
            _complaintService = complaintService;
            _staffService = staffService;
            _qrCodeService = qrCodeService;
            _pdfService = pdfService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard(string matricNumber)
        {
            ViewData["MatricNumber"] = matricNumber;
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var complaints = await _complaintService.GetComplaintsByStudentAsync(studentId);
            return View(complaints);
        }

        [HttpGet]
        public IActionResult LogComplaint(string matricNumber) 
        {
            ViewData["MatricNumber"] = matricNumber;
            ViewBag.ComplaintTypeList = _staffService.GetComplaintTypes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogComplaint(ComplaintsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string? userId = _userManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            try
            {
                var complaint = await _complaintService.LogComplaintAsync(userId, model.ComplaintTypeId, model.Description);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CompleteComplaint(int complaintId)
        {
            var success = await _complaintService.CompleteComplaintAsync(complaintId);
            if (success)
            {
                return Json(new { success = true, message = "Complaint marked as completed!" });
            }
            return Json(new { success = false, message = "Failed to complete complaint." });
        }

        // 🔹 Download PDF Ticket
        [HttpGet]
        public async Task<IActionResult> DownloadTicket(int complaintId)
        {
            var complaintType = await _complaintService.GetComplaintTypeByIdAsync(complaintId.ToString());
            var complaint = await _complaintService.GetComplaintByIdAsync(complaintId);
            if (complaint == null) return NotFound();

            var student = await _userManager.FindByIdAsync(complaint.StudentId);
            string studentName = student.FirstName + " " + student.LastName;

            // Generate QR Code
            string qrText = $"Student: {studentName}, Matric No: {student.MatricNumber}, Complaint: {complaintType.Name}, Timeframe: {complaint.AssignedTimeFrame}";
            byte[] qrCodeImage = _qrCodeService.GenerateQRCode(qrText);

            // Generate PDF
            var assignedStaff = await _staffService.GetStaffById(complaint.AssignedStaffId.ToString());
            string staffName = assignedStaff != null ? assignedStaff.FullName : "Pending";

            byte[] pdfBytes = _pdfService.GeneratePdf(
                studentName, student.MatricNumber, staffName, complaintType.Name,
                complaint.Description, complaint.AssignedTimeFrame.ToString(), qrCodeImage);

            return File(pdfBytes, "application/pdf", $"FUTO_Ticket_{complaintId}.pdf");
        }

    }
}
