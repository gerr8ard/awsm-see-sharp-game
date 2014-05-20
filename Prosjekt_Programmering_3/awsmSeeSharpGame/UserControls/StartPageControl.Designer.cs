namespace awsmSeeSharpGame.UserControls
{
    partial class StartPageControl
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
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.btn_Highscores = new System.Windows.Forms.Button();
            this.btn_PersonalRecords = new System.Windows.Forms.Button();
            this.btn_logOut = new System.Windows.Forms.Button();
            this.btn_Terminate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.Location = new System.Drawing.Point(31, 22);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(114, 23);
            this.btn_StartGame.TabIndex = 0;
            this.btn_StartGame.Text = "Start Spill";
            this.btn_StartGame.UseVisualStyleBackColor = true;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // btn_Highscores
            // 
            this.btn_Highscores.Location = new System.Drawing.Point(31, 51);
            this.btn_Highscores.Name = "btn_Highscores";
            this.btn_Highscores.Size = new System.Drawing.Size(114, 23);
            this.btn_Highscores.TabIndex = 1;
            this.btn_Highscores.Text = "Rekorder";
            this.btn_Highscores.UseVisualStyleBackColor = true;
            // 
            // btn_PersonalRecords
            // 
            this.btn_PersonalRecords.Location = new System.Drawing.Point(31, 80);
            this.btn_PersonalRecords.Name = "btn_PersonalRecords";
            this.btn_PersonalRecords.Size = new System.Drawing.Size(114, 23);
            this.btn_PersonalRecords.TabIndex = 2;
            this.btn_PersonalRecords.Text = "Mine Rekorder";
            this.btn_PersonalRecords.UseVisualStyleBackColor = true;
            // 
            // btn_logOut
            // 
            this.btn_logOut.Location = new System.Drawing.Point(31, 110);
            this.btn_logOut.Name = "btn_logOut";
            this.btn_logOut.Size = new System.Drawing.Size(114, 23);
            this.btn_logOut.TabIndex = 3;
            this.btn_logOut.Text = "Logg ut";
            this.btn_logOut.UseVisualStyleBackColor = true;
            this.btn_logOut.Click += new System.EventHandler(this.btn_logOut_Click);
            // 
            // btn_Terminate
            // 
            this.btn_Terminate.Location = new System.Drawing.Point(31, 140);
            this.btn_Terminate.Name = "btn_Terminate";
            this.btn_Terminate.Size = new System.Drawing.Size(114, 23);
            this.btn_Terminate.TabIndex = 4;
            this.btn_Terminate.Text = "Avslutt";
            this.btn_Terminate.UseVisualStyleBackColor = true;
            this.btn_Terminate.Click += new System.EventHandler(this.btn_Terminate_Click);
            // 
            // StartPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_Terminate);
            this.Controls.Add(this.btn_logOut);
            this.Controls.Add(this.btn_PersonalRecords);
            this.Controls.Add(this.btn_Highscores);
            this.Controls.Add(this.btn_StartGame);
            this.Name = "StartPageControl";
            this.Size = new System.Drawing.Size(180, 185);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_Highscores;
        private System.Windows.Forms.Button btn_PersonalRecords;
        private System.Windows.Forms.Button btn_logOut;
        private System.Windows.Forms.Button btn_Terminate;
    }
}
