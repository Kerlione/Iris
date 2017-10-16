namespace Demo_Client
{
    partial class Client
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
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.LblFile = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.btnUseTheCamera = new System.Windows.Forms.Button();
            this.cmbBoxAvailableDevices = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.Location = new System.Drawing.Point(13, 13);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(860, 480);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox.TabIndex = 0;
            this.imgBox.TabStop = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(13, 499);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open file";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(94, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Location = new System.Drawing.Point(798, 499);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // LblFile
            // 
            this.LblFile.AutoSize = true;
            this.LblFile.Location = new System.Drawing.Point(175, 504);
            this.LblFile.Name = "LblFile";
            this.LblFile.Size = new System.Drawing.Size(118, 13);
            this.LblFile.TabIndex = 4;
            this.LblFile.Text = "The image from camera";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(616, 504);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(176, 13);
            this.LblStatus.TabIndex = 5;
            this.LblStatus.Text = "Status: Not connected to the server";
            // 
            // btnUseTheCamera
            // 
            this.btnUseTheCamera.Location = new System.Drawing.Point(519, 500);
            this.btnUseTheCamera.Name = "btnUseTheCamera";
            this.btnUseTheCamera.Size = new System.Drawing.Size(75, 23);
            this.btnUseTheCamera.TabIndex = 6;
            this.btnUseTheCamera.Text = "Start/Stop";
            this.btnUseTheCamera.UseVisualStyleBackColor = true;
            this.btnUseTheCamera.Click += new System.EventHandler(this.btnUseTheCamera_Click);
            // 
            // cmbBoxAvailableDevices
            // 
            this.cmbBoxAvailableDevices.FormattingEnabled = true;
            this.cmbBoxAvailableDevices.Location = new System.Drawing.Point(299, 501);
            this.cmbBoxAvailableDevices.Name = "cmbBoxAvailableDevices";
            this.cmbBoxAvailableDevices.Size = new System.Drawing.Size(196, 21);
            this.cmbBoxAvailableDevices.TabIndex = 7;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 532);
            this.Controls.Add(this.cmbBoxAvailableDevices);
            this.Controls.Add(this.btnUseTheCamera);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.LblFile);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.imgBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(901, 571);
            this.MinimumSize = new System.Drawing.Size(901, 571);
            this.Name = "Client";
            this.Text = "Client form";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label LblFile;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button btnUseTheCamera;
        private System.Windows.Forms.ComboBox cmbBoxAvailableDevices;
    }
}

