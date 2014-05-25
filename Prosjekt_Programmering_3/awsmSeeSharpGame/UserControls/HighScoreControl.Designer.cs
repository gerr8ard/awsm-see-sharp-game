namespace awsmSeeSharpGame.UserControls
{
    partial class HighScoreControl
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
            this.dgvHighScore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHighScore
            // 
            this.dgvHighScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHighScore.Location = new System.Drawing.Point(0, 0);
            this.dgvHighScore.Name = "dgvHighScore";
            this.dgvHighScore.Size = new System.Drawing.Size(450, 500);
            this.dgvHighScore.TabIndex = 0;
            // 
            // HighScoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgvHighScore);
            this.Name = "HighScoreControl";
            this.Size = new System.Drawing.Size(450, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighScore;


    }
}
