using System.Drawing;

using System;
using System.Drawing;

namespace ChatBot
{
     class ImageDisplay
    {
        public void Show()
        {
            string imagePath = "C:\\Users\\lab_services_student\\Desktop\\Screenshot 2025-04-14 175844.png"; // Keep your image path
            int width = 80;    // Experiment with this value!  Try 80, 100, 120.
            int height = 40;   // Experiment with this value! Keep aspect ratio in mind.

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConvertImageToAscii(imagePath, width, height);
        }

        private void ConvertImageToAscii(string imagePath, int newWidth, int newHeight)
        {
            try
            {
                Bitmap image = new Bitmap(imagePath);
                // Resize the image.  You can move this around.
                image = new Bitmap(image, new Size(newWidth, newHeight));

                // ASCII characters ordered by brightness
                // string asciiChars = "@%#*+=-:. "; // Original
                // string asciiChars = " .:-=+*#%@"; // More balanced
                string asciiChars = "  ..::++==**##%%@@";  // More contrast
                // string asciiChars = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\|()1{}[]?-_+~<>i!lI;:,\"^'. ";

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; // Convert to grayscale
                        int index = grayValue * (asciiChars.Length - 1) / 255; // Map to ASCII range
                        Console.Write(asciiChars[index]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to ASCII: {ex.Message}");
                Console.WriteLine("Please ensure the image path is correct and the file is accessible.");
            }
        }
    }
}