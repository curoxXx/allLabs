namespace Grafik4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxTransformed = new System.Windows.Forms.PictureBox();
            this.pictureBoxRestored = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnAffineTransform = new System.Windows.Forms.Button();
            this.btnNonLinearTransform = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.lblAngle = new System.Windows.Forms.Label();
            this.btnInverseTransform = new System.Windows.Forms.Button();
            this.pictureBoxNonLinearTransform = new System.Windows.Forms.PictureBox();
            this.btnSaveNonLinearImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestored)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNonLinearTransform)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(31, 24);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(214, 156);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxTransformed
            // 
            this.pictureBoxTransformed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxTransformed.Location = new System.Drawing.Point(285, 24);
            this.pictureBoxTransformed.Name = "pictureBoxTransformed";
            this.pictureBoxTransformed.Size = new System.Drawing.Size(230, 156);
            this.pictureBoxTransformed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTransformed.TabIndex = 1;
            this.pictureBoxTransformed.TabStop = false;
            // 
            // pictureBoxRestored
            // 
            this.pictureBoxRestored.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxRestored.Location = new System.Drawing.Point(854, 24);
            this.pictureBoxRestored.Name = "pictureBoxRestored";
            this.pictureBoxRestored.Size = new System.Drawing.Size(230, 156);
            this.pictureBoxRestored.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRestored.TabIndex = 2;
            this.pictureBoxRestored.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(31, 206);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(214, 23);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnAffineTransform
            // 
            this.btnAffineTransform.Location = new System.Drawing.Point(285, 206);
            this.btnAffineTransform.Name = "btnAffineTransform";
            this.btnAffineTransform.Size = new System.Drawing.Size(230, 23);
            this.btnAffineTransform.TabIndex = 4;
            this.btnAffineTransform.Text = "Афинное преобр.";
            this.btnAffineTransform.UseVisualStyleBackColor = true;
            this.btnAffineTransform.Click += new System.EventHandler(this.btnAffineTransform_Click);
            // 
            // btnNonLinearTransform
            // 
            this.btnNonLinearTransform.Location = new System.Drawing.Point(560, 206);
            this.btnNonLinearTransform.Name = "btnNonLinearTransform";
            this.btnNonLinearTransform.Size = new System.Drawing.Size(230, 23);
            this.btnNonLinearTransform.TabIndex = 5;
            this.btnNonLinearTransform.Text = "Нелинейное преобр.";
            this.btnNonLinearTransform.UseVisualStyleBackColor = true;
            this.btnNonLinearTransform.Click += new System.EventHandler(this.btnNonLinearTransform_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(285, 244);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(230, 23);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.Text = "Сохранить изображение";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(390, 282);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(103, 20);
            this.txtAngle.TabIndex = 7;
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(302, 284);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(82, 13);
            this.lblAngle.TabIndex = 8;
            this.lblAngle.Text = "Угол поворота";
            // 
            // btnInverseTransform
            // 
            this.btnInverseTransform.Location = new System.Drawing.Point(854, 206);
            this.btnInverseTransform.Name = "btnInverseTransform";
            this.btnInverseTransform.Size = new System.Drawing.Size(230, 23);
            this.btnInverseTransform.TabIndex = 9;
            this.btnInverseTransform.Text = "Обратное преобр.";
            this.btnInverseTransform.UseVisualStyleBackColor = true;
            this.btnInverseTransform.Click += new System.EventHandler(this.btnInverseTransform_Click);
            // 
            // pictureBoxNonLinearTransform
            // 
            this.pictureBoxNonLinearTransform.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxNonLinearTransform.Location = new System.Drawing.Point(560, 24);
            this.pictureBoxNonLinearTransform.Name = "pictureBoxNonLinearTransform";
            this.pictureBoxNonLinearTransform.Size = new System.Drawing.Size(230, 156);
            this.pictureBoxNonLinearTransform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNonLinearTransform.TabIndex = 10;
            this.pictureBoxNonLinearTransform.TabStop = false;
            // 
            // btnSaveNonLinearImage
            // 
            this.btnSaveNonLinearImage.Location = new System.Drawing.Point(560, 244);
            this.btnSaveNonLinearImage.Name = "btnSaveNonLinearImage";
            this.btnSaveNonLinearImage.Size = new System.Drawing.Size(230, 23);
            this.btnSaveNonLinearImage.TabIndex = 11;
            this.btnSaveNonLinearImage.Text = "Сохранить изображение";
            this.btnSaveNonLinearImage.UseVisualStyleBackColor = true;
            this.btnSaveNonLinearImage.Click += new System.EventHandler(this.btnSaveNonLinearImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 336);
            this.Controls.Add(this.btnSaveNonLinearImage);
            this.Controls.Add(this.pictureBoxNonLinearTransform);
            this.Controls.Add(this.btnInverseTransform);
            this.Controls.Add(this.lblAngle);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnNonLinearTransform);
            this.Controls.Add(this.btnAffineTransform);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pictureBoxRestored);
            this.Controls.Add(this.pictureBoxTransformed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestored)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNonLinearTransform)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxTransformed;
        private System.Windows.Forms.PictureBox pictureBoxRestored;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnAffineTransform;
        private System.Windows.Forms.Button btnNonLinearTransform;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Button btnInverseTransform;
        private System.Windows.Forms.PictureBox pictureBoxNonLinearTransform;
        private System.Windows.Forms.Button btnSaveNonLinearImage;
    }
}

