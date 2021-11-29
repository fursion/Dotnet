using System;
using System.IO;
using QRCoder;
using System.Drawing;
namespace QRCode
{
    public static class CreateQRCode
    {
        public static Bitmap Create(string text)
        {
            QRCodeGenerator qRCodeGenerator = new();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCoder.BitmapByteQRCode qRCode = new QRCoder.BitmapByteQRCode(qRCodeData);
            byte[] qrbitmap = qRCode.GetGraphic(20);
            Bitmap bitmap;
            using (var ms = new MemoryStream(qrbitmap))
            {
                bitmap = new Bitmap(ms);
            }
            return bitmap;
        }
        public static Bitmap Create(string content, Bitmap log)
        {
            QRCodeGenerator qRCodeGenerator = new();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(20, "#000ff0", "#0ff000");
            return bitmap;
        }
        public static byte[] CreateByteMap(string content)
        {
            if (content == null)
                throw new Exception();
            try
            {
                if (content == null)
                    throw new Exception();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCoder.BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(qRCodeData);
                byte[] bitmap = bitmapByteQRCode.GetGraphic(20);
                return bitmap;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}