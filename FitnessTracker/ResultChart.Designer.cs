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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastCal_txt = new System.Windows.Forms.Label();
            this.totalBurned_txt = new System.Windows.Forms.Label();
            this.moti_label = new System.Windows.Forms.Label();
            this.toBackBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(59, 78);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Calories";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(793, 469);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(966, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Last Goal Calories : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(966, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your Total Burned Calories : ";
            // 
            // lastCal_txt
            // 
            this.lastCal_txt.AutoSize = true;
            this.lastCal_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastCal_txt.Location = new System.Drawing.Point(1266, 192);
            this.lastCal_txt.Name = "lastCal_txt";
            this.lastCal_txt.Size = new System.Drawing.Size(121, 25);
            this.lastCal_txt.TabIndex = 3;
            this.lastCal_txt.Text = "goal calories";
            // 
            // totalBurned_txt
            // 
            this.totalBurned_txt.AutoSize = true;
            this.totalBurned_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBurned_txt.Location = new System.Drawing.Point(1266, 312);
            this.totalBurned_txt.Name = "totalBurned_txt";
            this.totalBurned_txt.Size = new System.Drawing.Size(152, 25);
            this.totalBurned_txt.TabIndex = 4;
            this.totalBurned_txt.Text = "Burned Calories";
            // 
            // moti_label
            // 
            this.moti_label.AutoSize = true;
            this.moti_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moti_label.Location = new System.Drawing.Point(966, 78);
            this.moti_label.Name = "moti_label";
            this.moti_label.Size = new System.Drawing.Size(174, 25);
            this.moti_label.TabIndex = 5;
            this.moti_label.Text = "Motivation Speech";
            // 
            // toBackBtn
            // 
            this.toBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toBackBtn.Location = new System.Drawing.Point(971, 519);
            this.toBackBtn.Name = "toBackBtn";
            this.toBackBtn.Size = new System.Drawing.Size(254, 60);
            this.toBackBtn.TabIndex = 7;
            this.toBackBtn.Text = "Go Back To Main Program";
            this.toBackBtn.UseVisualStyleBackColor = true;
            this.toBackBtn.Click += new System.EventHandler(this.toBackBtn_Click);
            // 
            // ResultChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 657);
            this.Controls.Add(this.toBackBtn);
            this.Controls.Add(this.moti_label);
            this.Controls.Add(this.totalBurned_txt);
            this.Controls.Add(this.lastCal_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "ResultChart";
            this.Text = "ResultChart";
            this.Load += new System.EventHandler(this.ResultChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
    }
}