using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace GarticBot
{
    public static class Utils
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr value);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        /// <summary>
        /// Simulates mouse click on current position
        /// </summary>
        public static void Mouse_Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// Moves mouse cursor to set point
        /// </summary>
        /// <param name="point">New mouse position</param>
        public static void SetMousePos(Point point)
        {
            Console.WriteLine(point.ToString());
            SetCursorPos(point.X, point.Y);
        }

        /// <summary>
        /// Convert speed option to ms value
        /// </summary>
        /// <param name="speed">Speed level</param>
        /// <returns>Time to sleep</returns>
        public static int ConvertSpeed(int speed)
        {
            if (speed == 1)
                return 100;
            if (speed == 2)
                return 30;
            if (speed == 3)
                return 6;
            return 2;
        }

        /// <summary>
        /// Simulates keyboard input
        /// </summary>
        /// <param name="text">Text to write</param>
        public static void Type(string text)
        {
            SendKeys.SendWait(text);
        }

        /// <summary>
        /// Convert Bitmap to BitmapSource
        /// </summary>
        /// <param name="bmp">Bitmap to convert</param>
        /// <returns>Converted BitmapSource</returns>
        public static BitmapSource BitmapToBitmapSource(Bitmap bmp)
        {
            var hBitmap = bmp.GetHbitmap();
            var imageSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return imageSource;
        }

        /// <summary>
        /// Convert BitmapSource to Bitmap
        /// </summary>
        /// <param name="source">BitmapSource to convert</param>
        /// <returns>Converted Bitmap</returns>
        public static Bitmap BitmapFromSource(BitmapSource source)
        {
            if (source == null)
                return null;

            var pixelFormat = PixelFormat.Format32bppArgb;
            if (source.Format == PixelFormats.Bgr24)
                pixelFormat = PixelFormat.Format24bppRgb;
            else if (source.Format == PixelFormats.Pbgra32)
                pixelFormat = PixelFormat.Format32bppPArgb;
            else if (source.Format == PixelFormats.Prgba64)
                pixelFormat = PixelFormat.Format64bppPArgb;

            Bitmap bmp = new Bitmap(
                source.PixelWidth,
                source.PixelHeight,
                pixelFormat);

            BitmapData data = bmp.LockBits(
                new Rectangle(Point.Empty, bmp.Size),
                ImageLockMode.WriteOnly,
                pixelFormat);

            source.CopyPixels(
                Int32Rect.Empty,
                data.Scan0,
                data.Height * data.Stride,
                data.Stride);

            bmp.UnlockBits(data);

            return bmp;
        }

        /// <summary>
        /// Adjust contrast for Bitmap image
        /// </summary>
        /// <param name="Image">Image to change</param>
        /// <param name="Value">Contrast delta percentage</param>
        /// <returns>New image with changed contrast</returns>
        public static Bitmap AdjustContrast(Bitmap Image, double Value)
        {
            BitmapData sourceData = Image.LockBits(new Rectangle(0, 0,
                                Image.Width, Image.Height),
                                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] grayscaleBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            pixelBuffer.CopyTo(grayscaleBuffer, 0);
            Image.UnlockBits(sourceData);


            int[] workers = new int[1] { pixelBuffer.Length / 4 };
            float[] contrastArg = new float[1] { (float)Math.Pow((100.0 + Value) / 100.0, 2) };
            OpenCLTemplate.CLCalc.Program.Variable pixelsIn = new OpenCLTemplate.CLCalc.Program.Variable(pixelBuffer);
            OpenCLTemplate.CLCalc.Program.Variable pixelsOut = new OpenCLTemplate.CLCalc.Program.Variable(grayscaleBuffer);
            OpenCLTemplate.CLCalc.Program.Variable param = new OpenCLTemplate.CLCalc.Program.Variable(contrastArg);
            OpenCLTemplate.CLCalc.Program.Variable[] args = new OpenCLTemplate.CLCalc.Program.Variable[] { pixelsIn, param, pixelsOut };

            ContrastKernel.Execute(args, workers);
            pixelsOut.ReadFromDeviceTo(grayscaleBuffer);

            Bitmap resultBitmap = new Bitmap(Image.Width, Image.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(grayscaleBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;

            /*BitmapData sourceData = Image.LockBits(new Rectangle(0, 0,
                                Image.Width, Image.Height),
                                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Image.UnlockBits(sourceData);
            double contrastLevel = Math.Pow((100.0 + Value) / 100.0, 2);
            double blue = 0;
            double green = 0;
            double red = 0;
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;
                green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;
                red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;
                if (blue > 255)
                { blue = 255; }
                else if (blue < 0)
                { blue = 0; }
                if (green > 255)
                { green = 255; }
                else if (green < 0)
                { green = 0; }
                if (red > 255)
                { red = 255; }
                else if (red < 0)
                { red = 0; }
                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }


            Bitmap resultBitmap = new Bitmap(Image.Width, Image.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            return resultBitmap;*/
        }

        /// <summary>
        /// Tries to convert string to int, if not possible returns zero
        /// </summary>
        /// <param name="a">Number string</param>
        /// <returns>Converted number or zero</returns>
        public static int TryParse(string a)
        {
            int x = 0;
            int.TryParse(a, out x);
            return x;
        }

        /// <summary>
        /// Creates Point struct from two strings
        /// </summary>
        /// <param name="x">X parameter of the point</param>
        /// <param name="y">Y parameter of the point</param>
        /// <returns>Point struct</returns>
        public static Point GetPointFromStrings(string x, string y)
        {
            int a = 0, b = 0;
            int.TryParse(x, out a);
            int.TryParse(y, out b);

            return new Point(a, b);
        }

        /// <summary>
        /// Converts image to grayscale. Uses OpenCL
        /// </summary>
        /// <param name="Bmp">Bitmap which would be made grayscale</param>
        public static Bitmap ToGrayScale(Bitmap Bmp)
        {
            BitmapData sourceData = Bmp.LockBits(new Rectangle(0, 0,
                                Bmp.Width, Bmp.Height),
                                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] grayscaleBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            pixelBuffer.CopyTo(grayscaleBuffer, 0);
            Bmp.UnlockBits(sourceData);
            

            int[] workers = new int[1] { pixelBuffer.Length / 4 };
            OpenCLTemplate.CLCalc.Program.Variable pixelsIn = new OpenCLTemplate.CLCalc.Program.Variable(pixelBuffer);
            OpenCLTemplate.CLCalc.Program.Variable pixelsOut = new OpenCLTemplate.CLCalc.Program.Variable(grayscaleBuffer);
            OpenCLTemplate.CLCalc.Program.Variable[] args = new OpenCLTemplate.CLCalc.Program.Variable[] { pixelsIn, pixelsOut };

            GrayscaleKernel.Execute(args, workers);
            pixelsOut.ReadFromDeviceTo(grayscaleBuffer);

            Bitmap resultBitmap = new Bitmap(Bmp.Width, Bmp.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(grayscaleBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;

            /*
            // CPU Code
            int rgb;
            Color c;
            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            */
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Resize image with saving aspect ratio
        /// </summary>
        /// <param name="image">Image to resize</param>
        /// <param name="width">Max width</param>
        /// <param name="height">Max height</param>
        /// <returns></returns>
        public static Bitmap ResizeImageAspect(Bitmap image, int width, int height)
        {
            Bitmap thumbnail = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            double ratioX = (double)width / image.Width;
            double ratioY = (double)height / image.Height;
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            int posX = Convert.ToInt32((width - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((height - (image.Height * ratio)) / 2);

            graphic.Clear(System.Drawing.Color.White);
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
            return thumbnail;
        }

        public static KeyValuePair<Dictionary<Color, List<Rectangle>>, int> ExtractLinesToDraw(Bitmap image, bool vertically, int pixelInterval, int x, int y)
        {
            int bound1, bound2;

            if (!vertically)
            {
                bound1 = image.Height;
                bound2 = image.Width;
            }
            else
            {
                bound1 = image.Width;
                bound2 = image.Height;
            }

            Dictionary<Color, List<Rectangle>> lines = new Dictionary<Color, List<Rectangle>>();
            int nbLinesToDraw = 0;
            for (int i = 0; i < bound1; i += pixelInterval)
            {
                Color lineColor = Color.Empty;
                Point lineStart = new Point(),
                      lineEnd = new Point();
                if (i >= bound1) break;

                for (int j = 0; j < bound2; j += pixelInterval)
                {
                    if (j >= bound2) break;

                    Color tmp;
                    Point currentPosition;

                    if (!vertically)
                        tmp = image.GetPixel(j, i);
                    else
                        tmp = image.GetPixel(i, j);

                    if (!vertically) currentPosition = new Point(j + x, i + y);
                    else currentPosition = new Point(i + x, j + y);

                    if (lineColor == Color.Empty)
                    {
                        lineColor = tmp;
                        lineStart = currentPosition;
                    }
                    else if (lineColor != tmp)
                    {
                        if (!lines.ContainsKey(lineColor)) lines.Add(lineColor, new List<Rectangle>());
                        lines[lineColor].Add(new Rectangle(lineStart, new Size(lineEnd)));
                        if (lineColor != Color.Empty) nbLinesToDraw++;
                        lineColor = tmp;
                        lineStart = currentPosition;
                    }
                    lineEnd = currentPosition;
                }
                if (!lines.ContainsKey(lineColor)) lines.Add(lineColor, new List<Rectangle>());
                lines[lineColor].Add(new Rectangle(lineStart, new Size(lineEnd)));
                if (lineColor != Color.Empty) nbLinesToDraw++;
            }
            return new KeyValuePair<Dictionary<Color, List<Rectangle>>, int>(lines, nbLinesToDraw);
        }

        public static Dictionary<Color, List<Rectangle>> ExtractPixelLinesToDraw(Bitmap picture, int pixelInterval, int x, int y)
        {
            var vert = ExtractLinesToDraw(picture, true, pixelInterval, x, y);
            var hori = ExtractLinesToDraw(picture, false, pixelInterval, x, y);
            if (hori.Value <= vert.Value)
                return hori.Key;
            return vert.Key;
        }

        /// <summary>
        /// Get correct KeyCode from KeyEventArgs
        /// </summary>
        /// <param name="button">KeyEventArgs from KeyDown Event</param>
        /// <returns>Keys Enum with correct key</returns>
        public static Keys GetKeycodeFromKey(System.Windows.Input.KeyEventArgs button)
        {
            if (button.SystemKey == Key.F10)
                return Keys.F10;
            else
                return (Keys)KeyInterop.VirtualKeyFromKey(button.Key);
        }

        /// <summary>
        /// Creates binary image for selected color
        /// </summary>
        /// <param name="image"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool[,] GetColorBinaryImage(Bitmap image, Color color)
        {
            bool[,] data = new bool[image.Width, image.Height];
            Color c;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    c = image.GetPixel(x, y);
                    data[x, y] = c == color;
                }
            }
            return data;
        }

        /// <summary>
        /// Convert binary image to rectangles.
        /// <see href="https://stackoverflow.com/a/63602343/16349466">From stackoverflow answer</see>
        /// </summary>
        /// <param name="map">2D bool array for one color</param>
        /// <returns>List of rectangles</returns>
        public static IEnumerable<Rectangle> ReduceMap(bool[,] map)
        {
            int width = map.GetLength(0), height = map.GetLength(1);
            MapElement[,] bin = new MapElement[width, height];

            // Reduce
            // Step 1: Convert to map elements:
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y])
                        bin[x, y] = new MapElement() { X = x, Y = y, Width = 1, Height = 1, Set = true };
                }

            // Step 2: Process the bin map and generate a collection of Rectangles horizontally     
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Only care about this if we are set.
                    if (bin[x, y].Set)
                    {
                        // Scan forward and link this tile with its following tiles
                        int xx = 0;
                        for (int xForward = x + 1; xForward < width; xForward++)
                        {
                            if (!bin[xForward, y].Set)
                                break;

                            // We can link this...
                            bin[xForward, y].Set = false;
                            bin[x, y].Width++;
                            xx++; // Skip over these tiles.
                        }

                        x += xx;
                    }
                }
            }

            // Step 3: Process the bin map veritically and join any blocks that have equivalent blocks below them.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Only care about this if we are set.
                    if (bin[x, y].Set)
                    {
                        // Scan down and link this tile with its following tiles
                        for (int yDown = y + 1; yDown < height; yDown++)
                        {
                            if (!bin[x, yDown].Set || bin[x, yDown].Width != bin[x, y].Width)  // We might be able to link this if it's the same size
                                break;

                            bin[x, yDown].Set = false;
                            bin[x, y].Height++;
                        }
                    }
                }
            }

            // Step 4: Convert map to rectangles
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Only care about this if we are set.
                    if (bin[x, y].Set)
                    {
                        var b = bin[x, y];
                        yield return new Rectangle(b.X, b.Y, b.Width, b.Height);
                    }
                }
            }
        }

        internal struct MapElement
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
            public bool Set;
        }

        public static Dictionary<Color, List<Rectangle>> ExtractRectsToDraw(Bitmap picture, int x, int y)
        {
            List<Color> palette = new List<Color>();

            for (int yz = 0; yz < picture.Height; yz++)
            {
                for (int xz = 0; xz < picture.Width; xz++)
                {
                    Color c = picture.GetPixel(xz, yz);
                    if (!palette.Contains(c)) palette.Add(c);
                }
            }

            

            Dictionary<Color, List<Rectangle>> result = new Dictionary<Color, List<Rectangle>>();
            for (int i = 0; i < palette.Count; ++i)
            {
                Rectangle[] rects = ReduceMap(GetColorBinaryImage(picture, palette[i])).ToArray();
                for (int j = 0; j < rects.Length; ++j)
                {
                    rects[j].X += x;
                    rects[j].Y += y;
                }

                result.Add(palette[i], rects.ToList());
            }
            return result;
        }

        public static OpenCLTemplate.CLCalc.Program.Kernel GrayscaleKernel;
        public static OpenCLTemplate.CLCalc.Program.Kernel ContrastKernel;

        /// <summary>
        /// Prepare OpenCL kernels for work
        /// </summary>
        public static void CompileOpenCLKernels()
        {
            string GrayscaleKernelCode = @"
                __kernel void grayscaleKernel(__global unsigned char * pixelData, __global unsigned char * outputData)
                {
                    int i = get_global_id(0) * 4;
                    unsigned char blue = 0.114 * pixelData[i];
                    unsigned char green = 0.587 * pixelData[i + 1];
                    unsigned char red = 0.299 * pixelData[i + 2];
                    unsigned char gray = red + green + blue;
                    outputData[i] = gray;
                    outputData[i + 1] = gray;
                    outputData[i + 2] = gray;
                }
            ";

            string ContrastKernelCode = @"
                __kernel void contrastKernel(__global unsigned char * pixelData, __global float * contrastLevel, __global unsigned char * outputData)
                {
                    int i = get_global_id(0) * 4;
                    float blue = ((((pixelData[i] / 255.0) - 0.5) * contrastLevel[0]) + 0.5) * 255.0;
                    float green = ((((pixelData[i + 1] / 255.0) - 0.5) * contrastLevel[0]) + 0.5) * 255.0;
                    float red = ((((pixelData[i + 2] / 255.0) - 0.5) * contrastLevel[0]) + 0.5) * 255.0;
                    if (blue > 255) { blue = 255; }
                    else if (blue < 0) { blue = 0; }
                    if (green > 255) { green = 255; }
                    else if (green < 0) { green = 0; }
                    if (red > 255) { red = 255; }
                    else if (red < 0) { red = 0; }
                    outputData[i] = (unsigned char)blue;
                    outputData[i + 1] = (unsigned char)green;
                    outputData[i + 2] = (unsigned char)red;
                }
            ";

            OpenCLTemplate.CLCalc.InitCL();
            OpenCLTemplate.CLCalc.Program.Compile(new string[] { GrayscaleKernelCode, ContrastKernelCode });
            GrayscaleKernel = new OpenCLTemplate.CLCalc.Program.Kernel("grayscaleKernel");
            ContrastKernel = new OpenCLTemplate.CLCalc.Program.Kernel("contrastKernel");
        }


    }
}
