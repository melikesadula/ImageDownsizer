using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DownsizeImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void upload_img_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                Image originalImage = Image.FromFile(selectedImagePath);
                original_img.Image = originalImage;
            }
        }



        private void original_img_Click(object sender, EventArgs e)
        {



        }

        private void downsize_Click(object sender, EventArgs e)
        {
            if (original_img.Image != null)
            {

                if (!float.TryParse(downScallingFactor.Text, out float percentage) || percentage <= 0 || percentage > 100)
                {
                    MessageBox.Show("Please enter a valid downscaling percentage (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Image originalImage = original_img.Image;
                int newWidth = (int)(originalImage.Width * percentage / 100);
                int newHeight = (int)(originalImage.Height * percentage / 100);

                Image downscaledImage = ResizeImage(originalImage, newWidth, newHeight);
                downsized_img.Image = downscaledImage;
                size.Text = originalImage.Width.ToString() + "x" + originalImage.Height.ToString();
                newSize.Text = newWidth.ToString() + "x" + newHeight.ToString();

                stopwatch.Stop();
                MessageBox.Show($"Non-threaded resizing took {stopwatch.ElapsedMilliseconds} ms.", "Time Measurement");
            }

        }



        private void downsized_img_Click(object sender, EventArgs e)
        {

        }



        private Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.Bicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphics.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));
            }

            return resizedImage;
        }
        private byte[,,] ConvertToColor(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            int width = bitmap.Width;
            int height = bitmap.Height;
            byte[,,] colorImage = new byte[width, height, 3];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    colorImage[x, y, 0] = pixel.R;
                    colorImage[x, y, 1] = pixel.G;
                    colorImage[x, y, 2] = pixel.B;
                }
            }

            return colorImage;
        }

        private Image CreateBitmapFrom3DArray(byte[,,] array, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = Color.FromArgb(array[x, y, 0], array[x, y, 1], array[x, y, 2]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }

        private void downsize_parallel_Click(object sender, EventArgs e)
        {

            if (original_img.Image != null)
            {
                if (!float.TryParse(downScallingFactor.Text, out float percentage) || percentage <= 0 || percentage > 100)
                {
                    MessageBox.Show("Please enter a valid downscaling percentage (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Thread resizingThread = new Thread(() =>
                {
                    Image originalImage = original_img.Image;
                    int newWidth = (int)(originalImage.Width * percentage / 100);
                    int newHeight = (int)(originalImage.Height * percentage / 100);

                    Image downscaledImage = ResizeImage(originalImage, newWidth, newHeight);
                    SetImageOnMainThread(downsized_img, downscaledImage);

                    stopwatch.Stop();
                    MessageBox.Show($"Threaded resizing took {stopwatch.ElapsedMilliseconds} ms.", "Time Measurement");

                });
                resizingThread.Start();
            }
            else
            {
                MessageBox.Show("No image to downsize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void SetImageOnMainThread(PictureBox pictureBox, Image image)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() => pictureBox.Image = image));
            }
            else
            {
                pictureBox.Image = image;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (original_img.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Downsized Image";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath);

                    ImageFormat imageFormat = null;

                    if (fileExtension == ".png")
                    {
                        imageFormat = ImageFormat.Png;
                    }
                    else if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                    {
                        imageFormat = ImageFormat.Jpeg;
                    }
                    else if (fileExtension == ".bmp")
                    {
                        imageFormat = ImageFormat.Bmp;
                    }

                    if (imageFormat != null)
                    {
                        downsized_img.Image.Save(filePath, imageFormat);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Unsupported file format. Please select a PNG, JPEG, or Bitmap image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
