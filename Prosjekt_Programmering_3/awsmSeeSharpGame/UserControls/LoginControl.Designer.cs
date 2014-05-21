namespace awsmSeeSharpGame.UserControls
{
    partial class LoginControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserNameLoginControl = new System.Windows.Forms.Label();
            this.lblPasswordLoginControl = new System.Windows.Forms.Label();
            this.tbPasswordLoginControl = new System.Windows.Forms.TextBox();
            this.tbUserNameLoginControl = new System.Windows.Forms.TextBox();
            this.btnLoginLoginControl = new System.Windows.Forms.Button();
            this.btnNewUserLoginControl = new System.Windows.Forms.Button();
            this.lblHeaderLoginControl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.Controls.Add(this.lblUserNameLoginControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordLoginControl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPasswordLoginControl, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbUserNameLoginControl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoginLoginControl, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNewUserLoginControl, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHeaderLoginControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(751, 67);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblUserNameLoginControl
            // 
            this.lblUserNameLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserNameLoginControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameLoginControl.ForeColor = System.Drawing.Color.White;
            this.lblUserNameLoginControl.Location = new System.Drawing.Point(3, 26);
            this.lblUserNameLoginControl.Name = "lblUserNameLoginControl";
            this.lblUserNameLoginControl.Size = new System.Drawing.Size(94, 41);
            this.lblUserNameLoginControl.TabIndex = 0;
            this.lblUserNameLoginControl.Text = "Brukernavn:";
            this.lblUserNameLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPasswordLoginControl
            // 
            this.lblPasswordLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPasswordLoginControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordLoginControl.ForeColor = System.Drawing.Color.White;
            this.lblPasswordLoginControl.Location = new System.Drawing.Point(253, 26);
            this.lblPasswordLoginControl.Name = "lblPasswordLoginControl";
            this.lblPasswordLoginControl.Size = new System.Drawing.Size(94, 41);
            this.lblPasswordLoginControl.TabIndex = 2;
            this.lblPasswordLoginControl.Text = "Passord:";
            this.lblPasswordLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPasswordLoginControl
            // 
            this.tbPasswordLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPasswordLoginControl.Location = new System.Drawing.Point(353, 36);
            this.tbPasswordLoginControl.Name = "tbPasswordLoginControl";
            this.tbPasswordLoginControl.PasswordChar = '*';
            this.tbPasswordLoginControl.Size = new System.Drawing.Size(144, 20);
            this.tbPasswordLoginControl.TabIndex = 2;
            // 
            // tbUserNameLoginControl
            // 
            this.tbUserNameLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUserNameLoginControl.Location = new System.Drawing.Point(103, 36);
            this.tbUserNameLoginControl.Name = "tbUserNameLoginControl";
            this.tbUserNameLoginControl.Size = new System.Drawing.Size(144, 20);
            this.tbUserNameLoginControl.TabIndex = 1;
            // 
            // btnLoginLoginControl
            // 
            this.btnLoginLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoginLoginControl.Location = new System.Drawing.Point(503, 29);
            this.btnLoginLoginControl.Name = "btnLoginLoginControl";
            this.btnLoginLoginControl.Size = new System.Drawing.Size(94, 35);
            this.btnLoginLoginControl.TabIndex = 3;
            this.btnLoginLoginControl.Text = "&Logg inn";
            this.btnLoginLoginControl.UseVisualStyleBackColor = true;
            this.btnLoginLoginControl.Click += new System.EventHandler(this.btnLoginLoginControl_Click);
            // 
            // btnNewUserLoginControl
            // 
            this.btnNewUserLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewUserLoginControl.Location = new System.Drawing.Point(603, 29);
            this.btnNewUserLoginControl.Name = "btnNewUserLoginControl";
            this.btnNewUserLoginControl.Size = new System.Drawing.Size(145, 35);
            this.btnNewUserLoginControl.TabIndex = 4;
            this.btnNewUserLoginControl.Text = "&Registrer ny bruker";
            this.btnNewUserLoginControl.UseVisualStyleBackColor = true;
            this.btnNewUserLoginControl.Click += new System.EventHandler(this.btnNewUserLoginControl_Click);
            // 
            // lblHeaderLoginControl
            // 
            this.lblHeaderLoginControl.CausesValidation = false;
            this.tableLayoutPanel1.SetColumnSpan(this.lblHeaderLoginControl, 3);
            this.lblHeaderLoginControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderLoginControl.ForeColor = System.Drawing.Color.White;
            this.lblHeaderLoginControl.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderLoginControl.Name = "lblHeaderLoginControl";
            this.lblHeaderLoginControl.Size = new System.Drawing.Size(306, 23);
            this.lblHeaderLoginControl.TabIndex = 7;
            this.lblHeaderLoginControl.Text = "Logg inn her eller registrer ny bruker";
            this.lblHeaderLoginControl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(751, 67);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUserNameLoginControl;
        private System.Windows.Forms.Label lblPasswordLoginControl;
        private System.Windows.Forms.TextBox tbPasswordLoginControl;
        private System.Windows.Forms.TextBox tbUserNameLoginControl;
        private System.Windows.Forms.Button btnLoginLoginControl;
        private System.Windows.Forms.Button btnNewUserLoginControl;
        private System.Windows.Forms.Label lblHeaderLoginControl;
    }
}
