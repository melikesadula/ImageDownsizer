namespace DownsizeImage
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            original_img = new PictureBox();
            downsized_img = new PictureBox();
            upload_img = new Button();
            downsize = new Button();
            downsize_parallel = new Button();
            save = new Button();
            downScallingFactor = new TextBox();
            size = new TextBox();
            newSize = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)original_img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)downsized_img).BeginInit();
            SuspendLayout();
            // 
            // original_img
            // 
            original_img.BorderStyle = BorderStyle.Fixed3D;
            original_img.Location = new Point(12, 65);
            original_img.Name = "original_img";
            original_img.Size = new Size(271, 261);
            original_img.SizeMode = PictureBoxSizeMode.Zoom;
            original_img.TabIndex = 0;
            original_img.TabStop = false;
            original_img.Click += original_img_Click;
            // 
            // downsized_img
            // 
            downsized_img.BorderStyle = BorderStyle.Fixed3D;
            downsized_img.Location = new Point(517, 65);
            downsized_img.Name = "downsized_img";
            downsized_img.Size = new Size(271, 261);
            downsized_img.SizeMode = PictureBoxSizeMode.Zoom;
            downsized_img.TabIndex = 1;
            downsized_img.TabStop = false;
            downsized_img.Click += downsized_img_Click;
            // 
            // upload_img
            // 
            upload_img.BackColor = Color.DarkGray;
            upload_img.Location = new Point(12, 380);
            upload_img.Name = "upload_img";
            upload_img.Size = new Size(271, 58);
            upload_img.TabIndex = 2;
            upload_img.Text = "Upload";
            upload_img.UseVisualStyleBackColor = false;
            upload_img.Click += upload_img_Click;
            // 
            // downsize
            // 
            downsize.BackColor = Color.DarkGray;
            downsize.Location = new Point(331, 174);
            downsize.Name = "downsize";
            downsize.Size = new Size(135, 34);
            downsize.TabIndex = 3;
            downsize.Text = "Downsize";
            downsize.UseVisualStyleBackColor = false;
            downsize.Click += downsize_Click;
            // 
            // downsize_parallel
            // 
            downsize_parallel.BackColor = Color.DarkGray;
            downsize_parallel.Location = new Point(331, 283);
            downsize_parallel.Name = "downsize_parallel";
            downsize_parallel.Size = new Size(135, 34);
            downsize_parallel.TabIndex = 4;
            downsize_parallel.Text = "Downsize";
            downsize_parallel.UseVisualStyleBackColor = false;
            downsize_parallel.Click += downsize_parallel_Click;
            // 
            // save
            // 
            save.BackColor = Color.DarkGray;
            save.Location = new Point(517, 380);
            save.Name = "save";
            save.Size = new Size(271, 58);
            save.TabIndex = 5;
            save.Text = "Save";
            save.UseVisualStyleBackColor = false;
            save.Click += save_Click;
            // 
            // downScallingFactor
            // 
            downScallingFactor.Location = new Point(331, 65);
            downScallingFactor.Name = "downScallingFactor";
            downScallingFactor.Size = new Size(135, 26);
            downScallingFactor.TabIndex = 6;
            // 
            // size
            // 
            size.Location = new Point(148, 332);
            size.Name = "size";
            size.Size = new Size(135, 26);
            size.TabIndex = 7;
            // 
            // newSize
            // 
            newSize.Location = new Point(653, 335);
            newSize.Name = "newSize";
            newSize.Size = new Size(135, 26);
            newSize.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 151);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 9;
            label1.Text = "Consequential";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 260);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 10;
            label2.Text = "Parallel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(281, 42);
            label3.Name = "label3";
            label3.Size = new Size(239, 20);
            label3.TabIndex = 11;
            label3.Text = "Enter down-scaling factor(1-100)%";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 338);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 12;
            label4.Text = "Size:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(608, 341);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 13;
            label5.Text = "Size:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newSize);
            Controls.Add(size);
            Controls.Add(downScallingFactor);
            Controls.Add(save);
            Controls.Add(downsize_parallel);
            Controls.Add(downsize);
            Controls.Add(upload_img);
            Controls.Add(downsized_img);
            Controls.Add(original_img);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)original_img).EndInit();
            ((System.ComponentModel.ISupportInitialize)downsized_img).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox original_img;
        private PictureBox downsized_img;
        private Button upload_img;
        private Button downsize;
        private Button downsize_parallel;
        private Button save;
        private TextBox downScallingFactor;
        private TextBox size;
        private TextBox newSize;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
