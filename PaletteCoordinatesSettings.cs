using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarticBot
{
    public partial class PaletteCoordinatesSettings : Form
    {
        public PaletteCoordinatesSettings(Settings sets)
        {
            InitializeComponent();
            settings = sets;
        }

        public Image ClipboardImage()
        {
            Image returnImage = null;
            if (Clipboard.ContainsImage())
            {
                returnImage = Clipboard.GetImage();
            }
            return returnImage;
        }

        private void pasteImageButton_Click(object sender, EventArgs e)
        {
            var tmp = ClipboardImage();
            if(tmp != null)
            {
                coordsPreviewPictureBox.Image = tmp;
                background = (Bitmap)tmp.Clone();
                using(Graphics graphics = Graphics.FromImage(coordsPreviewPictureBox.Image)) DrawMarkers(graphics);
            }
        }


        private void DrawMarkers(Graphics gfx)
        {
            #region Open Palette
            using (SolidBrush brush = new SolidBrush(Color.White))
                gfx.FillEllipse(brush, (int)(openPaletteX.Value - 5), (int)openPaletteY.Value - 5, 10, 10);
            #endregion

            #region EmptySpace
            using (SolidBrush brush = new SolidBrush(Color.Black))
                gfx.FillEllipse(brush, (int)emptySpaceX.Value - 5, (int)emptySpaceY.Value - 5, 10, 10);
            #endregion

            #region Red
            using (SolidBrush brush = new SolidBrush(Color.Red))
                gfx.FillEllipse(brush, (int)redX.Value - 5, (int)redY.Value - 5, 10, 10);
            #endregion

            #region Green
            using (SolidBrush brush = new SolidBrush(Color.Green))
                gfx.FillEllipse(brush, (int)greenX.Value - 5, (int)greenY.Value - 5, 10, 10);
            #endregion

            #region Blue
            using (SolidBrush brush = new SolidBrush(Color.Blue))
                gfx.FillEllipse(brush, (int)blueX.Value - 5, (int)blueY.Value - 5, 10, 10);
            #endregion
        }

        Bitmap background;
        int currentSetting = -1;
        Settings settings;
        private void PaletteCoordinatesSettings_Load(object sender, EventArgs e)
        {
            var tmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics gfx = Graphics.FromImage(tmp))
            {
                using (SolidBrush brush = new SolidBrush(Color.Black)) gfx.FillRectangle(brush, 0, 0, tmp.Width, tmp.Height);
                background = (Bitmap)tmp.Clone();
                DrawMarkers(gfx);
            }
            
            coordsPreviewPictureBox.Image = tmp;


            openPaletteX.Maximum = tmp.Width;
            emptySpaceX.Maximum  = tmp.Width;
            redX.Maximum         = tmp.Width;
            greenX.Maximum       = tmp.Width;
            blueX.Maximum        = tmp.Width;

            openPaletteY.Maximum = tmp.Height;
            emptySpaceY.Maximum  = tmp.Height;
            redY.Maximum         = tmp.Height;
            greenY.Maximum       = tmp.Height;
            blueY.Maximum        = tmp.Height;

            #region Loading values
            openPaletteX.Value = settings.OpenPalette.X;
            openPaletteY.Value = settings.OpenPalette.Y;

            emptySpaceX.Value = settings.EmptySpace.X;
            emptySpaceY.Value = settings.EmptySpace.Y;

            redX.Value = settings.RedValue.X;
            redY.Value = settings.RedValue.Y;

            greenX.Value = settings.GreenValue.X;
            greenY.Value = settings.GreenValue.Y;

            blueX.Value = settings.BlueValue.X;
            blueY.Value = settings.BlueValue.Y;
            #endregion

        }

        private void coordsChanged(object sender, EventArgs e)
        {
            Bitmap tmp = (Bitmap)background.Clone();

            using (Graphics gfx = Graphics.FromImage(tmp))
            {
                DrawMarkers(gfx);
            }

            coordsPreviewPictureBox.Image = tmp;
        }

        

        private void setCoord_Click(object sender, EventArgs e)
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

        private void coordsPreviewPictureBox_Click(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            Point p = coordsPreviewPictureBox.PointToClient(Cursor.Position);
            Point unscaled_p = new Point();

            // image and container dimensions
            int w_i = coordsPreviewPictureBox.Image.Width;
            int h_i = coordsPreviewPictureBox.Image.Height;
            int w_c = coordsPreviewPictureBox.Width;
            int h_c = coordsPreviewPictureBox.Height;

            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                float filler = Math.Abs(h_c - scaledHeight) / 2;
                unscaled_p.X = (int)(p.X / scaleFactor);
                unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
            }
            else
            {
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
                unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                unscaled_p.Y = (int)(p.Y / scaleFactor);
            }

            switch (currentSetting)
            {
                case 0:
                    openPaletteX.Value = unscaled_p.X;
                    openPaletteY.Value = unscaled_p.Y;
                    break;
                case 1:
                    emptySpaceX.Value = unscaled_p.X;
                    emptySpaceY.Value = unscaled_p.Y;
                    break;
                case 2:
                    redX.Value = unscaled_p.X;
                    redY.Value = unscaled_p.Y;
                    break;
                case 3:
                    greenX.Value = unscaled_p.X;
                    greenY.Value = unscaled_p.Y;
                    break;
                case 4:
                    blueX.Value = unscaled_p.X;
                    blueY.Value = unscaled_p.Y;
                    break;
            }

            currentSetting = -1;
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            settings.OpenPalette = new Point((int)openPaletteX.Value, (int)openPaletteY.Value);
            settings.EmptySpace = new Point((int)emptySpaceX.Value, (int)emptySpaceY.Value);
            settings.RedValue = new Point((int)redX.Value, (int)redY.Value);
            settings.GreenValue = new Point((int)greenX.Value, (int)greenY.Value);
            settings.BlueValue = new Point((int)blueX.Value, (int)blueY.Value);

            settings.Save();
        }
    }
}
