using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryBattle
{
    partial class FormLeaderboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewScores;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScores;
        private System.Windows.Forms.Label labelTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        // this method is required for designer support - do not modify
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listViewScores = new System.Windows.Forms.ListView();
            this.chartScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartScores)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewScores
            // 
            this.listViewScores.FullRowSelect = true;
            this.listViewScores.GridLines = true;
            this.listViewScores.HideSelection = false;
            this.listViewScores.Location = new System.Drawing.Point(20, 60);
            this.listViewScores.Name = "listViewScores";
            this.listViewScores.Size = new System.Drawing.Size(280, 380);
            this.listViewScores.TabIndex = 0;
            this.listViewScores.UseCompatibleStateImageBehavior = false;
            this.listViewScores.View = System.Windows.Forms.View.Details;
            // 
            // chartScores
            // 
            chartArea1.Name = "ChartArea1";
            this.chartScores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartScores.Legends.Add(legend1);
            this.chartScores.Location = new System.Drawing.Point(320, 60);
            this.chartScores.Name = "chartScores";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Scores";
            this.chartScores.Series.Add(series1);
            this.chartScores.Size = new System.Drawing.Size(460, 380);
            this.chartScores.TabIndex = 1;
            this.chartScores.Text = "chart1";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 16F);
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.Location = new System.Drawing.Point(320, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(167, 32);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Leaderboard";

            // 
            // FormLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.chartScores);
            this.Controls.Add(this.listViewScores);
            this.Name = "FormLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Leaderboard - Memory Battle";
            ((System.ComponentModel.ISupportInitialize)(this.chartScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}