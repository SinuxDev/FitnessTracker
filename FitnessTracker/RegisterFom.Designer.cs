namespace FitnessTracker
{
    partial class RegisterFom
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
            this.reg_registerBtn = new System.Windows.Forms.Button();
            this.reg_loginHere = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reg_firstName = new System.Windows.Forms.TextBox();
            this.reg_lastName = new System.Windows.Forms.TextBox();
            this.reg_email = new System.Windows.Forms.TextBox();
            this.reg_userName = new System.Windows.Forms.TextBox();
            this.reg_confirmPassword = new System.Windows.Forms.TextBox();
            this.reg_password = new System.Windows.Forms.TextBox();
            this.reg_closeLabelClick = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Reg_showPassword_checkBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reg_registerBtn
            // 
            this.reg_registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_registerBtn.Location = new System.Drawing.Point(250, 524);
            this.reg_registerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reg_registerBtn.Name = "reg_registerBtn";
            this.reg_registerBtn.Size = new System.Drawing.Size(207, 47);
            this.reg_registerBtn.TabIndex = 11;
            this.reg_registerBtn.Text = "Create Your Account";
            this.reg_registerBtn.UseVisualStyleBackColor = true;
            this.reg_registerBtn.Click += new System.EventHandler(this.reg_registerBtn_Click);
            // 
            // reg_loginHere
            // 
            this.reg_loginHere.AutoSize = true;
            this.reg_loginHere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg_loginHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_loginHere.Location = new System.Drawing.Point(425, 619);
            this.reg_loginHere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reg_loginHere.Name = "reg_loginHere";
            this.reg_loginHere.Size = new System.Drawing.Size(98, 22);
            this.reg_loginHere.TabIndex = 14;
            this.reg_loginHere.Text = "Login Here";
            this.reg_loginHere.Click += new System.EventHandler(this.reg_loginHere_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(132, 619);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Already have an account ? ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.No;
            this.label1.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "Create Your Fitness Tracker Account";
            // 
            // reg_firstName
            // 
            this.reg_firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_firstName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_firstName.Location = new System.Drawing.Point(119, 171);
            this.reg_firstName.Name = "reg_firstName";
            this.reg_firstName.Size = new System.Drawing.Size(185, 27);
            this.reg_firstName.TabIndex = 200;
            this.reg_firstName.Text = "first name";
            this.reg_firstName.TextChanged += new System.EventHandler(this.reg_firstName_TextChanged);
            this.reg_firstName.Enter += new System.EventHandler(this.reg_firstName_Enter);
            this.reg_firstName.Leave += new System.EventHandler(this.reg_firstName_Leave);
            // 
            // reg_lastName
            // 
            this.reg_lastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_lastName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_lastName.Location = new System.Drawing.Point(411, 171);
            this.reg_lastName.Name = "reg_lastName";
            this.reg_lastName.Size = new System.Drawing.Size(185, 27);
            this.reg_lastName.TabIndex = 18;
            this.reg_lastName.Text = "last name";
            this.reg_lastName.Enter += new System.EventHandler(this.reg_lastName_Enter);
            this.reg_lastName.Leave += new System.EventHandler(this.reg_lastName_Leave);
            // 
            // reg_email
            // 
            this.reg_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_email.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_email.Location = new System.Drawing.Point(119, 226);
            this.reg_email.Name = "reg_email";
            this.reg_email.Size = new System.Drawing.Size(477, 27);
            this.reg_email.TabIndex = 19;
            this.reg_email.Text = "email address";
            this.reg_email.Enter += new System.EventHandler(this.reg_email_Enter);
            this.reg_email.Leave += new System.EventHandler(this.reg_email_Leave);
            // 
            // reg_userName
            // 
            this.reg_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_userName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_userName.Location = new System.Drawing.Point(119, 293);
            this.reg_userName.Name = "reg_userName";
            this.reg_userName.Size = new System.Drawing.Size(477, 27);
            this.reg_userName.TabIndex = 20;
            this.reg_userName.Text = "username";
            this.reg_userName.Enter += new System.EventHandler(this.reg_userName_Enter);
            this.reg_userName.Leave += new System.EventHandler(this.reg_userName_Leave);
            // 
            // reg_confirmPassword
            // 
            this.reg_confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_confirmPassword.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_confirmPassword.Location = new System.Drawing.Point(119, 422);
            this.reg_confirmPassword.Name = "reg_confirmPassword";
            this.reg_confirmPassword.Size = new System.Drawing.Size(477, 27);
            this.reg_confirmPassword.TabIndex = 24;
            this.reg_confirmPassword.Text = "confirm password";
            this.reg_confirmPassword.Enter += new System.EventHandler(this.reg_confirmPassword_Enter);
            this.reg_confirmPassword.Leave += new System.EventHandler(this.reg_confirmPassword_Leave);
            // 
            // reg_password
            // 
            this.reg_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_password.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reg_password.Location = new System.Drawing.Point(119, 356);
            this.reg_password.Name = "reg_password";
            this.reg_password.Size = new System.Drawing.Size(477, 27);
            this.reg_password.TabIndex = 23;
            this.reg_password.Text = "password";
            this.reg_password.Enter += new System.EventHandler(this.reg_password_Enter);
            this.reg_password.Leave += new System.EventHandler(this.reg_password_Leave);
            // 
            // reg_closeLabelClick
            // 
            this.reg_closeLabelClick.AutoSize = true;
            this.reg_closeLabelClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg_closeLabelClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_closeLabelClick.Location = new System.Drawing.Point(701, 9);
            this.reg_closeLabelClick.Name = "reg_closeLabelClick";
            this.reg_closeLabelClick.Size = new System.Drawing.Size(33, 32);
            this.reg_closeLabelClick.TabIndex = 201;
            this.reg_closeLabelClick.Text = "X";
            this.reg_closeLabelClick.Click += new System.EventHandler(this.reg_closeLabelClick_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.reg_closeLabelClick);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 53);
            this.panel1.TabIndex = 202;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Reg_showPassword_checkBox
            // 
            this.Reg_showPassword_checkBox.AutoSize = true;
            this.Reg_showPassword_checkBox.Location = new System.Drawing.Point(449, 476);
            this.Reg_showPassword_checkBox.Name = "Reg_showPassword_checkBox";
            this.Reg_showPassword_checkBox.Size = new System.Drawing.Size(147, 24);
            this.Reg_showPassword_checkBox.TabIndex = 203;
            this.Reg_showPassword_checkBox.Text = "show password";
            this.Reg_showPassword_checkBox.UseVisualStyleBackColor = true;
            this.Reg_showPassword_checkBox.CheckedChanged += new System.EventHandler(this.Reg_showPassword_checkBox_CheckedChanged);
            // 
            // RegisterFom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(746, 710);
            this.Controls.Add(this.Reg_showPassword_checkBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reg_confirmPassword);
            this.Controls.Add(this.reg_password);
            this.Controls.Add(this.reg_userName);
            this.Controls.Add(this.reg_email);
            this.Controls.Add(this.reg_lastName);
            this.Controls.Add(this.reg_firstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reg_loginHere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reg_registerBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterFom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterFom";
            this.Load += new System.EventHandler(this.RegisterFom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reg_registerBtn;
        private System.Windows.Forms.Label reg_loginHere;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reg_firstName;
        private System.Windows.Forms.TextBox reg_lastName;
        private System.Windows.Forms.TextBox reg_email;
        private System.Windows.Forms.TextBox reg_userName;
        private System.Windows.Forms.TextBox reg_confirmPassword;
        private System.Windows.Forms.TextBox reg_password;
        private System.Windows.Forms.Label reg_closeLabelClick;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox Reg_showPassword_checkBox;
    }
}