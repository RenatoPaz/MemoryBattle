namespace MemoryBattle
{
    partial class FormBattleModeMenu
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnSuperBattle = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEasy.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnEasy.Location = new System.Drawing.Point(126, 240);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(215, 36);
            this.btnEasy.TabIndex = 0;
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
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnHard.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnHard.Location = new System.Drawing.Point(127, 325);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(214, 35);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnSuperBattle
            // 
            this.btnSuperBattle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSuperBattle.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnSuperBattle.Location = new System.Drawing.Point(127, 366);
            this.btnSuperBattle.Name = "btnSuperBattle";
            this.btnSuperBattle.Size = new System.Drawing.Size(214, 37);
            this.btnSuperBattle.TabIndex = 3;
            this.btnSuperBattle.Text = "Super Battle";
            this.btnSuperBattle.UseVisualStyleBackColor = false;
            this.btnSuperBattle.Click += new System.EventHandler(this.btnSuperBattle_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnCancel.Location = new System.Drawing.Point(127, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.label1.Location = new System.Drawing.Point(28, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player 1 Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.label2.Location = new System.Drawing.Point(28, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Player 2 Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 169);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 22);
            this.textBox2.TabIndex = 8;
            // 
            // FormBattleModeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemoryBattle.Properties.Resources.WinterBattleDaytime;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(458, 503);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSuperBattle);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Name = "FormBattleModeMenu";
            this.Text = "FormBattleModeMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnSuperBattle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}