namespace TRR_SaveMaster
{
    partial class UnlocksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlocksForm));
            this.grpTRX = new System.Windows.Forms.GroupBox();
            this.chkSocietyOfRaidersJoinedTRX = new System.Windows.Forms.CheckBox();
            this.chkTR3Completed = new System.Windows.Forms.CheckBox();
            this.chkTR2Completed = new System.Windows.Forms.CheckBox();
            this.chkTR1Completed = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpTRX2 = new System.Windows.Forms.GroupBox();
            this.chkSocietyOfRaidersJoinedTRX2 = new System.Windows.Forms.CheckBox();
            this.chkTR6Completed = new System.Windows.Forms.CheckBox();
            this.chkTR5Completed = new System.Windows.Forms.CheckBox();
            this.chkTR4Completed = new System.Windows.Forms.CheckBox();
            this.grpTRX.SuspendLayout();
            this.grpTRX2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTRX
            // 
            this.grpTRX.Controls.Add(this.chkSocietyOfRaidersJoinedTRX);
            this.grpTRX.Controls.Add(this.chkTR3Completed);
            this.grpTRX.Controls.Add(this.chkTR2Completed);
            this.grpTRX.Controls.Add(this.chkTR1Completed);
            this.grpTRX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTRX.Location = new System.Drawing.Point(12, 5);
            this.grpTRX.Name = "grpTRX";
            this.grpTRX.Size = new System.Drawing.Size(311, 142);
            this.grpTRX.TabIndex = 0;
            this.grpTRX.TabStop = false;
            this.grpTRX.Text = "Tomb Raider I-III";
            // 
            // chkSocietyOfRaidersJoinedTRX
            // 
            this.chkSocietyOfRaidersJoinedTRX.AutoSize = true;
            this.chkSocietyOfRaidersJoinedTRX.Enabled = false;
            this.chkSocietyOfRaidersJoinedTRX.Location = new System.Drawing.Point(16, 105);
            this.chkSocietyOfRaidersJoinedTRX.Name = "chkSocietyOfRaidersJoinedTRX";
            this.chkSocietyOfRaidersJoinedTRX.Size = new System.Drawing.Size(156, 19);
            this.chkSocietyOfRaidersJoinedTRX.TabIndex = 3;
            this.chkSocietyOfRaidersJoinedTRX.Text = "Society of Raiders Joined";
            this.chkSocietyOfRaidersJoinedTRX.UseVisualStyleBackColor = true;
            this.chkSocietyOfRaidersJoinedTRX.CheckedChanged += new System.EventHandler(this.chkSocietyOfRaidersJoinedTRX_CheckedChanged);
            // 
            // chkTR3Completed
            // 
            this.chkTR3Completed.AutoSize = true;
            this.chkTR3Completed.Enabled = false;
            this.chkTR3Completed.Location = new System.Drawing.Point(16, 79);
            this.chkTR3Completed.Name = "chkTR3Completed";
            this.chkTR3Completed.Size = new System.Drawing.Size(167, 19);
            this.chkTR3Completed.TabIndex = 2;
            this.chkTR3Completed.Text = "Tomb Raider III Completed";
            this.chkTR3Completed.UseVisualStyleBackColor = true;
            this.chkTR3Completed.CheckedChanged += new System.EventHandler(this.chkTR3Completed_CheckedChanged);
            // 
            // chkTR2Completed
            // 
            this.chkTR2Completed.AutoSize = true;
            this.chkTR2Completed.Enabled = false;
            this.chkTR2Completed.Location = new System.Drawing.Point(16, 53);
            this.chkTR2Completed.Name = "chkTR2Completed";
            this.chkTR2Completed.Size = new System.Drawing.Size(164, 19);
            this.chkTR2Completed.TabIndex = 1;
            this.chkTR2Completed.Text = "Tomb Raider II Completed";
            this.chkTR2Completed.UseVisualStyleBackColor = true;
            this.chkTR2Completed.CheckedChanged += new System.EventHandler(this.chkTR2Completed_CheckedChanged);
            // 
            // chkTR1Completed
            // 
            this.chkTR1Completed.AutoSize = true;
            this.chkTR1Completed.Enabled = false;
            this.chkTR1Completed.Location = new System.Drawing.Point(16, 27);
            this.chkTR1Completed.Name = "chkTR1Completed";
            this.chkTR1Completed.Size = new System.Drawing.Size(161, 19);
            this.chkTR1Completed.TabIndex = 0;
            this.chkTR1Completed.Text = "Tomb Raider I Completed";
            this.chkTR1Completed.UseVisualStyleBackColor = true;
            this.chkTR1Completed.CheckedChanged += new System.EventHandler(this.chkTR1Completed_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(86, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(167, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(248, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpTRX2
            // 
            this.grpTRX2.Controls.Add(this.chkSocietyOfRaidersJoinedTRX2);
            this.grpTRX2.Controls.Add(this.chkTR6Completed);
            this.grpTRX2.Controls.Add(this.chkTR5Completed);
            this.grpTRX2.Controls.Add(this.chkTR4Completed);
            this.grpTRX2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTRX2.Location = new System.Drawing.Point(12, 153);
            this.grpTRX2.Name = "grpTRX2";
            this.grpTRX2.Size = new System.Drawing.Size(311, 142);
            this.grpTRX2.TabIndex = 4;
            this.grpTRX2.TabStop = false;
            this.grpTRX2.Text = "Tomb Raider IV-VI";
            // 
            // chkSocietyOfRaidersJoinedTRX2
            // 
            this.chkSocietyOfRaidersJoinedTRX2.AutoSize = true;
            this.chkSocietyOfRaidersJoinedTRX2.Enabled = false;
            this.chkSocietyOfRaidersJoinedTRX2.Location = new System.Drawing.Point(16, 105);
            this.chkSocietyOfRaidersJoinedTRX2.Name = "chkSocietyOfRaidersJoinedTRX2";
            this.chkSocietyOfRaidersJoinedTRX2.Size = new System.Drawing.Size(156, 19);
            this.chkSocietyOfRaidersJoinedTRX2.TabIndex = 3;
            this.chkSocietyOfRaidersJoinedTRX2.Text = "Society of Raiders Joined";
            this.chkSocietyOfRaidersJoinedTRX2.UseVisualStyleBackColor = true;
            this.chkSocietyOfRaidersJoinedTRX2.CheckedChanged += new System.EventHandler(this.chkSocietyOfRaidersJoinedTRX2_CheckedChanged);
            // 
            // chkTR6Completed
            // 
            this.chkTR6Completed.AutoSize = true;
            this.chkTR6Completed.Enabled = false;
            this.chkTR6Completed.Location = new System.Drawing.Point(16, 79);
            this.chkTR6Completed.Name = "chkTR6Completed";
            this.chkTR6Completed.Size = new System.Drawing.Size(168, 19);
            this.chkTR6Completed.TabIndex = 2;
            this.chkTR6Completed.Text = "Tomb Raider VI Completed";
            this.chkTR6Completed.UseVisualStyleBackColor = true;
            this.chkTR6Completed.CheckedChanged += new System.EventHandler(this.chkTR6Completed_CheckedChanged);
            // 
            // chkTR5Completed
            // 
            this.chkTR5Completed.AutoSize = true;
            this.chkTR5Completed.Enabled = false;
            this.chkTR5Completed.Location = new System.Drawing.Point(16, 53);
            this.chkTR5Completed.Name = "chkTR5Completed";
            this.chkTR5Completed.Size = new System.Drawing.Size(165, 19);
            this.chkTR5Completed.TabIndex = 1;
            this.chkTR5Completed.Text = "Tomb Raider V Completed";
            this.chkTR5Completed.UseVisualStyleBackColor = true;
            this.chkTR5Completed.CheckedChanged += new System.EventHandler(this.chkTR5Completed_CheckedChanged);
            // 
            // chkTR4Completed
            // 
            this.chkTR4Completed.AutoSize = true;
            this.chkTR4Completed.Enabled = false;
            this.chkTR4Completed.Location = new System.Drawing.Point(16, 27);
            this.chkTR4Completed.Name = "chkTR4Completed";
            this.chkTR4Completed.Size = new System.Drawing.Size(168, 19);
            this.chkTR4Completed.TabIndex = 0;
            this.chkTR4Completed.Text = "Tomb Raider IV Completed";
            this.chkTR4Completed.UseVisualStyleBackColor = true;
            this.chkTR4Completed.CheckedChanged += new System.EventHandler(this.chkTR4Completed_CheckedChanged);
            // 
            // UnlocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 331);
            this.Controls.Add(this.grpTRX2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpTRX);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnlocksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Unlocks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnlocksForm_FormClosing);
            this.Load += new System.EventHandler(this.UnlocksForm_Load);
            this.grpTRX.ResumeLayout(false);
            this.grpTRX.PerformLayout();
            this.grpTRX2.ResumeLayout(false);
            this.grpTRX2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTRX;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkSocietyOfRaidersJoinedTRX;
        private System.Windows.Forms.CheckBox chkTR3Completed;
        private System.Windows.Forms.CheckBox chkTR2Completed;
        private System.Windows.Forms.CheckBox chkTR1Completed;
        private System.Windows.Forms.GroupBox grpTRX2;
        private System.Windows.Forms.CheckBox chkSocietyOfRaidersJoinedTRX2;
        private System.Windows.Forms.CheckBox chkTR6Completed;
        private System.Windows.Forms.CheckBox chkTR5Completed;
        private System.Windows.Forms.CheckBox chkTR4Completed;
    }
}