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
            this.msMenyStripe = new System.Windows.Forms.MenuStrip();
            this.MenuItemMeny = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHovedmeny = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSkilleMeny = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemAvslutt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemInnstillinger = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHjelp = new System.Windows.Forms.ToolStripMenuItem();
            this.hvordanSpilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainForm = new System.Windows.Forms.Panel();
            this.msMenyStripe.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenyStripe
            // 
            this.msMenyStripe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMeny,
            this.MenuItemInnstillinger,
            this.MenuItemHjelp});
            this.msMenyStripe.Location = new System.Drawing.Point(0, 0);
            this.msMenyStripe.Name = "msMenyStripe";
            this.msMenyStripe.Size = new System.Drawing.Size(1184, 24);
            this.msMenyStripe.TabIndex = 4;
            this.msMenyStripe.Text = "menuStrip1";
            // 
            // MenuItemMeny
            // 
            this.MenuItemMeny.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHovedmeny,
            this.MenuItemSkilleMeny,
            this.MenuItemAvslutt});
            this.MenuItemMeny.Name = "MenuItemMeny";
            this.MenuItemMeny.Size = new System.Drawing.Size(49, 20);
            this.MenuItemMeny.Text = "Meny";
            // 
            // MenuItemHovedmeny
            // 
            this.MenuItemHovedmeny.Name = "MenuItemHovedmeny";
            this.MenuItemHovedmeny.Size = new System.Drawing.Size(152, 22);
            this.MenuItemHovedmeny.Text = "Hovedmeny";
            this.MenuItemHovedmeny.Click += new System.EventHandler(this.MenuItemHovedmeny_Click);
            // 
            // MenuItemSkilleMeny
            // 
            this.MenuItemSkilleMeny.Name = "MenuItemSkilleMeny";
            this.MenuItemSkilleMeny.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuItemAvslutt
            // 
            this.MenuItemAvslutt.Name = "MenuItemAvslutt";
            this.MenuItemAvslutt.Size = new System.Drawing.Size(152, 22);
            this.MenuItemAvslutt.Text = "&Avslutt";
            this.MenuItemAvslutt.Click += new System.EventHandler(this.MenuItemAvslutt_Click);
            // 
            // MenuItemInnstillinger
            // 
            this.MenuItemInnstillinger.Name = "MenuItemInnstillinger";
            this.MenuItemInnstillinger.Size = new System.Drawing.Size(81, 20);
            this.MenuItemInnstillinger.Text = "Innstillinger";
            // 
            // MenuItemHjelp
            // 
            this.MenuItemHjelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hvordanSpilleToolStripMenuItem,
            this.omToolStripMenuItem});
            this.MenuItemHjelp.Name = "MenuItemHjelp";
            this.MenuItemHjelp.Size = new System.Drawing.Size(47, 20);
            this.MenuItemHjelp.Text = "Hjelp";
            // 
            // hvordanSpilleToolStripMenuItem
            // 
            this.hvordanSpilleToolStripMenuItem.Name = "hvordanSpilleToolStripMenuItem";
            this.hvordanSpilleToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hvordanSpilleToolStripMenuItem.Text = "Hvordan spille...";
            this.hvordanSpilleToolStripMenuItem.Click += new System.EventHandler(this.hvordanSpilleToolStripMenuItem_Click);
            // 
            // omToolStripMenuItem
            // 
            this.omToolStripMenuItem.Name = "omToolStripMenuItem";
            this.omToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.omToolStripMenuItem.Text = "Om...";
            this.omToolStripMenuItem.Click += new System.EventHandler(this.omToolStripMenuItem_Click);
            // 
            // pnlMainForm
            // 
            this.pnlMainForm.BackgroundImage = global::awsmSeeSharpGame.Properties.Resources.spaceBackground;
            this.pnlMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainForm.Location = new System.Drawing.Point(0, 24);
            this.pnlMainForm.Name = "pnlMainForm";
            this.pnlMainForm.Size = new System.Drawing.Size(1184, 638);
            this.pnlMainForm.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.pnlMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "Maximum Combat Havoc - Mystery Robot Strikes Back";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.msMenyStripe.ResumeLayout(false);
            this.msMenyStripe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenyStripe;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMeny;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHovedmeny;
        private System.Windows.Forms.ToolStripSeparator MenuItemSkilleMeny;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAvslutt;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInnstillinger;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHjelp;
        private System.Windows.Forms.ToolStripMenuItem hvordanSpilleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMainForm;
    }
}

