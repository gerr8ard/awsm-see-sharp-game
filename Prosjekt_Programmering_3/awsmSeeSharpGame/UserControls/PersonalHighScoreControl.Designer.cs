namespace awsmSeeSharpGame.UserControls
{
    partial class PersonalHighScoreControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderPersonalHighScore = new System.Windows.Forms.Label();
            this.lvPersonalHighScore = new System.Windows.Forms.ListView();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeaderPersonalHighScore);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(450, 46);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeaderPersonalHighScore
            // 
            this.lblHeaderPersonalHighScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderPersonalHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPersonalHighScore.ForeColor = System.Drawing.Color.White;
            this.lblHeaderPersonalHighScore.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderPersonalHighScore.Name = "lblHeaderPersonalHighScore";
            this.lblHeaderPersonalHighScore.Size = new System.Drawing.Size(450, 46);
            this.lblHeaderPersonalHighScore.TabIndex = 0;
            this.lblHeaderPersonalHighScore.Text = "Dine høyeste poengsummer";
            this.lblHeaderPersonalHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvPersonalHighScore
            // 
            this.lvPersonalHighScore.BackgroundImage = global::awsmSeeSharpGame.Properties.Resources.ExplodingStar1;
            this.lvPersonalHighScore.Location = new System.Drawing.Point(0, 52);
            this.lvPersonalHighScore.Name = "lvPersonalHighScore";
            this.lvPersonalHighScore.Size = new System.Drawing.Size(450, 446);
            this.lvPersonalHighScore.TabIndex = 0;
            this.lvPersonalHighScore.UseCompatibleStateImageBehavior = false;
            // 
            // PersonalHighScoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lvPersonalHighScore);
            this.Name = "PersonalHighScoreControl";
            this.Size = new System.Drawing.Size(450, 425);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPersonalHighScore;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderPersonalHighScore;
    }
}
