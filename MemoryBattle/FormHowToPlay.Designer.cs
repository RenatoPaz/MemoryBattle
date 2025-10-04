using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryBattle
{
    partial class FormHowToPlay
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblRules;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblRules = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRules
            // 
            this.lblRules.BackColor = System.Drawing.Color.Transparent;
            this.lblRules.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.Color.White;
            this.lblRules.Location = new System.Drawing.Point(25, 20);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(250, 250);
            this.lblRules.TabIndex = 0;
            this.lblRules.Text = "🧩 Match pairs of cards.\r\n\r\n👥 Players take turns; a correct match earns another tr" +
    "y.\r\n\r\n💪 Each new level adds more pairs and harder symbols.\r\n\r\n🏆 The player with " +
    "the most pairs wins!";
            this.lblRules.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RosyBrown;
            this.btnClose.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(75, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemoryBattle.Properties.Resources.FallSeasonImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 360);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "How to Play";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
