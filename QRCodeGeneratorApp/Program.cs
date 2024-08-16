// See https://aka.ms/new-console-template for more information
using QRCoder;
using System.Drawing;

Console.WriteLine("Hello, World!");

Console.Write("Input the URL to convert: ");
string url = Console.ReadLine()!;

if (string.IsNullOrEmpty(url))
    Console.WriteLine("Invalid input.");

var qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

var qrCode = new BitmapByteQRCode(qrCodeData);
var qrCodeImage = qrCode.GetGraphic(pixelsPerModule: 20);

using var ms = new MemoryStream(qrCodeImage);
using var imgFromStream = Image.FromStream(ms);

imgFromStream.Save(filename: "qrcode.png");
Console.WriteLine($"QR Code saved.");