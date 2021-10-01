using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using static GarticBot.Utils;
using Button = System.Windows.Controls.Button;
using Clipboard = System.Windows.Clipboard;
using Color = System.Drawing.Color;

namespace GarticBot
{
    /// <summary>
    /// Interaction logic for CoordinateSettings.xaml
    /// </summary>
    public partial class CoordinateSettings : Window
    {
        Bitmap background;
        int currentSetting = -1;
        Settings settings;
        bool SetStopButton = false;
        bool SetSkipButton = false;
        uint closeThreadKey;
        uint skipColorKey;

        public CoordinateSettings(Settings sets)
        {
            InitializeComponent();
            settings = sets;

            #region Loading values
            closeThreadKey = settings.CloseThreadKeycode;
            skipColorKey = settings.SkipColorKeycode;

            SelectStopButton.Content = ((Keys)closeThreadKey).ToString();
            SelectSkipButton.Content = ((Keys)skipColorKey).ToString();

            openPaletteX.Text = settings.OpenPalette.X.ToString();
            openPaletteY.Text = settings.OpenPalette.Y.ToString();

            emptySpaceX.Text = settings.EmptySpace.X.ToString();
            emptySpaceY.Text = settings.EmptySpace.Y.ToString();

            redX.Text = settings.RedValue.X.ToString();
            redY.Text = settings.RedValue.Y.ToString();

            greenX.Text = settings.GreenValue.X.ToString();
            greenY.Text = settings.GreenValue.Y.ToString();

            blueX.Text = settings.BlueValue.X.ToString();
            blueY.Text = settings.BlueValue.Y.ToString();
            #endregion

            var tmp = new Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight);
            using (Graphics gfx = Graphics.FromImage(tmp))
            {
                using (SolidBrush brush = new(Color.Black)) gfx.FillRectangle(brush, 0, 0, tmp.Width, tmp.Height);
                background = (Bitmap)tmp.Clone();
            }
            DrawMarkers(tmp);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static Bitmap ClipboardImage()
        {
            Bitmap returnImage = null;
            if (Clipboard.ContainsImage())
            {
                returnImage = BitmapFromSource(Clipboard.GetImage());
            }
            return returnImage;
        }

        private void DrawMarkers(Bitmap img)
        {
            using (Graphics gfx = Graphics.FromImage(img))
            {
                #region Open Palette
                using (SolidBrush brush = new(Color.White))
                    gfx.FillEllipse(brush, TryParse(openPaletteX.Text) - 5, TryParse(openPaletteY.Text) - 5, 10, 10);
                #endregion

                #region EmptySpace
                using (SolidBrush brush = new(Color.Black))
                    gfx.FillEllipse(brush, TryParse(emptySpaceX.Text) - 5, TryParse(emptySpaceY.Text) - 5, 10, 10);
                #endregion

                #region Red
                using (SolidBrush brush = new(Color.Red))
                    gfx.FillEllipse(brush, TryParse(redX.Text) - 5, TryParse(redY.Text) - 5, 10, 10);
                #endregion

                #region Green
                using (SolidBrush brush = new(Color.Green))
                    gfx.FillEllipse(brush, TryParse(greenX.Text) - 5, TryParse(greenY.Text) - 5, 10, 10);
                #endregion

                #region Blue
                using (SolidBrush brush = new(Color.Blue))
                    gfx.FillEllipse(brush, TryParse(blueX.Text) - 5, TryParse(blueY.Text) - 5, 10, 10);
                #endregion
            }

            screenImage.Source = BitmapToBitmapSource(img);
        }

        private void PasteImageButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp = ClipboardImage();
            if (tmp != null)
            {
                background = (Bitmap)tmp.Clone();
                DrawMarkers(tmp);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            settings.OpenPalette = GetPointFromStrings(openPaletteX.Text, openPaletteY.Text);
            settings.EmptySpace = GetPointFromStrings(emptySpaceX.Text, emptySpaceY.Text);
            settings.RedValue = GetPointFromStrings(redX.Text, redY.Text);
            settings.GreenValue = GetPointFromStrings(greenX.Text, greenY.Text);
            settings.BlueValue = GetPointFromStrings(blueX.Text, blueY.Text);

            settings.SkipColorKeycode = skipColorKey;
            settings.CloseThreadKeycode = closeThreadKey;

            settings.Save();

            System.Windows.MessageBox.Show("Успешно сохранено!");
        }

        private void SetCoordButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "setOpenPalette":
                    currentSetting = 0;
                    break;
                case "setEmpty":
                    currentSetting = 1;
                    break;
                case "setRed":
                    currentSetting = 2;
                    break;
                case "setGreen":
                    currentSetting = 3;
                    break;
                case "setBlue":
                    currentSetting = 4;
                    break;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        };
        public static System.Windows.Point GetMousePosition()
        {
            var w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);

            return new System.Windows.Point(w32Mouse.X, w32Mouse.Y);
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = screenImage.PointFromScreen(GetMousePosition());
            System.Windows.Point unscaled_p = new System.Windows.Point();

            // image and container dimensions
            double w_i = background.Width;
            double w_c = screenImage.ActualWidth;

            double scaleFactor = w_i / w_c;
            unscaled_p.X = p.X * scaleFactor;
            unscaled_p.Y = p.Y * scaleFactor;

            switch (currentSetting)
            {
                case 0:
                    openPaletteX.Text = ((int)unscaled_p.X).ToString();
                    openPaletteY.Text = ((int)unscaled_p.Y).ToString();
                    break;
                case 1:
                    emptySpaceX.Text = ((int)unscaled_p.X).ToString();
                    emptySpaceY.Text = ((int)unscaled_p.Y).ToString();
                    break;
                case 2:
                    redX.Text = ((int)unscaled_p.X).ToString();
                    redY.Text = ((int)unscaled_p.Y).ToString();
                    break;
                case 3:
                    greenX.Text = ((int)unscaled_p.X).ToString();
                    greenY.Text = ((int)unscaled_p.Y).ToString();
                    break;
                case 4:
                    blueX.Text = ((int)unscaled_p.X).ToString();
                    blueY.Text = ((int)unscaled_p.Y).ToString();
                    break;
            }

            currentSetting = -1;
            DrawMarkers((Bitmap)background.Clone());
        }

        private void SelectStopButton_Click(object sender, RoutedEventArgs e)
        {
            SelectStopButton.Content = "(...)";
            SelectSkipButton.Content = ((Keys)skipColorKey).ToString();

            SetSkipButton = false;
            SetStopButton = true;
        }

        private void SelectSkipButton_Click(object sender, RoutedEventArgs e)
        {
            SelectSkipButton.Content = "(...)";
            SelectStopButton.Content = ((Keys)closeThreadKey).ToString();

            SetStopButton = false;
            SetSkipButton = true;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!SetStopButton && !SetSkipButton) return;

            if (SetStopButton)
                closeThreadKey = (uint)GetKeycodeFromKey(e);

            else if (SetSkipButton)
                skipColorKey = (uint)GetKeycodeFromKey(e);

            SetStopButton = false;
            SetSkipButton = false;
            SelectStopButton.Content = ((Keys)closeThreadKey).ToString();
            SelectSkipButton.Content = ((Keys)skipColorKey).ToString();
        }
    }
}
