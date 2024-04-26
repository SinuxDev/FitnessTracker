namespace FitnessTracker
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.login_username = new System.Windows.Forms.TextBox();
            this.login_password = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.login_registerHere = new System.Windows.Forms.Label();
            this.login_closeLableClick = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Login_showPassword_checkBox = new System.Windows.Forms.CheckBox();
            this.attemptLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.No;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign In to Your Fitness Tracker Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // login_username
            // 
            this.login_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_username.Location = new System.Drawing.Point(361, 147);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(227, 27);
            this.login_username.TabIndex = 3;
            // 
            // login_password
            // 
            this.login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password.Location = new System.Drawing.Point(361, 213);
            this.login_password.Name = "login_password";
            this.login_password.PasswordChar = '*';
            this.login_password.Size = new System.Drawing.Size(227, 27);
            this.login_password.TabIndex = 4;
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.Location = new System.Drawing.Point(361, 345);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(131, 55);
            this.login_btn.TabIndex = 5;
            this.login_btn.Text = "LOGIN";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(127, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Don\'t have an account ? ";
            // 
            // login_registerHere
            // 
            this.login_registerHere.AutoSize = true;
            this.login_registerHere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_registerHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_registerHere.Location = new System.Drawing.Point(476, 513);
            this.login_registerHere.Name = "login_registerHere";
            this.login_registerHere.Size = new System.Drawing.Size(163, 29);
            this.login_registerHere.TabIndex = 8;
            this.login_registerHere.Text = "Register Here";
            this.login_registerHere.Click += new System.EventHandler(this.login_registerHere_Click);
            // 
            // login_closeLableClick
            // 
            this.login_closeLableClick.AutoSize = true;
            this.login_closeLableClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_closeLableClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_closeLableClick.Location = new System.Drawing.Point(787, 9);
            this.login_closeLableClick.Name = "login_closeLableClick";
            this.login_closeLableClick.Size = new System.Drawing.Size(33, 32);
            this.login_closeLableClick.TabIndex = 9;
            this.login_closeLableClick.Text = "X";
            this.login_closeLableClick.Click += new System.EventHandler(this.login_closeLableClick_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.login_closeLableClick);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 45);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Login_showPassword_checkBox
            // 
            this.Login_showPassword_checkBox.AutoSize = true;
            this.Login_showPassword_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_showPassword_checkBox.Location = new System.Drawing.Point(441, 272);
            this.Login_showPassword_checkBox.Name = "Login_showPassword_checkBox";
            this.Login_showPassword_checkBox.Size = new System.Drawing.Size(156, 26);
            this.Login_showPassword_checkBox.TabIndex = 11;
            this.Login_showPassword_checkBox.Text = "show password";
            this.Login_showPassword_checkBox.UseVisualStyleBackColor = true;
            this.Login_showPassword_checkBox.CheckedChanged += new System.EventHandler(this.Login_showPassword_checkBox_CheckedChanged);
            // 
            // attemptLabel
            // 
            this.attemptLabel.AutoSize = true;
            this.attemptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attemptLabel.ForeColor = System.Drawing.Color.Red;
            this.attemptLabel.Location = new System.Drawing.Point(111, 444);
            this.attemptLabel.Name = "attemptLabel";
            this.attemptLabel.Size = new System.Drawing.Size(148, 22);
            this.attemptLabel.TabIndex = 12;
            this.attemptLabel.Text = "Attempt Message";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(836, 602);
            this.Controls.Add(this.attemptLabel);
            this.Controls.Add(this.Login_showPassword_checkBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.login_registerHere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label login_registerHere;
        private System.Windows.Forms.Label login_closeLableClick;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox Login_showPassword_checkBox;
        private System.Windows.Forms.Label attemptLabel;
    }
}

