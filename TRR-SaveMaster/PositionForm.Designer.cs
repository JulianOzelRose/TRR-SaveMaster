
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
            this.grpSavegame = new System.Windows.Forms.GroupBox();
            this.picInfoRoom = new System.Windows.Forms.PictureBox();
            this.picInfoZCoordinate = new System.Windows.Forms.PictureBox();
            this.picInfoYCoordinate = new System.Windows.Forms.PictureBox();
            this.picInfoXCoordinate = new System.Windows.Forms.PictureBox();
            this.btnEndOfLevel = new System.Windows.Forms.Button();
            this.nudRoom = new System.Windows.Forms.NumericUpDown();
            this.lblRoom = new System.Windows.Forms.Label();
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
            this.grpSavegame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoZCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoYCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoXCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCoordinate)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSavegame
            // 
            this.grpSavegame.Controls.Add(this.picInfoRoom);
            this.grpSavegame.Controls.Add(this.picInfoZCoordinate);
            this.grpSavegame.Controls.Add(this.picInfoYCoordinate);
            this.grpSavegame.Controls.Add(this.picInfoXCoordinate);
            this.grpSavegame.Controls.Add(this.btnEndOfLevel);
            this.grpSavegame.Controls.Add(this.nudRoom);
            this.grpSavegame.Controls.Add(this.lblRoom);
            this.grpSavegame.Controls.Add(this.lblZCoordinate);
            this.grpSavegame.Controls.Add(this.lblYCoordinate);
            this.grpSavegame.Controls.Add(this.lblXCoordinate);
            this.grpSavegame.Controls.Add(this.nudZCoordinate);
            this.grpSavegame.Controls.Add(this.nudYCoordinate);
            this.grpSavegame.Controls.Add(this.nudXCoordinate);
            this.grpSavegame.Location = new System.Drawing.Point(12, 5);
            this.grpSavegame.Name = "grpSavegame";
            this.grpSavegame.Size = new System.Drawing.Size(333, 191);
            this.grpSavegame.TabIndex = 0;
            this.grpSavegame.TabStop = false;
            // 
            // picInfoRoom
            // 
            this.picInfoRoom.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoRoom.Location = new System.Drawing.Point(300, 111);
            this.picInfoRoom.Name = "picInfoRoom";
            this.picInfoRoom.Size = new System.Drawing.Size(20, 20);
            this.picInfoRoom.TabIndex = 11;
            this.picInfoRoom.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoRoom, "Modifies movement relative to Lara\'s facing direction.");
            // 
            // picInfoZCoordinate
            // 
            this.picInfoZCoordinate.Image = global::TRR_SaveMaster.Properties.Resources.ToolTip_Image;
            this.picInfoZCoordinate.Location = new System.Drawing.Point(300, 85);
            this.picInfoZCoordinate.Name = "picInfoZCoordinate";
            this.picInfoZCoordinate.Size = new System.Drawing.Size(20, 20);
            this.picInfoZCoordinate.TabIndex = 10;
            this.picInfoZCoordinate.TabStop = false;
            this.tipPosition.SetToolTip(this.picInfoZCoordinate, "Represents depth position in game. Increasing moves Lara forwards, decreasing mov" +
        "es her backwards.");
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
            this.tipPosition.SetToolTip(this.picInfoXCoordinate, "Represents horizontal position in game. Decreasing moves Lara to the left, increa" +
        "sing moves her to the right.");
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
            // nudRoom
            // 
            this.nudRoom.Location = new System.Drawing.Point(201, 111);
            this.nudRoom.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRoom.Name = "nudRoom";
            this.nudRoom.Size = new System.Drawing.Size(88, 20);
            this.nudRoom.TabIndex = 7;
            this.nudRoom.ValueChanged += new System.EventHandler(this.nudRoom_ValueChanged);
            this.nudRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudRoom_KeyPress);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(12, 111);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(38, 13);
            this.lblRoom.TabIndex = 6;
            this.lblRoom.Text = "Room:";
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
            this.Controls.Add(this.grpSavegame);
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
            this.grpSavegame.ResumeLayout(false);
            this.grpSavegame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoZCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoYCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoXCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCoordinate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSavegame;
        private System.Windows.Forms.NumericUpDown nudXCoordinate;
        private System.Windows.Forms.Label lblZCoordinate;
        private System.Windows.Forms.Label lblYCoordinate;
        private System.Windows.Forms.Label lblXCoordinate;
        private System.Windows.Forms.NumericUpDown nudZCoordinate;
        private System.Windows.Forms.NumericUpDown nudYCoordinate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown nudRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Button btnEndOfLevel;
        private System.Windows.Forms.PictureBox picInfoRoom;
        private System.Windows.Forms.PictureBox picInfoZCoordinate;
        private System.Windows.Forms.PictureBox picInfoYCoordinate;
        private System.Windows.Forms.PictureBox picInfoXCoordinate;
        private System.Windows.Forms.ToolTip tipPosition;
    }
}