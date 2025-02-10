using System;
using BusinessLogicLayer.Interfaces;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Org.BouncyCastle.Security;
// using Org.BouncyCastle.Crypto;
// using Org.BouncyCastle.Security;
// using iText.Kernel.Pdf.Canvas.Parser;
//using itext7.bouncy-castle-adapter;

namespace BusinessLogicLayer.Services;

public class PdfService : IPdfService
    {
        public byte[] GeneratePdf(string studentName, string matricNumber, string staffName, string complaintType, string complaintDesc, string assignedTimeframe, byte[] qrCode)
        {
            using (var stream = new MemoryStream())
            {
                using (var pdfWriter = new PdfWriter(stream))
                using (var pdfDocument = new PdfDocument(pdfWriter))
                using (var document = new Document(pdfDocument))
                {
                    document.Add(new Paragraph("FUTO Appointment Ticket").SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)).SetFontSize(18));
                    document.Add(new Paragraph($"Student Name: {studentName}"));
                    document.Add(new Paragraph($"Matric Number: {matricNumber}"));
                    document.Add(new Paragraph($"Assigned Staff: {staffName}"));
                    document.Add(new Paragraph($"Complaint Type: {complaintType}"));
                    document.Add(new Paragraph($"Description: {complaintDesc}"));
                    document.Add(new Paragraph($"Assigned Timeframe: {assignedTimeframe}"));
                    document.Add(new Paragraph($"Date & Time Logged: {DateTime.Now}"));

                    // Add QR Code Image
                    if (qrCode != null)
                    {
                        ImageData imageData = ImageDataFactory.Create(qrCode);
                        Image qrImage = new Image(imageData).SetWidth(150).SetHeight(150);
                        document.Add(qrImage);
                    }

                    document.Close();
                }
                return stream.ToArray();
            }
        }
    }
