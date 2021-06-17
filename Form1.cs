using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using AForge.Imaging.ColorReduction;
using System.Runtime.InteropServices;
using System.Threading;

namespace GarticBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ghk = new KeyHandler(Keys.Escape, this);
            ghk.Register();
        }

        Bitmap currentPicture;
        SelectionScreen sc;
        int x = (Screen.PrimaryScreen.Bounds.Width / 2) - 150, y = (Screen.PrimaryScreen.Bounds.Height / 2) - 100;
        int w = 300, h = 200;
        Settings settings = new Settings(true);
        Color[] palette;
        private KeyHandler ghk;
        #region Drawing functions

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
            int dwExtraInfo);

        public void Mouse_Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public int convertSpeed(int speed)
        {
            if (speed == 1)
                return 100;
            return 2;
        }

        private void HandleHotkey()
        {
            if(runner != null && runner.IsAlive) runner.Abort();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        public void Type(string text)
        {
            SendKeys.SendWait(text);
        }

        public void SetMousePos(Point point)
        {
            Console.WriteLine(point.ToString());
            SetCursorPos(point.X, point.Y);
        }

        public KeyValuePair<Dictionary<Color, List<Rectangle>>, int> extractLinesToDraw(Bitmap image, bool vertically, int pixelInterval) {
            int bound1, bound2;
            
            if (!vertically) {
                bound1 = image.Height;
                bound2 = image.Width;
            } else {
                bound1 = image.Width;
                bound2 = image.Height;
            }

            Dictionary<Color, List<Rectangle>> lines = new Dictionary<Color, List<Rectangle>>();
            int nbLinesToDraw = 0;
            for(int i = 0; i < bound1; i += pixelInterval){
                Color lineColor = Color.Empty;
                Point lineStart = new Point(), 
                      lineEnd   = new Point();
                if (i >= bound1) break;

                for (int j = 0; j < bound2; j += pixelInterval)
                {
                    if (j >= bound2) break;

                    Color tmp;
                    Point currentPosition;

                    if (!vertically) tmp = image.GetPixel(j, i);
                    else tmp = image.GetPixel(i, j);
                   
                    if (!vertically) currentPosition = new Point(j + x, i + y);
                    else currentPosition = new Point(i + x, j + y);

                    if(lineColor == Color.Empty)
                    {
                        lineColor = tmp;
                        lineStart = currentPosition;
                    }
                    else if(lineColor != tmp)
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
                if(lineColor != Color.Empty) nbLinesToDraw++;
            }
            return new KeyValuePair<Dictionary<Color, List<Rectangle>>, int>(lines, nbLinesToDraw);
        }

        public Dictionary<Color, List<Rectangle>> extractPixelLinesToDraw(Bitmap picture, int pixelInterval)
        {
            var vert = extractLinesToDraw(picture, true, pixelInterval);
            var hori = extractLinesToDraw(picture, false, pixelInterval);
            if (hori.Value <= vert.Value)
                return hori.Key;
            return vert.Key;
        }
        
        public void drawLine(Rectangle coordinates, int speed) {
            SetMousePos(coordinates.Location);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            SetMousePos(new Point(coordinates.X + Math.Abs(coordinates.Width - coordinates.X), coordinates.Y + Math.Abs(coordinates.Height - coordinates.Y)));
            if (Math.Abs(coordinates.Width - coordinates.X) > 0 || Math.Abs(coordinates.Height - coordinates.Y) > 0) Thread.Sleep(speed);
            else Thread.Sleep(speed / 2);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void StartDraw(Bitmap image, Settings settings, int gapSize, int speed)
        {
            var pixelLinesToDraw = extractPixelLinesToDraw(image, gapSize);
            uint done = 0;
            foreach (var line in pixelLinesToDraw)
            {
                if(line.Key.GetBrightness() < 0.98 && line.Key != Color.FromArgb(0, 0, 0)) {
                    SelectColor(line.Key, settings);
                    foreach (var j in line.Value)
                    {
                        drawLine(j, convertSpeed(speed));
                    }

                    done++;
                    Invoke((MethodInvoker)delegate ()
                    {
                        workProgressBar.Value = (int)(100.0 * ((float)done / pixelLinesToDraw.Count));
                    });
                }
                if (speed == 1) Thread.Sleep(100);
                else if (speed == 2) Thread.Sleep(50);
                else if (speed == 3) Thread.Sleep(25);
                else if (speed == 4) Thread.Sleep(10);
            }
            if (pixelLinesToDraw.ContainsKey(Color.FromArgb(0, 0, 0))){
                SelectColor(Color.Black, settings);
                foreach (var j in pixelLinesToDraw[Color.FromArgb(0, 0, 0)])
                {
                    drawLine(j, convertSpeed(speed));
                }
                done++;
                Invoke((MethodInvoker)delegate ()
                {
                    workProgressBar.Value = (int)(100.0 * ((float)done / pixelLinesToDraw.Count));
                });
            }
            
        }

        public void SelectColor(Color color, Settings settings)
        {
            SetMousePos(settings.OpenPalette);
            Mouse_Click();
            SetMousePos(settings.RedValue);
            Thread.Sleep(100);
            Mouse_Click();
            Type(color.R.ToString());
            SetMousePos(settings.GreenValue);
            Thread.Sleep(100);
            Mouse_Click();
            Type(color.G.ToString());
            SetMousePos(settings.BlueValue);
            Thread.Sleep(100);
            Mouse_Click();
            Type(color.B.ToString());
            SetMousePos(settings.EmptySpace);
            Thread.Sleep(100);
            Mouse_Click();
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
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

        private Bitmap ResizeImageAspect(Image image, int width, int height)
        {
            Bitmap thumbnail = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            double ratioX = (double)width / (double)image.Width;
            double ratioY = (double)height / (double)image.Height;
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            int posX = Convert.ToInt32((width - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((height - (image.Height * ratio)) / 2);

            graphic.Clear(Color.White);
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            return thumbnail;
        }

        #endregion

        private Bitmap SetupImage(Bitmap img, int desiredWidth, int desiredHeight)
        {
            img = ReplaceTransparency(img, Color.White);

            switch (imageSizeCombobox.SelectedIndex)
            {
                case 0: //Normal
                    if (img.Width > desiredWidth || img.Height > desiredHeight) img = ResizeImageAspect(img, desiredWidth, desiredHeight);
                    break;
                case 1: //Zoom
                    img = ResizeImageAspect(img, desiredWidth, desiredHeight);
                    break;
                case 2: //Stretch
                    img = ResizeImage(img, desiredWidth, desiredHeight);
                    break;
                case 3: //Center
                    if (img.Width > desiredWidth || img.Height > desiredHeight) img = ResizeImageAspect(img, desiredWidth, desiredHeight);
                    Bitmap centered = new Bitmap(desiredWidth, desiredHeight);
                    using (Graphics gfx = Graphics.FromImage(centered))
                    {
                        gfx.FillRectangle(Brushes.White, 0, 0, desiredWidth, desiredHeight);
                        gfx.DrawImage(img, (desiredWidth / 2) - (img.Width / 2), (desiredHeight / 2) - (img.Height / 2));
                    }
                    img = centered;
                    break;
            }

            ColorImageQuantizer ciq = new ColorImageQuantizer(new MedianCutQuantizer());
            Bitmap newImage = ciq.ReduceColors(img, (int)colorCountInput.Value);
            palette = newImage.Palette.Entries;

            return newImage;
        }

        public static Bitmap ReplaceTransparency(Bitmap bitmap, Color background)
        {
            var result = new Bitmap(bitmap.Size.Width, bitmap.Size.Height, PixelFormat.Format24bppRgb);
            var g = Graphics.FromImage(result);

            g.Clear(background);
            g.CompositingMode = CompositingMode.SourceOver;
            g.DrawImage(bitmap, 0, 0);

            return result;
        }

        private void downloadImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrlTextBox.Text);
                currentPicture = new Bitmap(stream);
                Bitmap bitmap; bitmap = SetupImage((Bitmap)currentPicture.Clone(), w, h);
                previewImagebox.Image = bitmap;
                errorLabel.Text = "";
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Ошибка загрузки картинки";
                Console.WriteLine(ex);
            }
        }

        private void speedTrackbar_Scroll(object sender, EventArgs e)
        {
            speedLabel.Text = $"Скорость: ({speedTrackbar.Value})";
        }

        private void gapSizeTrackbar_Scroll(object sender, EventArgs e)
        {
            gapLabel.Text = $"Ширина пропуска: ({gapSizeTrackbar.Value})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageSizeCombobox.SelectedIndex = 0;
            topWindowCheckbox.Checked = settings.OnTop;
            x = settings.DrawingPlace.X;
            y = settings.DrawingPlace.Y;
            w = settings.DrawingPlace.Width;
            h = settings.DrawingPlace.Height;
        }

        private void topWindowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = topWindowCheckbox.Checked;
            settings.OnTop = TopMost;
            settings.Save();
        }

        Thread runner;

        private void startButton_Click(object sender, EventArgs e)
        {
            int gap = gapSizeTrackbar.Value;
            int speed = speedTrackbar.Value;
            Bitmap img = (Bitmap)previewImagebox.Image.Clone();
            runner = new Thread(() =>
            {
                StartDraw(img, settings, gap, speed);
            });
            runner.Start();
        }

        private void colorCountInput_ValueChanged(object sender, EventArgs e)
        {
            if (currentPicture != null)
                previewImagebox.Image = SetupImage((Bitmap)currentPicture.Clone(), w, h);
        }

        private void imageSizeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(currentPicture != null)
                previewImagebox.Image = SetupImage((Bitmap)currentPicture.Clone(), w, h);
        }

        private void coordinatesSetup_Click(object sender, EventArgs e)
        {
            PaletteCoordinatesSettings coordsettings = new PaletteCoordinatesSettings(settings);
            coordsettings.ShowDialog();
        }

        private void frameSelectButton_Click(object sender, EventArgs e)
        {
            if(sc != null)
            {
                x = sc.Location.X;
                y = sc.Location.Y;
                w = sc.Size.Width;
                h = sc.Size.Height;
                sc.Close();
                sc.Dispose();
                sc = null;
                errorLabel.Text = "";
                settings.DrawingPlace = new Rectangle(x, y, w, h);
                settings.Save();
                if (currentPicture != null)
                    previewImagebox.Image = SetupImage((Bitmap)currentPicture.Clone(), w, h);
            }
            else
            {
                sc = new SelectionScreen();
                sc.Location = new Point(x, y);
                sc.Size = new Size(w, h);
                sc.Show();
                errorLabel.Text = "Переместите окно и нажмите кнопку ещё раз.";
            }
        }
    }

    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, 0, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }

    public static class Constants
    {
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }
}
