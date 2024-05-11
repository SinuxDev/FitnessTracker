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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.user_goals_dataGrid = new System.Windows.Forms.DataGridView();
            this.exe_weight_textBox = new System.Windows.Forms.TextBox();
            this.repetitions_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.times_textBox = new System.Windows.Forms.TextBox();
            this.DelectGoals_btn = new System.Windows.Forms.Button();
            this.Delete_acti_record_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Result_Btn = new System.Windows.Forms.Button();
            this.user_recordActivities_DGV = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.user_goals_dataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_recordActivities_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1328, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate Your Calories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1276, 175);
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
            this.exe_ComboList.Location = new System.Drawing.Point(1300, 235);
            this.exe_ComboList.Name = "exe_ComboList";
            this.exe_ComboList.Size = new System.Drawing.Size(150, 24);
            this.exe_ComboList.TabIndex = 2;
            this.exe_ComboList.SelectedIndexChanged += new System.EventHandler(this.exe_ComboList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1592, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Weight";
            // 
            // CaloriesCal_Btn
            // 
            this.CaloriesCal_Btn.BackColor = System.Drawing.Color.FloralWhite;
            this.CaloriesCal_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CaloriesCal_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaloriesCal_Btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CaloriesCal_Btn.Location = new System.Drawing.Point(1427, 440);
            this.CaloriesCal_Btn.Name = "CaloriesCal_Btn";
            this.CaloriesCal_Btn.Size = new System.Drawing.Size(166, 61);
            this.CaloriesCal_Btn.TabIndex = 5;
            this.CaloriesCal_Btn.Text = "Calculate Calories";
            this.CaloriesCal_Btn.UseVisualStyleBackColor = false;
            this.CaloriesCal_Btn.Click += new System.EventHandler(this.CaloriesCal_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1725, 9);
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
            this.setGoals_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setGoals_textbox.Location = new System.Drawing.Point(286, 206);
            this.setGoals_textbox.Name = "setGoals_textbox";
            this.setGoals_textbox.Size = new System.Drawing.Size(143, 22);
            this.setGoals_textbox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "User Goals Calories";
            // 
            // setGoal_btn
            // 
            this.setGoal_btn.BackColor = System.Drawing.Color.FloralWhite;
            this.setGoal_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setGoal_btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.setGoal_btn.Location = new System.Drawing.Point(158, 283);
            this.setGoal_btn.Name = "setGoal_btn";
            this.setGoal_btn.Size = new System.Drawing.Size(130, 53);
            this.setGoal_btn.TabIndex = 10;
            this.setGoal_btn.Text = "Set Goals";
            this.setGoal_btn.UseVisualStyleBackColor = false;
            this.setGoal_btn.Click += new System.EventHandler(this.setGoal_btn_Click);
            // 
            // user_goals_dataGrid
            // 
            this.user_goals_dataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray;
            this.user_goals_dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.user_goals_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.user_goals_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_goals_dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.user_goals_dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.user_goals_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_goals_dataGrid.Location = new System.Drawing.Point(59, 463);
            this.user_goals_dataGrid.Name = "user_goals_dataGrid";
            this.user_goals_dataGrid.RowHeadersWidth = 51;
            this.user_goals_dataGrid.RowTemplate.Height = 24;
            this.user_goals_dataGrid.Size = new System.Drawing.Size(358, 175);
            this.user_goals_dataGrid.TabIndex = 13;
            // 
            // exe_weight_textBox
            // 
            this.exe_weight_textBox.Location = new System.Drawing.Point(1572, 235);
            this.exe_weight_textBox.Name = "exe_weight_textBox";
            this.exe_weight_textBox.Size = new System.Drawing.Size(150, 22);
            this.exe_weight_textBox.TabIndex = 14;
            // 
            // repetitions_textBox
            // 
            this.repetitions_textBox.Location = new System.Drawing.Point(1572, 345);
            this.repetitions_textBox.Name = "repetitions_textBox";
            this.repetitions_textBox.Size = new System.Drawing.Size(150, 22);
            this.repetitions_textBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1314, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Times(Min)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1592, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Repetitions";
            // 
            // times_textBox
            // 
            this.times_textBox.Location = new System.Drawing.Point(1300, 345);
            this.times_textBox.Name = "times_textBox";
            this.times_textBox.Size = new System.Drawing.Size(150, 22);
            this.times_textBox.TabIndex = 18;
            // 
            // DelectGoals_btn
            // 
            this.DelectGoals_btn.BackColor = System.Drawing.Color.FloralWhite;
            this.DelectGoals_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelectGoals_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelectGoals_btn.ForeColor = System.Drawing.Color.Red;
            this.DelectGoals_btn.Location = new System.Drawing.Point(131, 685);
            this.DelectGoals_btn.Name = "DelectGoals_btn";
            this.DelectGoals_btn.Size = new System.Drawing.Size(198, 61);
            this.DelectGoals_btn.TabIndex = 25;
            this.DelectGoals_btn.Text = "Delete User\'s Goals";
            this.DelectGoals_btn.UseVisualStyleBackColor = false;
            this.DelectGoals_btn.Click += new System.EventHandler(this.DelectGoals_btn_Click);
            // 
            // Delete_acti_record_btn
            // 
            this.Delete_acti_record_btn.BackColor = System.Drawing.Color.FloralWhite;
            this.Delete_acti_record_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Delete_acti_record_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_acti_record_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_acti_record_btn.ForeColor = System.Drawing.Color.Red;
            this.Delete_acti_record_btn.Location = new System.Drawing.Point(762, 679);
            this.Delete_acti_record_btn.Name = "Delete_acti_record_btn";
            this.Delete_acti_record_btn.Size = new System.Drawing.Size(232, 73);
            this.Delete_acti_record_btn.TabIndex = 26;
            this.Delete_acti_record_btn.Text = "Delete User\'s Records";
            this.Delete_acti_record_btn.UseVisualStyleBackColor = false;
            this.Delete_acti_record_btn.Click += new System.EventHandler(this.Delete_acti_record_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1771, 47);
            this.panel1.TabIndex = 27;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Logout_btn
            // 
            this.Logout_btn.BackColor = System.Drawing.Color.FloralWhite;
            this.Logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.ForeColor = System.Drawing.Color.Red;
            this.Logout_btn.Location = new System.Drawing.Point(1572, 786);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(135, 58);
            this.Logout_btn.TabIndex = 29;
            this.Logout_btn.Text = "Logout";
            this.Logout_btn.UseVisualStyleBackColor = false;
            this.Logout_btn.Click += new System.EventHandler(this.Logout_btn_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(620, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(500, 226);
            this.label11.TabIndex = 30;
            this.label11.Text = "Every drop of\r\nsweat is a step \r\ncloser to your goals\r\nKeep pushing \r\nKeep strivi" +
    "ng\r\nNever give up";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Result_Btn
            // 
            this.Result_Btn.BackColor = System.Drawing.Color.FloralWhite;
            this.Result_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Result_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Result_Btn.Location = new System.Drawing.Point(1319, 786);
            this.Result_Btn.Name = "Result_Btn";
            this.Result_Btn.Size = new System.Drawing.Size(157, 58);
            this.Result_Btn.TabIndex = 31;
            this.Result_Btn.Text = "Show Results";
            this.Result_Btn.UseVisualStyleBackColor = false;
            this.Result_Btn.Click += new System.EventHandler(this.Result_Btn_Click);
            // 
            // user_recordActivities_DGV
            // 
            this.user_recordActivities_DGV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gray;
            this.user_recordActivities_DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.user_recordActivities_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.user_recordActivities_DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_recordActivities_DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.user_recordActivities_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.user_recordActivities_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_recordActivities_DGV.Location = new System.Drawing.Point(567, 463);
            this.user_recordActivities_DGV.Name = "user_recordActivities_DGV";
            this.user_recordActivities_DGV.RowHeadersWidth = 51;
            this.user_recordActivities_DGV.RowTemplate.Height = 24;
            this.user_recordActivities_DGV.Size = new System.Drawing.Size(651, 175);
            this.user_recordActivities_DGV.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(708, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(375, 32);
            this.label7.TabIndex = 33;
            this.label7.Text = "Your Activity Record Table";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(109, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 25);
            this.label10.TabIndex = 34;
            this.label10.Text = "Your User Goal Record";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1770, 870);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.user_recordActivities_DGV);
            this.Controls.Add(this.Result_Btn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Logout_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Delete_acti_record_btn);
            this.Controls.Add(this.DelectGoals_btn);
            this.Controls.Add(this.times_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.repetitions_textBox);
            this.Controls.Add(this.exe_weight_textBox);
            this.Controls.Add(this.user_goals_dataGrid);
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
            ((System.ComponentModel.ISupportInitialize)(this.user_goals_dataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_recordActivities_DGV)).EndInit();
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
        private System.Windows.Forms.DataGridView user_goals_dataGrid;
        private System.Windows.Forms.TextBox exe_weight_textBox;
        private System.Windows.Forms.TextBox repetitions_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox times_textBox;
        private System.Windows.Forms.Button DelectGoals_btn;
        private System.Windows.Forms.Button Delete_acti_record_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Result_Btn;
        private System.Windows.Forms.DataGridView user_recordActivities_DGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
    }
}