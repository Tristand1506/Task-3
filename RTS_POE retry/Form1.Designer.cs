namespace RTS_POE
{
    partial class GameWindow
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.gbxUntilUI = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblBattleLog = new System.Windows.Forms.Label();
            this.lbxBattleLog = new System.Windows.Forms.ListBox();
            this.lblSelectedUnit = new System.Windows.Forms.Label();
            this.rtbUnitInfo = new System.Windows.Forms.RichTextBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlBattleField = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxUntilUI.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(4, 655);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(134, 40);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.TmrClock_Tick);
            // 
            // gbxUntilUI
            // 
            this.gbxUntilUI.Controls.Add(this.btnSave);
            this.gbxUntilUI.Controls.Add(this.lblBattleLog);
            this.gbxUntilUI.Controls.Add(this.lbxBattleLog);
            this.gbxUntilUI.Controls.Add(this.lblSelectedUnit);
            this.gbxUntilUI.Controls.Add(this.rtbUnitInfo);
            this.gbxUntilUI.Controls.Add(this.lblRound);
            this.gbxUntilUI.Controls.Add(this.button2);
            this.gbxUntilUI.Controls.Add(this.btnStop);
            this.gbxUntilUI.Controls.Add(this.btnPause);
            this.gbxUntilUI.Controls.Add(this.btnStartStop);
            this.gbxUntilUI.Location = new System.Drawing.Point(718, 25);
            this.gbxUntilUI.Name = "gbxUntilUI";
            this.gbxUntilUI.Size = new System.Drawing.Size(364, 700);
            this.gbxUntilUI.TabIndex = 4;
            this.gbxUntilUI.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBattleLog
            // 
            this.lblBattleLog.AutoSize = true;
            this.lblBattleLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattleLog.Location = new System.Drawing.Point(6, 423);
            this.lblBattleLog.Name = "lblBattleLog";
            this.lblBattleLog.Size = new System.Drawing.Size(119, 25);
            this.lblBattleLog.TabIndex = 9;
            this.lblBattleLog.Text = "Battle Log";
            // 
            // lbxBattleLog
            // 
            this.lbxBattleLog.FormattingEnabled = true;
            this.lbxBattleLog.Location = new System.Drawing.Point(6, 451);
            this.lbxBattleLog.Name = "lbxBattleLog";
            this.lbxBattleLog.Size = new System.Drawing.Size(352, 147);
            this.lbxBattleLog.TabIndex = 8;
            // 
            // lblSelectedUnit
            // 
            this.lblSelectedUnit.AutoSize = true;
            this.lblSelectedUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedUnit.Location = new System.Drawing.Point(14, 22);
            this.lblSelectedUnit.Name = "lblSelectedUnit";
            this.lblSelectedUnit.Size = new System.Drawing.Size(153, 25);
            this.lblSelectedUnit.TabIndex = 7;
            this.lblSelectedUnit.Text = "Selected Unit";
            // 
            // rtbUnitInfo
            // 
            this.rtbUnitInfo.Enabled = false;
            this.rtbUnitInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbUnitInfo.Location = new System.Drawing.Point(6, 50);
            this.rtbUnitInfo.Name = "rtbUnitInfo";
            this.rtbUnitInfo.Size = new System.Drawing.Size(352, 370);
            this.rtbUnitInfo.TabIndex = 6;
            this.rtbUnitInfo.Text = "";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(258, 22);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(100, 25);
            this.lblRound.TabIndex = 5;
            this.lblRound.Text = "Round 1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 611);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(224, 655);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(134, 40);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(142, 611);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(77, 84);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // pnlBattleField
            // 
            this.pnlBattleField.Location = new System.Drawing.Point(12, 25);
            this.pnlBattleField.Name = "pnlBattleField";
            this.pnlBattleField.Size = new System.Drawing.Size(700, 700);
            this.pnlBattleField.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 731);
            this.Controls.Add(this.pnlBattleField);
            this.Controls.Add(this.gbxUntilUI);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameWindow";
            this.Text = "Form1";
            this.gbxUntilUI.ResumeLayout(false);
            this.gbxUntilUI.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.GroupBox gbxUntilUI;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblBattleLog;
        private System.Windows.Forms.ListBox lbxBattleLog;
        private System.Windows.Forms.Label lblSelectedUnit;
        private System.Windows.Forms.RichTextBox rtbUnitInfo;
        private System.Windows.Forms.Panel pnlBattleField;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
    }
}

