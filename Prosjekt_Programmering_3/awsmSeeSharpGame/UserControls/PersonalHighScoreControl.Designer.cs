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
            this.lvPersonalHighScore = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvPersonalHighScore
            // 
            this.lvPersonalHighScore.BackgroundImage = global::awsmSeeSharpGame.Properties.Resources.ExplodingStar;
            this.lvPersonalHighScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPersonalHighScore.Location = new System.Drawing.Point(0, 0);
            this.lvPersonalHighScore.Name = "lvPersonalHighScore";
            this.lvPersonalHighScore.Size = new System.Drawing.Size(450, 500);
            this.lvPersonalHighScore.TabIndex = 0;
            this.lvPersonalHighScore.UseCompatibleStateImageBehavior = false;
            // 
            // PersonalHighScoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lvPersonalHighScore);
            this.Name = "PersonalHighScoreControl";
            this.Size = new System.Drawing.Size(450, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPersonalHighScore;
    }
}
