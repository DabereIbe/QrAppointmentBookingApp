using System;
using BusinessLogicLayer.Interfaces;
using QRCoder;

namespace BusinessLogicLayer.Services;

public class QRCodeService : IQRCodeService
    {
        public byte[] GenerateQRCode(string qrText)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrData);
                return qrCode.GetGraphic(20);
            }
        }
    }
