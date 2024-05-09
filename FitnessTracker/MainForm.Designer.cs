namespace FitnessTracker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exe_ComboList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CaloriesCal_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.setGoals_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.setGoal_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exe_duration_textBox = new System.Windows.Forms.TextBox();
            this.times_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.step_textBox = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DelectGoals_btn = new System.Windows.Forms.Button();
            this.Delete_acti_record_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Result_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(602, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate Your Calories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Your Exercise";
            // 
            // exe_ComboList
            // 
            this.exe_ComboList.FormattingEnabled = true;
            this.exe_ComboList.Items.AddRange(new object[] {
            "Walking",
            "Swimming",
            "Squat",
            "Push up",
            "Pull up",
            "Anaerobic"});
            this.exe_ComboList.Location = new System.Drawing.Point(845, 207);
            this.exe_ComboList.Name = "exe_ComboList";
            this.exe_ComboList.Size = new System.Drawing.Size(121, 24);
            this.exe_ComboList.TabIndex = 2;
            this.exe_ComboList.SelectedIndexChanged += new System.EventHandler(this.exe_ComboList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(603, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Duration(Min)";
            // 
            // CaloriesCal_Btn
            // 
            this.CaloriesCal_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaloriesCal_Btn.Location = new System.Drawing.Point(733, 462);
            this.CaloriesCal_Btn.Name = "CaloriesCal_Btn";
            this.CaloriesCal_Btn.Size = new System.Drawing.Size(125, 52);
            this.CaloriesCal_Btn.TabIndex = 5;
            this.CaloriesCal_Btn.Text = "Calculate";
            this.CaloriesCal_Btn.UseVisualStyleBackColor = true;
            this.CaloriesCal_Btn.Click += new System.EventHandler(this.CaloriesCal_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1634, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 36);
            this.label5.TabIndex = 7;
            this.label5.Text = "Set Your Goals";
            // 
            // setGoals_textbox
            // 
            this.setGoals_textbox.Location = new System.Drawing.Point(286, 206);
            this.setGoals_textbox.Name = "setGoals_textbox";
            this.setGoals_textbox.Size = new System.Drawing.Size(121, 22);
            this.setGoals_textbox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "User Goals Calories";
            // 
            // setGoal_btn
            // 
            this.setGoal_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setGoal_btn.Location = new System.Drawing.Point(167, 266);
            this.setGoal_btn.Name = "setGoal_btn";
            this.setGoal_btn.Size = new System.Drawing.Size(121, 44);
            this.setGoal_btn.TabIndex = 10;
            this.setGoal_btn.Text = "Set Goals";
            this.setGoal_btn.UseVisualStyleBackColor = true;
            this.setGoal_btn.Click += new System.EventHandler(this.setGoal_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 339);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(336, 131);
            this.dataGridView1.TabIndex = 13;
            // 
            // exe_duration_textBox
            // 
            this.exe_duration_textBox.Location = new System.Drawing.Point(845, 265);
            this.exe_duration_textBox.Name = "exe_duration_textBox";
            this.exe_duration_textBox.Size = new System.Drawing.Size(121, 22);
            this.exe_duration_textBox.TabIndex = 14;
            // 
            // times_textBox
            // 
            this.times_textBox.Location = new System.Drawing.Point(845, 320);
            this.times_textBox.Name = "times_textBox";
            this.times_textBox.Size = new System.Drawing.Size(121, 22);
            this.times_textBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(603, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Times";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(603, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Steps";
            // 
            // step_textBox
            // 
            this.step_textBox.Location = new System.Drawing.Point(845, 376);
            this.step_textBox.Name = "step_textBox";
            this.step_textBox.Size = new System.Drawing.Size(121, 22);
            this.step_textBox.TabIndex = 18;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1137, 372);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(463, 185);
            this.dataGridView2.TabIndex = 19;
            // 
            // DelectGoals_btn
            // 
            this.DelectGoals_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelectGoals_btn.Location = new System.Drawing.Point(141, 533);
            this.DelectGoals_btn.Name = "DelectGoals_btn";
            this.DelectGoals_btn.Size = new System.Drawing.Size(147, 48);
            this.DelectGoals_btn.TabIndex = 25;
            this.DelectGoals_btn.Text = "Delete Goals";
            this.DelectGoals_btn.UseVisualStyleBackColor = true;
            this.DelectGoals_btn.Click += new System.EventHandler(this.DelectGoals_btn_Click);
            // 
            // Delete_acti_record_btn
            // 
            this.Delete_acti_record_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_acti_record_btn.Location = new System.Drawing.Point(1301, 604);
            this.Delete_acti_record_btn.Name = "Delete_acti_record_btn";
            this.Delete_acti_record_btn.Size = new System.Drawing.Size(147, 48);
            this.Delete_acti_record_btn.TabIndex = 26;
            this.Delete_acti_record_btn.Text = "Delete Record";
            this.Delete_acti_record_btn.UseVisualStyleBackColor = true;
            this.Delete_acti_record_btn.Click += new System.EventHandler(this.Delete_acti_record_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1685, 47);
            this.panel1.TabIndex = 27;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Logout_btn
            // 
            this.Logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.Location = new System.Drawing.Point(467, 663);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(125, 52);
            this.Logout_btn.TabIndex = 29;
            this.Logout_btn.Text = "Logout";
            this.Logout_btn.UseVisualStyleBackColor = true;
            this.Logout_btn.Click += new System.EventHandler(this.Logout_btn_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1121, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(500, 220);
            this.label11.TabIndex = 30;
            this.label11.Text = "Every drop of\r\nsweat is a step \r\ncloser to your goals\r\nKeep pushing \r\nKeep strivi" +
    "ng\r\nNever give up";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Result_Btn
            // 
            this.Result_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Btn.Location = new System.Drawing.Point(907, 660);
            this.Result_Btn.Name = "Result_Btn";
            this.Result_Btn.Size = new System.Drawing.Size(157, 58);
            this.Result_Btn.TabIndex = 31;
            this.Result_Btn.Text = "Show Results";
            this.Result_Btn.UseVisualStyleBackColor = true;
            this.Result_Btn.Click += new System.EventHandler(this.Result_Btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1679, 776);
            this.Controls.Add(this.Result_Btn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Logout_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Delete_acti_record_btn);
            this.Controls.Add(this.DelectGoals_btn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.step_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.times_textBox);
            this.Controls.Add(this.exe_duration_textBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.setGoal_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.setGoals_textbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CaloriesCal_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exe_ComboList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox exe_ComboList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CaloriesCal_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox setGoals_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button setGoal_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox exe_duration_textBox;
        private System.Windows.Forms.TextBox times_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox step_textBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button DelectGoals_btn;
        private System.Windows.Forms.Button Delete_acti_record_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Result_Btn;
    }
}