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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMainForm = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSplitterMenu = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemHowToPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainForm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainForm
            // 
            this.pnlMainForm.BackgroundImage = global::awsmSeeSharpGame.Properties.Resources.spaceBackground;
            this.pnlMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainForm.Controls.Add(this.menuStrip1);
            this.pnlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainForm.Location = new System.Drawing.Point(0, 0);
            this.pnlMainForm.Name = "pnlMainForm";
            this.pnlMainForm.Size = new System.Drawing.Size(1184, 662);
            this.pnlMainForm.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemMenu,
            this.tsMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsMenuItemMenu
            // 
            this.tsMenuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemMainMenu,
            this.tsMenuItemSplitterMenu,
            this.tsMenuItemQuit});
            this.tsMenuItemMenu.Name = "tsMenuItemMenu";
            this.tsMenuItemMenu.Size = new System.Drawing.Size(49, 20);
            this.tsMenuItemMenu.Text = "Meny";
            // 
            // tsMenuItemMainMenu
            // 
            this.tsMenuItemMainMenu.Name = "tsMenuItemMainMenu";
            this.tsMenuItemMainMenu.Size = new System.Drawing.Size(167, 22);
            this.tsMenuItemMainMenu.Text = "Gå til hovedmeny";
            this.tsMenuItemMainMenu.Click += new System.EventHandler(this.tsMenuItemMainMenu_Click);
            // 
            // tsMenuItemSplitterMenu
            // 
            this.tsMenuItemSplitterMenu.Name = "tsMenuItemSplitterMenu";
            this.tsMenuItemSplitterMenu.Size = new System.Drawing.Size(164, 6);
            // 
            // tsMenuItemQuit
            // 
            this.tsMenuItemQuit.Name = "tsMenuItemQuit";
            this.tsMenuItemQuit.Size = new System.Drawing.Size(167, 22);
            this.tsMenuItemQuit.Text = "Avslutt";
            this.tsMenuItemQuit.Click += new System.EventHandler(this.tsMenuItemQuit_Click);
            // 
            // tsMenuItemHelp
            // 
            this.tsMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemHowToPlay,
            this.tsMenuItemAbout});
            this.tsMenuItemHelp.Name = "tsMenuItemHelp";
            this.tsMenuItemHelp.Size = new System.Drawing.Size(47, 20);
            this.tsMenuItemHelp.Text = "Hjelp";
            // 
            // tsMenuItemHowToPlay
            // 
            this.tsMenuItemHowToPlay.Name = "tsMenuItemHowToPlay";
            this.tsMenuItemHowToPlay.Size = new System.Drawing.Size(209, 22);
            this.tsMenuItemHowToPlay.Text = "Hvordan spille Alien Wars";
            this.tsMenuItemHowToPlay.Click += new System.EventHandler(this.tsMenuItemHowToPlay_Click);
            // 
            // tsMenuItemAbout
            // 
            this.tsMenuItemAbout.Name = "tsMenuItemAbout";
            this.tsMenuItemAbout.Size = new System.Drawing.Size(209, 22);
            this.tsMenuItemAbout.Text = "Om...";
            this.tsMenuItemAbout.Click += new System.EventHandler(this.tsMenuItemAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.pnlMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "Alien Wars";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlMainForm.ResumeLayout(false);
            this.pnlMainForm.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainForm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemMainMenu;
        private System.Windows.Forms.ToolStripSeparator tsMenuItemSplitterMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemHowToPlay;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAbout;
    }
}

