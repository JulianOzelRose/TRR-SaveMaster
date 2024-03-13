
namespace TRR_SaveMaster
{
    partial class PositionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionForm));
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.picInfoDirection = new System.Windows.Forms.PictureBox();
            this.picInfoZCoordinate = new System.Windows.Forms.PictureBox();
            this.picInfoYCoordinate = new System.Windows.Forms.PictureBox();
            this.picInfoXCoordinate = new System.Windows.Forms.PictureBox();
            this.btnEndOfLevel = new System.Windows.Forms.Button();
            this.nudDirection = new System.Windows.Forms.NumericUpDown();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblZCoordinate = new System.Windows.Forms.Label();
            this.lblYCoordinate = new System.Windows.Forms.Label();
            this.lblXCoordinate = new System.Windows.Forms.Label();
            this.nudZCoordinate = new System.Windows.Forms.NumericUpDown();
            this.nudYCoordinate = new System.Windows.Forms.NumericUpDown();
            this.nudXCoordinate = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tipPosition = new System.Windows.Forms.ToolTip(this.components);
            this.grpLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoZCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoYCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoXCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCoordinate)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.picInfoDirection);
            this.grpLevel.Controls.Add(this.picInfoZCoordinate);
            this.grpLevel.Controls.Add(this.picInfoYCoordinate);
            this.grpLevel.Controls.Add(this.picInfoXCoordinate);
            this.grpLevel.Controls.Add(this.btnEndOfLevel);
            this.grpLevel.Controls.Add(this.nudDirection);
            this.grpLevel.Controls.Add(this.lblDirection);
            this.grpLevel.Controls.Add(this.lblZCoordinate);
            this.grpLevel.Controls.Add(this.lblYCoordinate);
            this.grpLevel.Controls.Add(this.lblXCoordinate);
            this.grpLevel.Controls.Add(this.nudZCoordinate);
            this.grpLevel.Controls.Add(this.nudYCoordinate);
            this.grpLevel.Controls.Add(this.nudXCoordinate);
            this.grpLevel.Location = new System.Drawing.Point(12, 5);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(333, 191);
            this.grpLevel.TabIndex = 0;
            this.grpLevel.TabStop = false;
            // 
            // picInfoDirection
            // 
            this.picInfoDirection.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoDirection.Location = new System.Drawing.Point(300, 111);
            this.picInfoDirection.Name = "picInfoDirection";
            this.picInfoDirection.Size = new System.Drawing.Size(20, 20);
            this.picInfoDirection.TabIndex = 11;
            this.picInfoDirection.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoDirection, "Modifies movement relative to Lara\'s facing direction.");
            // 
            // picInfoZCoordinate
            // 
            this.picInfoZCoordinate.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoZCoordinate.Location = new System.Drawing.Point(300, 85);
            this.picInfoZCoordinate.Name = "picInfoZCoordinate";
            this.picInfoZCoordinate.Size = new System.Drawing.Size(20, 20);
            this.picInfoZCoordinate.TabIndex = 10;
            this.picInfoZCoordinate.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoZCoordinate, "Represents depth position in the game world. Increasing moves Lara forwards, decr" +
        "easing moves her backwards.");
            // 
            // picInfoYCoordinate
            // 
            this.picInfoYCoordinate.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoYCoordinate.Location = new System.Drawing.Point(300, 59);
            this.picInfoYCoordinate.Name = "picInfoYCoordinate";
            this.picInfoYCoordinate.Size = new System.Drawing.Size(20, 20);
            this.picInfoYCoordinate.TabIndex = 9;
            this.picInfoYCoordinate.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoYCoordinate, "Represents vertical position in game. Decreasing moves Lara up, increasing moves " +
        "her down.");
            // 
            // picInfoXCoordinate
            // 
            this.picInfoXCoordinate.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoXCoordinate.Location = new System.Drawing.Point(300, 33);
            this.picInfoXCoordinate.Name = "picInfoXCoordinate";
            this.picInfoXCoordinate.Size = new System.Drawing.Size(20, 20);
            this.picInfoXCoordinate.TabIndex = 8;
            this.picInfoXCoordinate.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoXCoordinate, "Represents horizontal position in the game world. Decreasing moves Lara to the le" +
        "ft, increasing moves her to the right.");
            // 
            // btnEndOfLevel
            // 
            this.btnEndOfLevel.Enabled = false;
            this.btnEndOfLevel.Location = new System.Drawing.Point(107, 147);
            this.btnEndOfLevel.Name = "btnEndOfLevel";
            this.btnEndOfLevel.Size = new System.Drawing.Size(110, 23);
            this.btnEndOfLevel.TabIndex = 5;
            this.btnEndOfLevel.Text = "End of Level";
            this.btnEndOfLevel.UseVisualStyleBackColor = true;
            this.btnEndOfLevel.Click += new System.EventHandler(this.btnEndOfLevel_Click);
            // 
            // nudDirection
            // 
            this.nudDirection.Location = new System.Drawing.Point(201, 111);
            this.nudDirection.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudDirection.Name = "nudDirection";
            this.nudDirection.Size = new System.Drawing.Size(88, 20);
            this.nudDirection.TabIndex = 7;
            this.nudDirection.ValueChanged += new System.EventHandler(this.nudDirection_ValueChanged);
            this.nudDirection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDirection_KeyPress);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(12, 111);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(52, 13);
            this.lblDirection.TabIndex = 6;
            this.lblDirection.Text = "Direction:";
            // 
            // lblZCoordinate
            // 
            this.lblZCoordinate.AutoSize = true;
            this.lblZCoordinate.Location = new System.Drawing.Point(12, 85);
            this.lblZCoordinate.Name = "lblZCoordinate";
            this.lblZCoordinate.Size = new System.Drawing.Size(63, 13);
            this.lblZCoordinate.TabIndex = 5;
            this.lblZCoordinate.Text = "Position (Z):";
            // 
            // lblYCoordinate
            // 
            this.lblYCoordinate.AutoSize = true;
            this.lblYCoordinate.Location = new System.Drawing.Point(12, 59);
            this.lblYCoordinate.Name = "lblYCoordinate";
            this.lblYCoordinate.Size = new System.Drawing.Size(63, 13);
            this.lblYCoordinate.TabIndex = 4;
            this.lblYCoordinate.Text = "Position (Y):";
            // 
            // lblXCoordinate
            // 
            this.lblXCoordinate.AutoSize = true;
            this.lblXCoordinate.Location = new System.Drawing.Point(12, 33);
            this.lblXCoordinate.Name = "lblXCoordinate";
            this.lblXCoordinate.Size = new System.Drawing.Size(63, 13);
            this.lblXCoordinate.TabIndex = 3;
            this.lblXCoordinate.Text = "Position (X):";
            // 
            // nudZCoordinate
            // 
            this.nudZCoordinate.Increment = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudZCoordinate.Location = new System.Drawing.Point(201, 85);
            this.nudZCoordinate.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudZCoordinate.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudZCoordinate.Name = "nudZCoordinate";
            this.nudZCoordinate.Size = new System.Drawing.Size(88, 20);
            this.nudZCoordinate.TabIndex = 2;
            this.nudZCoordinate.ValueChanged += new System.EventHandler(this.nudZCoordinate_ValueChanged);
            this.nudZCoordinate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudZCoordinate_KeyPress);
            // 
            // nudYCoordinate
            // 
            this.nudYCoordinate.Increment = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudYCoordinate.Location = new System.Drawing.Point(201, 59);
            this.nudYCoordinate.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudYCoordinate.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudYCoordinate.Name = "nudYCoordinate";
            this.nudYCoordinate.Size = new System.Drawing.Size(88, 20);
            this.nudYCoordinate.TabIndex = 1;
            this.nudYCoordinate.ValueChanged += new System.EventHandler(this.nudYCoordinate_ValueChanged);
            this.nudYCoordinate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudYCoordinate_KeyPress);
            // 
            // nudXCoordinate
            // 
            this.nudXCoordinate.Increment = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudXCoordinate.Location = new System.Drawing.Point(201, 33);
            this.nudXCoordinate.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudXCoordinate.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudXCoordinate.Name = "nudXCoordinate";
            this.nudXCoordinate.Size = new System.Drawing.Size(88, 20);
            this.nudXCoordinate.TabIndex = 0;
            this.nudXCoordinate.ValueChanged += new System.EventHandler(this.nudXCoordinate_ValueChanged);
            this.nudXCoordinate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudXCoordinate_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(270, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(189, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(108, 202);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tipPosition
            // 
            this.tipPosition.AutoPopDelay = 10000;
            this.tipPosition.InitialDelay = 500;
            this.tipPosition.ReshowDelay = 100;
            // 
            // PositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 235);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpLevel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Position";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PositionForm_FormClosing);
            this.Load += new System.EventHandler(this.PositionForm_Load);
            this.grpLevel.ResumeLayout(false);
            this.grpLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoZCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoYCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoXCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCoordinate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.NumericUpDown nudXCoordinate;
        private System.Windows.Forms.Label lblZCoordinate;
        private System.Windows.Forms.Label lblYCoordinate;
        private System.Windows.Forms.Label lblXCoordinate;
        private System.Windows.Forms.NumericUpDown nudZCoordinate;
        private System.Windows.Forms.NumericUpDown nudYCoordinate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown nudDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button btnEndOfLevel;
        private System.Windows.Forms.PictureBox picInfoDirection;
        private System.Windows.Forms.PictureBox picInfoZCoordinate;
        private System.Windows.Forms.PictureBox picInfoYCoordinate;
        private System.Windows.Forms.PictureBox picInfoXCoordinate;
        private System.Windows.Forms.ToolTip tipPosition;
    }
}