namespace MemoryBattle
{
    partial class FormGameModeSelection
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPlayerVsPlayer = new System.Windows.Forms.Button();
            this.btnPlayerVsAI = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
             
            // btnPlayerVsPlayer
            this.btnPlayerVsPlayer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlayerVsPlayer.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(123, 204);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(214, 36);
            this.btnPlayerVsPlayer.TabIndex = 0;
            this.btnPlayerVsPlayer.Text = "Player vs Player";
            this.btnPlayerVsPlayer.UseVisualStyleBackColor = false;
            this.btnPlayerVsPlayer.Click += new System.EventHandler(this.btnPlayerVsPlayer_Click);
             
            // btnPlayerVsAI
            this.btnPlayerVsAI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlayerVsAI.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnPlayerVsAI.Location = new System.Drawing.Point(123, 256);
            this.btnPlayerVsAI.Name = "btnPlayerVsAI";
            this.btnPlayerVsAI.Size = new System.Drawing.Size(214, 36);
            this.btnPlayerVsAI.TabIndex = 1;
            this.btnPlayerVsAI.Text = "Player vs AI";
            this.btnPlayerVsAI.UseVisualStyleBackColor = false;
            this.btnPlayerVsAI.Click += new System.EventHandler(this.btnPlayerVsAI_Click);
            
            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            this.btnCancel.Location = new System.Drawing.Point(123, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Game Mode";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // FormGameModeSelection
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemoryBattle.Properties.Resources.WinterBattleDaytime;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(458, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPlayerVsAI);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Name = "FormGameModeSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnPlayerVsPlayer;
        private System.Windows.Forms.Button btnPlayerVsAI;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}