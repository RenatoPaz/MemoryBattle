using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MemoryBattle.Details;

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
            ApplyColorScheme();
            LoadMockData();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
            LoadMockData(); // Reload to apply new colors to chart
        }

        private void ApplyColorScheme()
        {
            // Apply color scheme to all controls
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorSchemeManager.ButtonBackground;
                    button.ForeColor = ColorSchemeManager.ButtonForeground;
                }
                else if (control is Label label)
                {
                    label.ForeColor = ColorSchemeManager.LabelForeground;
                }
                else if (control is ListView listView)
                {
                    listView.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                        ColorSchemeManager.CardRevealed : Color.White;
                    listView.ForeColor = Color.Black;
                }
            }

            // Handle chart colors
            if (chartScores != null)
            {
                chartScores.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                    ColorSchemeManager.FormBackground : Color.White;

                // Update chart area background
                if (chartScores.ChartAreas.Count > 0)
                {
                    chartScores.ChartAreas[0].BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                        ColorSchemeManager.FormBackground : Color.White;
                }
            }

            // Handle background
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
            }
            else
            {

            }

            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
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

            // Color-blind friendly chart colors
            Color[] barColors;
            Color[] legendColors;

            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                // Use patterns and high contrast colors safe for color-blind users
                barColors = new Color[]
                {
                    Color.FromArgb(0, 0, 139),      // Dark Blue (1st)
                    Color.FromArgb(25, 25, 112),    // Midnight Blue (2nd)  
                    Color.FromArgb(70, 130, 180),   // Steel Blue (3rd)
                    Color.FromArgb(105, 105, 105),  // Dim Gray (4th)
                    Color.FromArgb(169, 169, 169)   // Dark Gray (5th)
                };
                legendColors = barColors;
            }
            else
            {
                // Original colors for regular mode
                barColors = new Color[]
                {
                    Color.Gold,
                    Color.Silver,
                    Color.SandyBrown,
                    Color.CornflowerBlue,
                    Color.MediumPurple
                };
                legendColors = barColors;
            }

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
            customLegend.TitleForeColor = ColorSchemeManager.LabelForeground;
            customLegend.ForeColor = ColorSchemeManager.LabelForeground;
            customLegend.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                ColorSchemeManager.FormBackground : Color.Transparent;
            customLegend.Docking = Docking.Right;

            // Legend items with appropriate labels for color-blind mode
            string[] rankLabels = ColorSchemeManager.IsColorBlindFriendly ?
                new[] { "1st Place (Dark Blue)", "2nd Place (Mid Blue)", "3rd Place (Steel Blue)", "4th Place (Dark Gray)", "5th Place (Light Gray)" } :
                new[] { "1st Place", "2nd Place", "3rd Place", "4th Place", "5th Place" };

            for (int i = 0; i < legendColors.Length; i++)
            {
                customLegend.CustomItems.Add(new LegendItem()
                {
                    Name = rankLabels[i],
                    Color = legendColors[i],
                    ImageStyle = LegendImageStyle.Rectangle
                });
            }

            // this adds the custom legend to the chart
            chartScores.Legends.Add(customLegend);
            chartScores.Series["Scores"].Legend = "RankLegend";
        }
    }
}