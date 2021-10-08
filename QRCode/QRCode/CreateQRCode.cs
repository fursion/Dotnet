using System;
using QRCoder;
using System.Drawing;
namespace QRCode
{
    public static class CreateQRCode
    {
        public static void Create(string text)
        {
            QRCodeGenerator qRCodeGenerator = new();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            Bitmap qrbitmap = qRCode.GetGraphic(20);
        }
    }
}