namespace MemoryBattle
{
    partial class FormSinglePlayerMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnHardest;
        private System.Windows.Forms.Button btnPro;
        private System.Windows.Forms.Button btnProgressive;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        /// <param name="disposing"></param>
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnHardest = new System.Windows.Forms.Button();
            this.btnPro = new System.Windows.Forms.Button();
            this.btnProgressive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.Location = new System.Drawing.Point(50, 20);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(200, 40);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(50, 70);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(200, 40);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHard
            // 
            this.btnHard.Location = new System.Drawing.Point(50, 120);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(200, 40);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnHardest
            // 
            this.btnHardest.Location = new System.Drawing.Point(50, 170);
            this.btnHardest.Name = "btnHardest";
            this.btnHardest.Size = new System.Drawing.Size(200, 40);
            this.btnHardest.TabIndex = 3;
            this.btnHardest.Text = "Hardest";
            this.btnHardest.UseVisualStyleBackColor = true;
            this.btnHardest.Click += new System.EventHandler(this.btnHardest_Click);
            // 
            // btnPro
            // 
            this.btnPro.Location = new System.Drawing.Point(50, 220);
            this.btnPro.Name = "btnPro";
            this.btnPro.Size = new System.Drawing.Size(200, 40);
            this.btnPro.TabIndex = 4;
            this.btnPro.Text = "Pro";
            this.btnPro.UseVisualStyleBackColor = true;
            this.btnPro.Click += new System.EventHandler(this.btnPro_Click);
            // 
            // btnProgressive
            // 
            this.btnProgressive.Location = new System.Drawing.Point(50, 270);
            this.btnProgressive.Name = "btnProgressive";
            this.btnProgressive.Size = new System.Drawing.Size(200, 40);
            this.btnProgressive.TabIndex = 5;
            this.btnProgressive.Text = "Progressive Mode";
            this.btnProgressive.UseVisualStyleBackColor = true;
            this.btnProgressive.Click += new System.EventHandler(this.btnProgressive_Click);
            // 
            // FormSinglePlayerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Controls.Add(this.btnProgressive);
            this.Controls.Add(this.btnPro);
            this.Controls.Add(this.btnHardest);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSinglePlayerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Difficulty";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
