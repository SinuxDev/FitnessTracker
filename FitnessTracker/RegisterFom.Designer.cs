﻿namespace FitnessTracker
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
            this.reg_showPass = new System.Windows.Forms.CheckBox();
            this.reg_registerBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reg_loginHere = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reg_firstName = new System.Windows.Forms.TextBox();
            this.reg_lastName = new System.Windows.Forms.TextBox();
            this.reg_email = new System.Windows.Forms.TextBox();
            this.reg_userName = new System.Windows.Forms.TextBox();
            this.reg_confirmPassword = new System.Windows.Forms.TextBox();
            this.reg_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reg_showPass
            // 
            this.reg_showPass.AutoSize = true;
            this.reg_showPass.BackColor = System.Drawing.SystemColors.ControlDark;
            this.reg_showPass.Location = new System.Drawing.Point(461, 585);
            this.reg_showPass.Margin = new System.Windows.Forms.Padding(4);
            this.reg_showPass.Name = "reg_showPass";
            this.reg_showPass.Size = new System.Drawing.Size(151, 24);
            this.reg_showPass.TabIndex = 12;
            this.reg_showPass.Text = "Show Password";
            this.reg_showPass.UseVisualStyleBackColor = false;
            // 
            // reg_registerBtn
            // 
            this.reg_registerBtn.Location = new System.Drawing.Point(292, 609);
            this.reg_registerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reg_registerBtn.Name = "reg_registerBtn";
            this.reg_registerBtn.Size = new System.Drawing.Size(128, 47);
            this.reg_registerBtn.TabIndex = 11;
            this.reg_registerBtn.Text = "SIGNUP";
            this.reg_registerBtn.UseVisualStyleBackColor = true;
            this.reg_registerBtn.Click += new System.EventHandler(this.reg_registerBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email Address";
            // 
            // reg_loginHere
            // 
            this.reg_loginHere.AutoSize = true;
            this.reg_loginHere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg_loginHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_loginHere.Location = new System.Drawing.Point(402, 680);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(131, 680);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Get Started!!";
            // 
            // reg_firstName
            // 
            this.reg_firstName.Location = new System.Drawing.Point(135, 116);
            this.reg_firstName.Name = "reg_firstName";
            this.reg_firstName.Size = new System.Drawing.Size(185, 27);
            this.reg_firstName.TabIndex = 17;
            // 
            // reg_lastName
            // 
            this.reg_lastName.Location = new System.Drawing.Point(406, 116);
            this.reg_lastName.Name = "reg_lastName";
            this.reg_lastName.Size = new System.Drawing.Size(185, 27);
            this.reg_lastName.TabIndex = 18;
            // 
            // reg_email
            // 
            this.reg_email.Location = new System.Drawing.Point(135, 216);
            this.reg_email.Name = "reg_email";
            this.reg_email.Size = new System.Drawing.Size(477, 27);
            this.reg_email.TabIndex = 19;
            // 
            // reg_userName
            // 
            this.reg_userName.Location = new System.Drawing.Point(135, 322);
            this.reg_userName.Name = "reg_userName";
            this.reg_userName.Size = new System.Drawing.Size(477, 27);
            this.reg_userName.TabIndex = 20;
            // 
            // reg_confirmPassword
            // 
            this.reg_confirmPassword.Location = new System.Drawing.Point(135, 524);
            this.reg_confirmPassword.Name = "reg_confirmPassword";
            this.reg_confirmPassword.Size = new System.Drawing.Size(477, 27);
            this.reg_confirmPassword.TabIndex = 24;
            // 
            // reg_password
            // 
            this.reg_password.Location = new System.Drawing.Point(135, 418);
            this.reg_password.Name = "reg_password";
            this.reg_password.Size = new System.Drawing.Size(477, 27);
            this.reg_password.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(131, 479);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Confirm Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(131, 382);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(131, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "First Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(402, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Last Name";
            // 
            // RegisterFom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 746);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.reg_confirmPassword);
            this.Controls.Add(this.reg_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.reg_userName);
            this.Controls.Add(this.reg_email);
            this.Controls.Add(this.reg_lastName);
            this.Controls.Add(this.reg_firstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reg_loginHere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reg_showPass);
            this.Controls.Add(this.reg_registerBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterFom";
            this.Text = "RegisterFom";
            this.Load += new System.EventHandler(this.RegisterFom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reg_registerBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label reg_loginHere;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox reg_showPass;
        private System.Windows.Forms.TextBox reg_firstName;
        private System.Windows.Forms.TextBox reg_lastName;
        private System.Windows.Forms.TextBox reg_email;
        private System.Windows.Forms.TextBox reg_userName;
        private System.Windows.Forms.TextBox reg_confirmPassword;
        private System.Windows.Forms.TextBox reg_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}