using System;

namespace BusinessLogicLayer.Interfaces;

public interface IPdfService
{
    byte[] GeneratePdf(string studentName, string matricNumber, string staffName, string complaintType, string complaintDesc, string assignedTimeframe, byte[] qrCode);
}
