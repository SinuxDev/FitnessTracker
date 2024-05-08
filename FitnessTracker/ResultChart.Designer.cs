namespace FitnessTracker
{
    partial class ResultChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastCal_txt = new System.Windows.Forms.Label();
            this.totalBurned_txt = new System.Windows.Forms.Label();
            this.moti_label = new System.Windows.Forms.Label();
            this.toBackBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.show_userName = new System.Windows.Forms.Label();
            this.show_eamiladdress = new System.Windows.Forms.Label();
            this.logOut_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(712, 102);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Legend = "Legend1";
            series3.Name = "Calories";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(662, 409);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Last Goal Calories : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 631);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your Total Burned Calories : ";
            // 
            // lastCal_txt
            // 
            this.lastCal_txt.AutoSize = true;
            this.lastCal_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastCal_txt.Location = new System.Drawing.Point(419, 543);
            this.lastCal_txt.Name = "lastCal_txt";
            this.lastCal_txt.Size = new System.Drawing.Size(151, 29);
            this.lastCal_txt.TabIndex = 3;
            this.lastCal_txt.Text = "goal calories";
            // 
            // totalBurned_txt
            // 
            this.totalBurned_txt.AutoSize = true;
            this.totalBurned_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBurned_txt.Location = new System.Drawing.Point(419, 631);
            this.totalBurned_txt.Name = "totalBurned_txt";
            this.totalBurned_txt.Size = new System.Drawing.Size(187, 29);
            this.totalBurned_txt.TabIndex = 4;
            this.totalBurned_txt.Text = "Burned Calories";
            // 
            // moti_label
            // 
            this.moti_label.AutoSize = true;
            this.moti_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moti_label.Location = new System.Drawing.Point(21, 462);
            this.moti_label.Name = "moti_label";
            this.moti_label.Size = new System.Drawing.Size(211, 29);
            this.moti_label.TabIndex = 5;
            this.moti_label.Text = "Motivation Speech";
            // 
            // toBackBtn
            // 
            this.toBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toBackBtn.Location = new System.Drawing.Point(712, 597);
            this.toBackBtn.Name = "toBackBtn";
            this.toBackBtn.Size = new System.Drawing.Size(301, 63);
            this.toBackBtn.TabIndex = 7;
            this.toBackBtn.Text = "Click To Calculate Your Calories";
            this.toBackBtn.UseVisualStyleBackColor = true;
            this.toBackBtn.Click += new System.EventHandler(this.toBackBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 44);
            this.panel1.TabIndex = 27;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1396, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 39);
            this.label4.TabIndex = 28;
            this.label4.Text = "Your Profile Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Username : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(123, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "Email : ";
            // 
            // show_userName
            // 
            this.show_userName.AutoSize = true;
            this.show_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_userName.Location = new System.Drawing.Point(242, 206);
            this.show_userName.Name = "show_userName";
            this.show_userName.Size = new System.Drawing.Size(185, 29);
            this.show_userName.TabIndex = 31;
            this.show_userName.Text = "info_username";
            // 
            // show_eamiladdress
            // 
            this.show_eamiladdress.AutoSize = true;
            this.show_eamiladdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_eamiladdress.Location = new System.Drawing.Point(242, 297);
            this.show_eamiladdress.Name = "show_eamiladdress";
            this.show_eamiladdress.Size = new System.Drawing.Size(248, 29);
            this.show_eamiladdress.TabIndex = 32;
            this.show_eamiladdress.Text = "show_emailAddress";
            // 
            // logOut_btn
            // 
            this.logOut_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut_btn.Location = new System.Drawing.Point(1237, 597);
            this.logOut_btn.Name = "logOut_btn";
            this.logOut_btn.Size = new System.Drawing.Size(137, 63);
            this.logOut_btn.TabIndex = 33;
            this.logOut_btn.Text = "Logout";
            this.logOut_btn.UseVisualStyleBackColor = true;
            this.logOut_btn.Click += new System.EventHandler(this.logOut_btn_Click);
            // 
            // ResultChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1441, 749);
            this.Controls.Add(this.logOut_btn);
            this.Controls.Add(this.show_eamiladdress);
            this.Controls.Add(this.show_userName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toBackBtn);
            this.Controls.Add(this.moti_label);
            this.Controls.Add(this.totalBurned_txt);
            this.Controls.Add(this.lastCal_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultChart";
            this.Load += new System.EventHandler(this.ResultChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lastCal_txt;
        private System.Windows.Forms.Label totalBurned_txt;
        private System.Windows.Forms.Label moti_label;
        private System.Windows.Forms.Button toBackBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label show_userName;
        private System.Windows.Forms.Label show_eamiladdress;
        private System.Windows.Forms.Button logOut_btn;
    }
}