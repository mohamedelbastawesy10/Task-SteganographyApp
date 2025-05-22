using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SteganographyApp
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap encodedImage;
        private string selectedImagePath;
        private string selectedDecodeImagePath;

        public Form1()
        {
            InitializeComponent();
        }

        // Encode tab events
        private void btnSelectImageEncode_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openFileDialog.FileName;
                    originalImage = new Bitmap(selectedImagePath);
                    pictureBoxEncode.Image = originalImage;
                    lblSelectedImageEncode.Text = Path.GetFileName(selectedImagePath);

                    UpdateEncodeButtonState();
                    UpdateStatusLabel($"Image loaded: {originalImage.Width}x{originalImage.Height} pixels");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            UpdateEncodeButtonState();
        }

        private void btnEncodeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                string message = txtMessage.Text;
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("Please enter a message to encode.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the image can hold the message
                int maxCapacity = (originalImage.Width * originalImage.Height * 3) / 8; // 3 color channels, 8 bits per byte
                if (Encoding.UTF8.GetByteCount(message) + 4 > maxCapacity) // +4 for length prefix
                {
                    MessageBox.Show($"Message is too long for this image. Maximum capacity: {maxCapacity - 4} bytes",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                encodedImage = EncodeMessageInImage(originalImage, message);
                pictureBoxEncode.Image = encodedImage;
                btnSaveEncodedImage.Enabled = true;

                UpdateStatusLabel("Message encoded successfully!");
                MessageBox.Show("Message has been encoded in the image!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encoding message: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveEncodedImage_Click(object sender, EventArgs e)
        {
            if (encodedImage == null) return;

            saveFileDialog.FileName = "encoded_image";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Save as PNG to preserve exact pixel values
                    encodedImage.Save(saveFileDialog.FileName, ImageFormat.Png);
                    UpdateStatusLabel($"Encoded image saved: {Path.GetFileName(saveFileDialog.FileName)}");
                    MessageBox.Show("Encoded image saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Decode tab events
        private void btnSelectImageDecode_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedDecodeImagePath = openFileDialog.FileName;
                    Bitmap decodeImage = new Bitmap(selectedDecodeImagePath);
                    pictureBoxDecode.Image = decodeImage;
                    lblSelectedImageDecode.Text = Path.GetFileName(selectedDecodeImagePath);
                    btnDecodeMessage.Enabled = true;

                    UpdateStatusLabel($"Image loaded for decoding: {decodeImage.Width}x{decodeImage.Height} pixels");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDecodeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap imageTodecode = new Bitmap(selectedDecodeImagePath);
                string decodedMessage = DecodeMessageFromImage(imageTodecode);

                if (!string.IsNullOrEmpty(decodedMessage))
                {
                    txtDecodedMessage.Text = decodedMessage;
                    UpdateStatusLabel("Message decoded successfully!");
                    MessageBox.Show("Message has been decoded from the image!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtDecodedMessage.Text = "";
                    MessageBox.Show("No hidden message found in this image.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decoding message: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper methods
        private void UpdateEncodeButtonState()
        {
            btnEncodeMessage.Enabled = originalImage != null && !string.IsNullOrEmpty(txtMessage.Text);
        }

        private void UpdateStatusLabel(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        // Steganography methods
        private Bitmap EncodeMessageInImage(Bitmap image, string message)
        {
            Bitmap encodedBitmap = new Bitmap(image);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            // Convert message length to bytes (4 bytes for int32)
            byte[] lengthBytes = BitConverter.GetBytes(messageBytes.Length);

            // Combine length and message
            byte[] dataToHide = new byte[lengthBytes.Length + messageBytes.Length];
            Array.Copy(lengthBytes, 0, dataToHide, 0, lengthBytes.Length);
            Array.Copy(messageBytes, 0, dataToHide, lengthBytes.Length, messageBytes.Length);

            int dataIndex = 0;
            int bitIndex = 0;

            // Iterate through each pixel
            for (int y = 0; y < encodedBitmap.Height && dataIndex < dataToHide.Length; y++)
            {
                for (int x = 0; x < encodedBitmap.Width && dataIndex < dataToHide.Length; x++)
                {
                    Color pixel = encodedBitmap.GetPixel(x, y);

                    // Process R, G, B channels
                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    // Modify LSB of red channel
                    if (dataIndex < dataToHide.Length)
                    {
                        r = (r & 0xFE) | ((dataToHide[dataIndex] >> bitIndex) & 1);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Modify LSB of green channel
                    if (dataIndex < dataToHide.Length)
                    {
                        g = (g & 0xFE) | ((dataToHide[dataIndex] >> bitIndex) & 1);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Modify LSB of blue channel
                    if (dataIndex < dataToHide.Length)
                    {
                        b = (b & 0xFE) | ((dataToHide[dataIndex] >> bitIndex) & 1);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    encodedBitmap.SetPixel(x, y, Color.FromArgb(pixel.A, r, g, b));
                }
            }

            return encodedBitmap;
        }

        private string DecodeMessageFromImage(Bitmap image)
        {
            // First, extract the message length (first 4 bytes)
            byte[] lengthBytes = new byte[4];
            int dataIndex = 0;
            int bitIndex = 0;

            // Extract message length
            for (int y = 0; y < image.Height && dataIndex < lengthBytes.Length; y++)
            {
                for (int x = 0; x < image.Width && dataIndex < lengthBytes.Length; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // Extract from red channel
                    if (dataIndex < lengthBytes.Length)
                    {
                        lengthBytes[dataIndex] |= (byte)((pixel.R & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Extract from green channel
                    if (dataIndex < lengthBytes.Length)
                    {
                        lengthBytes[dataIndex] |= (byte)((pixel.G & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Extract from blue channel
                    if (dataIndex < lengthBytes.Length)
                    {
                        lengthBytes[dataIndex] |= (byte)((pixel.B & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }
                }
            }

            int messageLength = BitConverter.ToInt32(lengthBytes, 0);

            // Validate message length
            if (messageLength <= 0 || messageLength > 1000000) // Reasonable limit
            {
                return null; // No valid message found
            }

            // Extract the actual message
            byte[] messageBytes = new byte[messageLength];
            dataIndex = 0;
            bitIndex = 0;
            bool lengthBytesProcessed = false;
            int lengthBitCount = 0;

            for (int y = 0; y < image.Height && dataIndex < messageBytes.Length; y++)
            {
                for (int x = 0; x < image.Width && dataIndex < messageBytes.Length; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // Skip the length bytes (first 32 bits)
                    if (!lengthBytesProcessed)
                    {
                        lengthBitCount += 3; // We process 3 bits per pixel (R, G, B)
                        if (lengthBitCount >= 32)
                        {
                            lengthBytesProcessed = true;
                            // Adjust for any extra bits processed
                            int extraBits = lengthBitCount - 32;
                            if (extraBits > 0)
                            {
                                // Handle the remaining bits from this pixel
                                Color channels = pixel;
                                if (extraBits >= 1) // Blue channel bit
                                {
                                    messageBytes[dataIndex] |= (byte)((channels.B & 1) << bitIndex);
                                    bitIndex++;
                                    if (bitIndex == 8)
                                    {
                                        bitIndex = 0;
                                        dataIndex++;
                                    }
                                }
                            }
                        }
                        continue;
                    }

                    // Extract message bits
                    // Extract from red channel
                    if (dataIndex < messageBytes.Length)
                    {
                        messageBytes[dataIndex] |= (byte)((pixel.R & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Extract from green channel
                    if (dataIndex < messageBytes.Length)
                    {
                        messageBytes[dataIndex] |= (byte)((pixel.G & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }

                    // Extract from blue channel
                    if (dataIndex < messageBytes.Length)
                    {
                        messageBytes[dataIndex] |= (byte)((pixel.B & 1) << bitIndex);
                        bitIndex++;
                        if (bitIndex == 8)
                        {
                            bitIndex = 0;
                            dataIndex++;
                        }
                    }
                }
            }

            try
            {
                return Encoding.UTF8.GetString(messageBytes);
            }
            catch
            {
                return null; // Invalid UTF-8 sequence
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}