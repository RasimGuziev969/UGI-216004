namespace PhotoEnhancer
{
    partial class MainForm
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
            this.orginalPictureBox = new System.Windows.Forms.PictureBox();
            this.rusultPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.orginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rusultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // orginalPictureBox
            // 
            this.orginalPictureBox.Location = new System.Drawing.Point(407, 45);
            this.orginalPictureBox.Name = "orginalPictureBox";
            this.orginalPictureBox.Size = new System.Drawing.Size(100, 50);
            this.orginalPictureBox.TabIndex = 0;
            this.orginalPictureBox.TabStop = false;
            // 
            // rusultPictureBox
            // 
            this.rusultPictureBox.Location = new System.Drawing.Point(407, 174);
            this.rusultPictureBox.Name = "rusultPictureBox";
            this.rusultPictureBox.Size = new System.Drawing.Size(100, 50);
            this.rusultPictureBox.TabIndex = 1;
            this.rusultPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.rusultPictureBox);
            this.Controls.Add(this.orginalPictureBox);
            this.Name = "MainForm";
            this.Text = "PhotoEnhancer";
            ((System.ComponentModel.ISupportInitialize)(this.orginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rusultPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox orginalPictureBox;
        private System.Windows.Forms.PictureBox rusultPictureBox;
    }
}

