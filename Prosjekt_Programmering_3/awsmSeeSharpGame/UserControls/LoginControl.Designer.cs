namespace awsmSeeSharpGame
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
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeadlineLoginControl = new System.Windows.Forms.Label();
            this.lblUsernameLoginControl = new System.Windows.Forms.Label();
            this.lblPasswordLoginControl = new System.Windows.Forms.Label();
            this.tbUsernameLoginControl = new System.Windows.Forms.TextBox();
            this.tbPasswordLoginControl = new System.Windows.Forms.TextBox();
            this.btnLoginLoginControl = new System.Windows.Forms.Button();
            this.btnRegisterNewUserLoginControl = new System.Windows.Forms.Button();
            this.tlpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLogin
            // 
            this.tlpLogin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpLogin.ColumnCount = 2;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.58333F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.41667F));
            this.tlpLogin.Controls.Add(this.lblHeadlineLoginControl, 0, 0);
            this.tlpLogin.Controls.Add(this.lblUsernameLoginControl, 0, 1);
            this.tlpLogin.Controls.Add(this.lblPasswordLoginControl, 0, 2);
            this.tlpLogin.Controls.Add(this.tbUsernameLoginControl, 1, 1);
            this.tlpLogin.Controls.Add(this.tbPasswordLoginControl, 1, 2);
            this.tlpLogin.Controls.Add(this.btnLoginLoginControl, 0, 3);
            this.tlpLogin.Controls.Add(this.btnRegisterNewUserLoginControl, 1, 3);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(0, 0);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.RowCount = 4;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.64219F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.78481F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.78481F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.7882F));
            this.tlpLogin.Size = new System.Drawing.Size(242, 168);
            this.tlpLogin.TabIndex = 0;
            // 
            // lblHeadlineLoginControl
            // 
            this.tlpLogin.SetColumnSpan(this.lblHeadlineLoginControl, 2);
            this.lblHeadlineLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeadlineLoginControl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadlineLoginControl.Location = new System.Drawing.Point(5, 2);
            this.lblHeadlineLoginControl.Name = "lblHeadlineLoginControl";
            this.lblHeadlineLoginControl.Size = new System.Drawing.Size(232, 31);
            this.lblHeadlineLoginControl.TabIndex = 0;
            this.lblHeadlineLoginControl.Text = "Innlogging";
            this.lblHeadlineLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsernameLoginControl
            // 
            this.lblUsernameLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsernameLoginControl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameLoginControl.Location = new System.Drawing.Point(5, 35);
            this.lblUsernameLoginControl.Name = "lblUsernameLoginControl";
            this.lblUsernameLoginControl.Size = new System.Drawing.Size(87, 42);
            this.lblUsernameLoginControl.TabIndex = 1;
            this.lblUsernameLoginControl.Text = "Brukernavn:";
            this.lblUsernameLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPasswordLoginControl
            // 
            this.lblPasswordLoginControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPasswordLoginControl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordLoginControl.Location = new System.Drawing.Point(5, 79);
            this.lblPasswordLoginControl.Name = "lblPasswordLoginControl";
            this.lblPasswordLoginControl.Size = new System.Drawing.Size(87, 42);
            this.lblPasswordLoginControl.TabIndex = 2;
            this.lblPasswordLoginControl.Text = "Passord:";
            this.lblPasswordLoginControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUsernameLoginControl
            // 
            this.tbUsernameLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUsernameLoginControl.Location = new System.Drawing.Point(100, 46);
            this.tbUsernameLoginControl.MaximumSize = new System.Drawing.Size(137, 20);
            this.tbUsernameLoginControl.Name = "tbUsernameLoginControl";
            this.tbUsernameLoginControl.Size = new System.Drawing.Size(137, 20);
            this.tbUsernameLoginControl.TabIndex = 3;
            // 
            // tbPasswordLoginControl
            // 
            this.tbPasswordLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPasswordLoginControl.Location = new System.Drawing.Point(100, 90);
            this.tbPasswordLoginControl.Name = "tbPasswordLoginControl";
            this.tbPasswordLoginControl.Size = new System.Drawing.Size(137, 20);
            this.tbPasswordLoginControl.TabIndex = 4;
            this.tbPasswordLoginControl.UseSystemPasswordChar = true;
            // 
            // btnLoginLoginControl
            // 
            this.btnLoginLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoginLoginControl.Location = new System.Drawing.Point(5, 133);
            this.btnLoginLoginControl.Name = "btnLoginLoginControl";
            this.btnLoginLoginControl.Size = new System.Drawing.Size(87, 23);
            this.btnLoginLoginControl.TabIndex = 5;
            this.btnLoginLoginControl.Text = "Logg inn";
            this.btnLoginLoginControl.UseVisualStyleBackColor = true;
            this.btnLoginLoginControl.Click += new System.EventHandler(this.btnLoginLoginControl_Click);
            // 
            // btnRegisterNewUserLoginControl
            // 
            this.btnRegisterNewUserLoginControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegisterNewUserLoginControl.Location = new System.Drawing.Point(100, 133);
            this.btnRegisterNewUserLoginControl.Name = "btnRegisterNewUserLoginControl";
            this.btnRegisterNewUserLoginControl.Size = new System.Drawing.Size(137, 23);
            this.btnRegisterNewUserLoginControl.TabIndex = 6;
            this.btnRegisterNewUserLoginControl.Text = "Registrer ny bruker";
            this.btnRegisterNewUserLoginControl.UseVisualStyleBackColor = true;
            this.btnRegisterNewUserLoginControl.Click += new System.EventHandler(this.btnRegisterNewUserLoginControl_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpLogin);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(242, 168);
            this.tlpLogin.ResumeLayout(false);
            this.tlpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLogin;
        private System.Windows.Forms.Label lblHeadlineLoginControl;
        private System.Windows.Forms.Label lblUsernameLoginControl;
        private System.Windows.Forms.Label lblPasswordLoginControl;
        private System.Windows.Forms.TextBox tbUsernameLoginControl;
        private System.Windows.Forms.TextBox tbPasswordLoginControl;
        private System.Windows.Forms.Button btnLoginLoginControl;
        private System.Windows.Forms.Button btnRegisterNewUserLoginControl;

    }
}
