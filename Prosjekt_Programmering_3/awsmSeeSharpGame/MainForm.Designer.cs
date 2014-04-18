namespace awsmSeeSharpGame
{
    partial class MainForm
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTid = new System.Windows.Forms.Label();
            this.lblPoeng = new System.Windows.Forms.Label();
            this.lblTidTekst = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.pbxGamingArea = new System.Windows.Forms.PictureBox();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGamingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlInfo.Controls.Add(this.lblTid);
            this.pnlInfo.Controls.Add(this.lblPoeng);
            this.pnlInfo.Controls.Add(this.lblTidTekst);
            this.pnlInfo.Controls.Add(this.lblLevel);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(824, 43);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // lblTid
            // 
            this.lblTid.AutoSize = true;
            this.lblTid.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTid.ForeColor = System.Drawing.Color.Snow;
            this.lblTid.Location = new System.Drawing.Point(363, 9);
            this.lblTid.Name = "lblTid";
            this.lblTid.Size = new System.Drawing.Size(86, 23);
            this.lblTid.TabIndex = 3;
            this.lblTid.Text = "00:00:00";
            // 
            // lblPoeng
            // 
            this.lblPoeng.AutoSize = true;
            this.lblPoeng.BackColor = System.Drawing.Color.Transparent;
            this.lblPoeng.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoeng.ForeColor = System.Drawing.Color.Snow;
            this.lblPoeng.Location = new System.Drawing.Point(603, 9);
            this.lblPoeng.Name = "lblPoeng";
            this.lblPoeng.Size = new System.Drawing.Size(76, 23);
            this.lblPoeng.TabIndex = 2;
            this.lblPoeng.Text = "Poeng: ";
            // 
            // lblTidTekst
            // 
            this.lblTidTekst.AutoSize = true;
            this.lblTidTekst.BackColor = System.Drawing.Color.Transparent;
            this.lblTidTekst.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTidTekst.ForeColor = System.Drawing.Color.Snow;
            this.lblTidTekst.Location = new System.Drawing.Point(275, 9);
            this.lblTidTekst.Name = "lblTidTekst";
            this.lblTidTekst.Size = new System.Drawing.Size(91, 23);
            this.lblTidTekst.TabIndex = 1;
            this.lblTidTekst.Text = "Tid igjen:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Snow;
            this.lblLevel.Location = new System.Drawing.Point(12, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(54, 23);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Nivå:";
            // 
            // pbxGamingArea
            // 
            this.pbxGamingArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbxGamingArea.Location = new System.Drawing.Point(0, 35);
            this.pbxGamingArea.Name = "pbxGamingArea";
            this.pbxGamingArea.Size = new System.Drawing.Size(824, 357);
            this.pbxGamingArea.TabIndex = 1;
            this.pbxGamingArea.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 392);
            this.Controls.Add(this.pbxGamingArea);
            this.Controls.Add(this.pnlInfo);
            this.Name = "MainForm";
            this.Text = "AwsmSeeSharpGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGamingArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblTidTekst;
        private System.Windows.Forms.Label lblPoeng;
        private System.Windows.Forms.PictureBox pbxGamingArea;
        private System.Windows.Forms.Label lblTid;
    }
}

