using Avalonia.Media.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO; // Добавлено для MemoryStream
using ZXing;
using ZXing.ImageSharp.Rendering;
using ZXing.QrCode;
using ZXing.QrCode.Internal; // Добавлено для ErrorCorrectionLevel

namespace qrTest
{
    public static class qrTestService
    {
        public static Bitmap Generate(string text, int size = 300)
        {
            var writer = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.QR_CODE,
                Renderer = new ImageSharpRenderer<Rgba32>(),  // Исправленный тип
                Options = new QrCodeEncodingOptions
                {
                    Width = size,
                    Height = size,
                    Margin = 2,
                    ErrorCorrection = ErrorCorrectionLevel.H // Теперь доступно
                }
            };

            var image = writer.Write(text);
            
            using var memoryStream = new MemoryStream(); // Теперь распознаётся
            image.SaveAsPng(memoryStream);
            memoryStream.Position = 0;
            
            return new Bitmap(memoryStream);
        }
    }
}