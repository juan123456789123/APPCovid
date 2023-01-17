namespace WindowsFormsApp1
{
    partial class FrmEstadistica
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDona = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOpcEstadistica = new System.Windows.Forms.ComboBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDona)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartBarras
            // 
            this.chartBarras.BackColor = System.Drawing.Color.Transparent;
            this.chartBarras.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartBarras.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartBarras.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBarras.Legends.Add(legend1);
            this.chartBarras.Location = new System.Drawing.Point(58, 221);
            this.chartBarras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartBarras.Name = "chartBarras";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBarras.Series.Add(series1);
            this.chartBarras.Size = new System.Drawing.Size(1083, 531);
            this.chartBarras.TabIndex = 0;
            this.chartBarras.Text = "chart1";
            // 
            // chartDona
            // 
            this.chartDona.BackColor = System.Drawing.Color.Transparent;
            this.chartDona.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartDona.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartDona.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDona.Legends.Add(legend2);
            this.chartDona.Location = new System.Drawing.Point(236, 227);
            this.chartDona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartDona.Name = "chartDona";
            this.chartDona.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.BackSecondaryColor = System.Drawing.Color.Transparent;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDona.Series.Add(series2);
            this.chartDona.Size = new System.Drawing.Size(731, 488);
            this.chartDona.TabIndex = 1;
            this.chartDona.Text = "chart2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 124);
            this.panel2.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Ebrima", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(50, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "ESTADISTICAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(104, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Elija el tipo de estadistica:";
            // 
            // comboBoxOpcEstadistica
            // 
            this.comboBoxOpcEstadistica.FormattingEnabled = true;
            this.comboBoxOpcEstadistica.Location = new System.Drawing.Point(388, 185);
            this.comboBoxOpcEstadistica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxOpcEstadistica.Name = "comboBoxOpcEstadistica";
            this.comboBoxOpcEstadistica.Size = new System.Drawing.Size(389, 28);
            this.comboBoxOpcEstadistica.TabIndex = 21;
            this.comboBoxOpcEstadistica.SelectionChangeCommitted += new System.EventHandler(this.comboBoxOpcEstadistica_SelectionChangeCommitted);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(959, 543);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(8, 8);
            this.iconButton1.TabIndex = 22;
            this.iconButton1.Text = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // FrmEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 765);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.comboBoxOpcEstadistica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chartDona);
            this.Controls.Add(this.chartBarras);
            this.ForeColor = System.Drawing.Color.Lavender;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmEstadistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEsta";
            this.Load += new System.EventHandler(this.FrmEsta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDona)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxOpcEstadistica;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartDona;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}