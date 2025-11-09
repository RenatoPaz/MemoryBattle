using System;
using System.Drawing;
using System.Windows.Forms;
using MemoryBattle.Details;

namespace MemoryBattle
{
    public partial class FormHowToPlay : Form
    {
        public FormHowToPlay()
        {
            InitializeComponent();
            ApplyColorScheme();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
        }

        private void ApplyColorScheme()
        {
            // Apply color scheme to all controls recursively
            ApplyColorSchemeToControl(this);

            // Handle background
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
            }

            this.Invalidate();
        }

        private void ApplyColorSchemeToControl(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorSchemeManager.ButtonBackground;
                    button.ForeColor = ColorSchemeManager.ButtonForeground;
                }
                else if (control is Label label)
                {
                    label.ForeColor = ColorSchemeManager.LabelForeground;
                    // Keep background transparent unless it has a specific color
                    if (label.BackColor != Color.Transparent && label.BackColor != SystemColors.Control)
                    {
                        label.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                            ColorSchemeManager.FormBackground : label.BackColor;
                    }
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                        ColorSchemeManager.CardRevealed : Color.White;
                    richTextBox.ForeColor = Color.Black;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = ColorSchemeManager.IsColorBlindFriendly ?
                        ColorSchemeManager.CardRevealed : Color.White;
                    textBox.ForeColor = Color.Black;
                }

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyColorSchemeToControl(control);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}