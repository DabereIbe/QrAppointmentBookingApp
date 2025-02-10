using System;

namespace BusinessLogicLayer.Interfaces;

public interface IQRCodeService
{
    byte[] GenerateQRCode(string qrText);
}
