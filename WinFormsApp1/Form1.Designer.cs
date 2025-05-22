namespace SteganographyApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageEncode = new TabPage();
            btnSaveEncodedImage = new Button();
            btnEncodeMessage = new Button();
            txtMessage = new TextBox();
            lblMessage = new Label();
            btnSelectImageEncode = new Button();
            lblSelectedImageEncode = new Label();
            pictureBoxEncode = new PictureBox();
            tabPageDecode = new TabPage();
            btnDecodeMessage = new Button();
            txtDecodedMessage = new TextBox();
            lblDecodedMessage = new Label();
            btnSelectImageDecode = new Button();
            lblSelectedImageDecode = new Label();
            pictureBoxDecode = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabPageEncode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEncode).BeginInit();
            tabPageDecode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDecode).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageEncode);
            tabControl1.Controls.Add(tabPageDecode);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1067, 666);
            tabControl1.TabIndex = 0;
            // 
            // tabPageEncode
            // 
            tabPageEncode.Controls.Add(btnSaveEncodedImage);
            tabPageEncode.Controls.Add(btnEncodeMessage);
            tabPageEncode.Controls.Add(txtMessage);
            tabPageEncode.Controls.Add(lblMessage);
            tabPageEncode.Controls.Add(btnSelectImageEncode);
            tabPageEncode.Controls.Add(lblSelectedImageEncode);
            tabPageEncode.Controls.Add(pictureBoxEncode);
            tabPageEncode.Location = new Point(4, 29);
            tabPageEncode.Margin = new Padding(4, 5, 4, 5);
            tabPageEncode.Name = "tabPageEncode";
            tabPageEncode.Padding = new Padding(4, 5, 4, 5);
            tabPageEncode.Size = new Size(1059, 633);
            tabPageEncode.TabIndex = 0;
            tabPageEncode.Text = "Encode Message";
            tabPageEncode.UseVisualStyleBackColor = true;
            // 
            // btnSaveEncodedImage
            // 
            btnSaveEncodedImage.Enabled = false;
            btnSaveEncodedImage.Location = new Point(560, 538);
            btnSaveEncodedImage.Margin = new Padding(4, 5, 4, 5);
            btnSaveEncodedImage.Name = "btnSaveEncodedImage";
            btnSaveEncodedImage.Size = new Size(160, 46);
            btnSaveEncodedImage.TabIndex = 6;
            btnSaveEncodedImage.Text = "Save Encoded Image";
            btnSaveEncodedImage.UseVisualStyleBackColor = true;
            btnSaveEncodedImage.Click += btnSaveEncodedImage_Click;
            // 
            // btnEncodeMessage
            // 
            btnEncodeMessage.Enabled = false;
            btnEncodeMessage.Location = new Point(560, 477);
            btnEncodeMessage.Margin = new Padding(4, 5, 4, 5);
            btnEncodeMessage.Name = "btnEncodeMessage";
            btnEncodeMessage.Size = new Size(160, 46);
            btnEncodeMessage.TabIndex = 5;
            btnEncodeMessage.Text = "Encode Message";
            btnEncodeMessage.UseVisualStyleBackColor = true;
            btnEncodeMessage.Click += btnEncodeMessage_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(560, 215);
            txtMessage.Margin = new Padding(4, 5, 4, 5);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(465, 229);
            txtMessage.TabIndex = 4;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(560, 185);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(141, 20);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Message to encode:";
            // 
            // btnSelectImageEncode
            // 
            btnSelectImageEncode.Location = new Point(27, 538);
            btnSelectImageEncode.Margin = new Padding(4, 5, 4, 5);
            btnSelectImageEncode.Name = "btnSelectImageEncode";
            btnSelectImageEncode.Size = new Size(133, 46);
            btnSelectImageEncode.TabIndex = 2;
            btnSelectImageEncode.Text = "Select Image";
            btnSelectImageEncode.UseVisualStyleBackColor = true;
            btnSelectImageEncode.Click += btnSelectImageEncode_Click;
            // 
            // lblSelectedImageEncode
            // 
            lblSelectedImageEncode.AutoSize = true;
            lblSelectedImageEncode.Location = new Point(27, 31);
            lblSelectedImageEncode.Margin = new Padding(4, 0, 4, 0);
            lblSelectedImageEncode.Name = "lblSelectedImageEncode";
            lblSelectedImageEncode.Size = new Size(134, 20);
            lblSelectedImageEncode.TabIndex = 1;
            lblSelectedImageEncode.Text = "No image selected";
            // 
            // pictureBoxEncode
            // 
            pictureBoxEncode.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEncode.Location = new Point(27, 62);
            pictureBoxEncode.Margin = new Padding(4, 5, 4, 5);
            pictureBoxEncode.Name = "pictureBoxEncode";
            pictureBoxEncode.Size = new Size(506, 460);
            pictureBoxEncode.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEncode.TabIndex = 0;
            pictureBoxEncode.TabStop = false;
            // 
            // tabPageDecode
            // 
            tabPageDecode.Controls.Add(btnDecodeMessage);
            tabPageDecode.Controls.Add(txtDecodedMessage);
            tabPageDecode.Controls.Add(lblDecodedMessage);
            tabPageDecode.Controls.Add(btnSelectImageDecode);
            tabPageDecode.Controls.Add(lblSelectedImageDecode);
            tabPageDecode.Controls.Add(pictureBoxDecode);
            tabPageDecode.Location = new Point(4, 29);
            tabPageDecode.Margin = new Padding(4, 5, 4, 5);
            tabPageDecode.Name = "tabPageDecode";
            tabPageDecode.Padding = new Padding(4, 5, 4, 5);
            tabPageDecode.Size = new Size(1059, 625);
            tabPageDecode.TabIndex = 1;
            tabPageDecode.Text = "Decode Message";
            tabPageDecode.UseVisualStyleBackColor = true;
            // 
            // btnDecodeMessage
            // 
            btnDecodeMessage.Enabled = false;
            btnDecodeMessage.Location = new Point(560, 538);
            btnDecodeMessage.Margin = new Padding(4, 5, 4, 5);
            btnDecodeMessage.Name = "btnDecodeMessage";
            btnDecodeMessage.Size = new Size(160, 46);
            btnDecodeMessage.TabIndex = 5;
            btnDecodeMessage.Text = "Decode Message";
            btnDecodeMessage.UseVisualStyleBackColor = true;
            btnDecodeMessage.Click += btnDecodeMessage_Click;
            // 
            // txtDecodedMessage
            // 
            txtDecodedMessage.Location = new Point(560, 215);
            txtDecodedMessage.Margin = new Padding(4, 5, 4, 5);
            txtDecodedMessage.Multiline = true;
            txtDecodedMessage.Name = "txtDecodedMessage";
            txtDecodedMessage.ReadOnly = true;
            txtDecodedMessage.ScrollBars = ScrollBars.Vertical;
            txtDecodedMessage.Size = new Size(465, 306);
            txtDecodedMessage.TabIndex = 4;
            // 
            // lblDecodedMessage
            // 
            lblDecodedMessage.AutoSize = true;
            lblDecodedMessage.Location = new Point(560, 185);
            lblDecodedMessage.Margin = new Padding(4, 0, 4, 0);
            lblDecodedMessage.Name = "lblDecodedMessage";
            lblDecodedMessage.Size = new Size(135, 20);
            lblDecodedMessage.TabIndex = 3;
            lblDecodedMessage.Text = "Decoded message:";
            // 
            // btnSelectImageDecode
            // 
            btnSelectImageDecode.Location = new Point(27, 538);
            btnSelectImageDecode.Margin = new Padding(4, 5, 4, 5);
            btnSelectImageDecode.Name = "btnSelectImageDecode";
            btnSelectImageDecode.Size = new Size(133, 46);
            btnSelectImageDecode.TabIndex = 2;
            btnSelectImageDecode.Text = "Select Image";
            btnSelectImageDecode.UseVisualStyleBackColor = true;
            btnSelectImageDecode.Click += btnSelectImageDecode_Click;
            // 
            // lblSelectedImageDecode
            // 
            lblSelectedImageDecode.AutoSize = true;
            lblSelectedImageDecode.Location = new Point(27, 31);
            lblSelectedImageDecode.Margin = new Padding(4, 0, 4, 0);
            lblSelectedImageDecode.Name = "lblSelectedImageDecode";
            lblSelectedImageDecode.Size = new Size(134, 20);
            lblSelectedImageDecode.TabIndex = 1;
            lblSelectedImageDecode.Text = "No image selected";
            // 
            // pictureBoxDecode
            // 
            pictureBoxDecode.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDecode.Location = new Point(27, 62);
            pictureBoxDecode.Margin = new Padding(4, 5, 4, 5);
            pictureBoxDecode.Name = "pictureBoxDecode";
            pictureBoxDecode.Size = new Size(506, 460);
            pictureBoxDecode.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxDecode.TabIndex = 0;
            pictureBoxDecode.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 666);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 19, 0);
            statusStrip1.Size = new Size(1067, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(50, 20);
            toolStripStatusLabel.Text = "Ready";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select an image file";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "PNG Files|*.png|Bitmap Files|*.bmp";
            saveFileDialog.Title = "Save encoded image";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 692);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Steganography Tool - Hide and Extract Text in Images";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageEncode.ResumeLayout(false);
            tabPageEncode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEncode).EndInit();
            tabPageDecode.ResumeLayout(false);
            tabPageDecode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDecode).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEncode;
        private System.Windows.Forms.TabPage tabPageDecode;
        private System.Windows.Forms.PictureBox pictureBoxEncode;
        private System.Windows.Forms.Label lblSelectedImageEncode;
        private System.Windows.Forms.Button btnSelectImageEncode;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnEncodeMessage;
        private System.Windows.Forms.Button btnSaveEncodedImage;
        private System.Windows.Forms.PictureBox pictureBoxDecode;
        private System.Windows.Forms.Label lblSelectedImageDecode;
        private System.Windows.Forms.Button btnSelectImageDecode;
        private System.Windows.Forms.TextBox txtDecodedMessage;
        private System.Windows.Forms.Label lblDecodedMessage;
        private System.Windows.Forms.Button btnDecodeMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}