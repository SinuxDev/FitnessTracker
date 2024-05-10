namespace FitnessTracker
{
    partial class forgetPasswordForm
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
            this.reset_link_email = new System.Windows.Forms.TextBox();
            this.send_reset_link = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reset_link_email
            // 
            this.reset_link_email.Location = new System.Drawing.Point(264, 88);
            this.reset_link_email.Name = "reset_link_email";
            this.reset_link_email.Size = new System.Drawing.Size(118, 22);
            this.reset_link_email.TabIndex = 0;
            // 
            // send_reset_link
            // 
            this.send_reset_link.Location = new System.Drawing.Point(264, 176);
            this.send_reset_link.Name = "send_reset_link";
            this.send_reset_link.Size = new System.Drawing.Size(115, 46);
            this.send_reset_link.TabIndex = 1;
            this.send_reset_link.Text = "Send Reset Link";
            this.send_reset_link.UseVisualStyleBackColor = true;
            this.send_reset_link.Click += new System.EventHandler(this.send_reset_link_Click);
            // 
            // forgetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.send_reset_link);
            this.Controls.Add(this.reset_link_email);
            this.Name = "forgetPasswordForm";
            this.Text = "forgetPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reset_link_email;
        private System.Windows.Forms.Button send_reset_link;
    }
}