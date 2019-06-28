using System;
using System.Drawing;
using System.Windows.Forms;
using Atomic.FFmpeg;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using CSASS;

namespace Atomic.UI.Element
{
    public partial class VideoEditorView : UserControl
    {
        private Core core = null;
        private long frame = 0;
        private int framewidth = 1280;
        private int frameheight = 720;
        private bool upscale = true;
        private bool sizeSameAsControl = true;

        private FFmpegAutoGenWrapper ffwrapper = null;

        public VideoEditorView()
        {
            InitializeComponent();

            Paint += VideoEditorView_Paint;
        }

        public Core Core { get => core; set => core = value; }
        public long Frame { get => frame; set => frame = value; }
        public int FrameWidth { get => framewidth; set => framewidth = value; }
        public int FrameHeight { get => frameheight; set => frameheight = value; }
        public bool Upscale { get => upscale; set => upscale = value; }
        public bool SizeSameAsControl { get => sizeSameAsControl; set => sizeSameAsControl = value; }


        private void VideoEditorView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.ClipRectangle);

            if (core != null && core.VideoFile != null)
            {
                try
                {
                    Csass ca = core.CSASS;

                    if (ca.Events.Count == 0)
                    {
                        ca.LoadASS(core.AssFile[0]);
                    }

                    if (ffwrapper == null)
                    {
                        ffwrapper = new FFmpegAutoGenWrapper(core);
                    }

                    ffwrapper.GenerateImageFromFrame(core.VideoFile[0], frame);

                    Bitmap bmp = new Bitmap("temp.png");

                    if (sizeSameAsControl == true | (upscale == true && bmp.Width < Width))
                    {
                        framewidth = Width;
                        frameheight = Height;
                    }

                    e.Graphics.DrawImage(ResizeImage(bmp, framewidth, frameheight), 0, 0);
                }
                catch (Exception)
                {

                }
            }
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
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
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
    }
}
