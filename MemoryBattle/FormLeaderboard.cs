using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// add > references > system.windows.forms.datavisualization.charting is a library that for charting and graphing controls.
// referenced: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datavisualization.charting?view=netframework-4.8.1
// chart types can be modified in the ChartType property. Can be Bar, Column, Line, Pie, etc.
namespace MemoryBattle
{
    public partial class FormLeaderboard : Form
    {
        public FormLeaderboard()
        {
            InitializeComponent();
            InitializeListViewColumns();
            LoadMockData();
        }

        private void InitializeListViewColumns()
        {
            // Add columns to ListView if they don't exist
            if (listViewScores.Columns.Count == 0)
            {
                listViewScores.Columns.Add("Rank", 60);
                listViewScores.Columns.Add("Player", 120);
                listViewScores.Columns.Add("Score", 80);
            }
        }

        private void LoadMockData()
        {
            // this is temp data for the graph
            // we can implement actual data later through a seperate class that handles data storage and retrieval.
            // scores that come from the game in FormGame.cs can be saved to a seperate class that manages the leaderboard data,
            // then can be loaded in a form like this intead of using mock data.
            var scores = new[]
            {
                new { Player = "Alice", Score = 2500 },
                new { Player = "Bob", Score = 2100 },
                new { Player = "Charlie", Score = 1800 },
                new { Player = "Diana", Score = 1500 },
                new { Player = "Eve", Score = 1200 }
            };

            // this is for the bars in the graph, each bar is color coordinated.
            Color[] barColors = new Color[]
            {
                Color.Gold,
                Color.Silver,
                Color.SandyBrown,
                Color.CornflowerBlue,
                Color.MediumPurple
            };

            // populate ListView with rank, player name, and score data
            listViewScores.Items.Clear();
            int rank = 1;
            foreach (var score in scores)
            {
                var item = new ListViewItem(rank.ToString());
                item.SubItems.Add(score.Player);
                item.SubItems.Add(score.Score.ToString());
                listViewScores.Items.Add(item);
                rank++;
            }

            // this will populate the chart with the scores and apply the colors.
            chartScores.Series["Scores"].Points.Clear();
            chartScores.Series["Scores"].IsVisibleInLegend = false;

            int colorIndex = 0;
            foreach (var score in scores)
            {
                var point = chartScores.Series["Scores"].Points.AddXY(score.Player, score.Score);
                chartScores.Series["Scores"].Points[point].Color = barColors[colorIndex % barColors.Length];
                colorIndex++;
            }

            // this is the custom legend
            chartScores.Legends.Clear();

            Legend customLegend = new Legend("RankLegend");
            customLegend.Title = "Rank Colors";
            customLegend.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            customLegend.Docking = Docking.Right;

            // color coordinated 1st place to 5th, can adjust if only 3 places are used.
            customLegend.CustomItems.Add(new LegendItem()
            {
                Name = "1st Place",
                Color = Color.Gold,
                ImageStyle = LegendImageStyle.Rectangle
            });
            customLegend.CustomItems.Add(new LegendItem()
            {
                Name = "2nd Place",
                Color = Color.Silver,
                ImageStyle = LegendImageStyle.Rectangle
            });
            customLegend.CustomItems.Add(new LegendItem()
            {
                Name = "3rd Place",
                Color = Color.SandyBrown,
                ImageStyle = LegendImageStyle.Rectangle
            });
            customLegend.CustomItems.Add(new LegendItem()
            {
                Name = "4th Place",
                Color = Color.CornflowerBlue,
                ImageStyle = LegendImageStyle.Rectangle
            });
            customLegend.CustomItems.Add(new LegendItem()
            {
                Name = "5th Place",
                Color = Color.MediumPurple,
                ImageStyle = LegendImageStyle.Rectangle
            });

            // this adds the custom legend to the chart
            chartScores.Legends.Add(customLegend);
            chartScores.Series["Scores"].Legend = "RankLegend";
        }
    }
}