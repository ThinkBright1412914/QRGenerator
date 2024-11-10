using QRCoder;

Console.WriteLine("Welcome to QR Code Generator");
Console.Write("Input the URL to convert : ");
string url = Console.ReadLine();

if (string.IsNullOrEmpty(url))
{
	Console.WriteLine("Invalid Input");
	return;
}

var qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

var qrCode = new BitmapByteQRCode(qrCodeData);
var qrCodeImage = qrCode.GetGraphic(pixelsPerModule: 20);

var currentDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");

string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
string filePath = Path.Combine(downloadsPath, $"QRCode_{currentDate}.png");

using (var stream = new FileStream(filePath, FileMode.Create))
{
	stream.Write(qrCodeImage, 0, qrCodeImage.Length);
}

Console.WriteLine($"QR Code saved to {filePath}");

