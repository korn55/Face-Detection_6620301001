namespace Face_Detection_6620301001
{
    partial class MainForm
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
            groupBoxLive = new GroupBox();
            pictureBoxCamera = new PictureBox();
            lblRecordStatus = new Label();
            lblConnectionStatus = new Label();
            btnRecord = new Button();
            btnConnect = new Button();
            pictureBoxGray = new PictureBox();
            groupBoxLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).BeginInit();
            SuspendLayout();
            // 
            // groupBoxLive
            // 
            groupBoxLive.Anchor = AnchorStyles.None;
            groupBoxLive.Controls.Add(pictureBoxCamera);
            groupBoxLive.Location = new Point(12, 53);
            groupBoxLive.Name = "groupBoxLive";
            groupBoxLive.Size = new Size(544, 373);
            groupBoxLive.TabIndex = 13;
            groupBoxLive.TabStop = false;
            groupBoxLive.Text = "Live view";
            // 
            // pictureBoxCamera
            // 
            pictureBoxCamera.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCamera.Location = new Point(6, 20);
            pictureBoxCamera.Margin = new Padding(3, 4, 3, 4);
            pictureBoxCamera.Name = "pictureBoxCamera";
            pictureBoxCamera.Size = new Size(520, 331);
            pictureBoxCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCamera.TabIndex = 0;
            pictureBoxCamera.TabStop = false;
            // 
            // lblRecordStatus
            // 
            lblRecordStatus.AutoSize = true;
            lblRecordStatus.Location = new Point(297, 522);
            lblRecordStatus.Name = "lblRecordStatus";
            lblRecordStatus.Size = new Size(84, 20);
            lblRecordStatus.TabIndex = 12;
            lblRecordStatus.Text = "Recording: ";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Location = new Point(22, 522);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(111, 20);
            lblConnectionStatus.TabIndex = 11;
            lblConnectionStatus.Text = "Camera Status: ";
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(297, 433);
            btnRecord.Margin = new Padding(3, 4, 3, 4);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(114, 61);
            btnRecord.TabIndex = 10;
            btnRecord.Text = "Start";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(22, 433);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 61);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // pictureBoxGray
            // 
            pictureBoxGray.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxGray.Location = new Point(572, 73);
            pictureBoxGray.Margin = new Padding(3, 4, 3, 4);
            pictureBoxGray.Name = "pictureBoxGray";
            pictureBoxGray.Size = new Size(262, 251);
            pictureBoxGray.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGray.TabIndex = 8;
            pictureBoxGray.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 623);
            Controls.Add(groupBoxLive);
            Controls.Add(lblRecordStatus);
            Controls.Add(lblConnectionStatus);
            Controls.Add(btnRecord);
            Controls.Add(btnConnect);
            Controls.Add(pictureBoxGray);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            groupBoxLive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxLive;
        private PictureBox pictureBoxCamera;
        private Label lblRecordStatus;
        private Label lblConnectionStatus;
        private Button btnRecord;
        private Button btnConnect;
        private PictureBox pictureBoxGray;
    }
}
