namespace MemoryBattle
{
    partial class FormAIModeMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnPro;
        private System.Windows.Forms.Button btnSuperBattle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnPro = new System.Windows.Forms.Button();
            this.btnSuperBattle = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEasy.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnEasy.Location = new System.Drawing.Point(126, 240);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(215, 36);
            this.btnEasy.TabIndex = 2;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMedium.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnMedium.Location = new System.Drawing.Point(127, 284);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(214, 35);
            this.btnMedium.TabIndex = 3;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnPro
            // 
            this.btnPro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPro.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnPro.Location = new System.Drawing.Point(127, 368);
            this.btnPro.Name = "btnPro";
            this.btnPro.Size = new System.Drawing.Size(214, 35);
            this.btnPro.TabIndex = 4;
            this.btnPro.Text = "Pro";
            this.btnPro.UseVisualStyleBackColor = false;
            this.btnPro.Click += new System.EventHandler(this.btnPro_Click);
            // 
            // btnSuperBattle
            // 
            this.btnSuperBattle.Location = new System.Drawing.Point(0, 0);
            this.btnSuperBattle.Name = "btnSuperBattle";
            this.btnSuperBattle.Size = new System.Drawing.Size(75, 23);
            this.btnSuperBattle.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnCancel.Location = new System.Drawing.Point(126, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Silver;
            this.labelName.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.labelName.Location = new System.Drawing.Point(28, 171);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(104, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Player Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(167, 169);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(174, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnHard.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnHard.Location = new System.Drawing.Point(126, 325);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(214, 35);
            this.btnHard.TabIndex = 8;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // FormAIModeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemoryBattle.Properties.Resources.WinterBattleDaytime;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(458, 503);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSuperBattle);
            this.Controls.Add(this.btnPro);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAIModeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Player vs AI - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnHard;
    }
}
