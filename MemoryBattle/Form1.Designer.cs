using MemoryBattle.Details;

namespace MemoryBattle
//Test comment 2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSinglePlayer;
        private System.Windows.Forms.Button btnBattleMode;
        private System.Windows.Forms.Button btnScoreInfo;
        private System.Windows.Forms.Button btnHowToPlay;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.btnBattleMode = new System.Windows.Forms.Button();
            this.btnScoreInfo = new System.Windows.Forms.Button();
            this.btnHowToPlay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(77, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memory Battle";
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSinglePlayer.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinglePlayer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSinglePlayer.Location = new System.Drawing.Point(100, 100);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(200, 40);
            this.btnSinglePlayer.TabIndex = 1;
            this.btnSinglePlayer.Text = "1 Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = false;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // btnBattleMode
            // 
            this.btnBattleMode.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBattleMode.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBattleMode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBattleMode.Location = new System.Drawing.Point(100, 160);
            this.btnBattleMode.Name = "btnBattleMode";
            this.btnBattleMode.Size = new System.Drawing.Size(200, 40);
            this.btnBattleMode.TabIndex = 2;
            this.btnBattleMode.Text = "Battle Mode";
            this.btnBattleMode.UseVisualStyleBackColor = false;
            this.btnBattleMode.Click += new System.EventHandler(this.btnBattleMode_Click);
            // 
            // btnScoreInfo
            // 
            this.btnScoreInfo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnScoreInfo.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScoreInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnScoreInfo.Location = new System.Drawing.Point(100, 220);
            this.btnScoreInfo.Name = "btnScoreInfo";
            this.btnScoreInfo.Size = new System.Drawing.Size(200, 40);
            this.btnScoreInfo.TabIndex = 3;
            this.btnScoreInfo.Text = "Score Info";
            this.btnScoreInfo.UseVisualStyleBackColor = false;
            this.btnScoreInfo.Click += new System.EventHandler(this.btnScoreInfo_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.BackColor = System.Drawing.Color.PowderBlue;
            this.btnHowToPlay.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHowToPlay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHowToPlay.Location = new System.Drawing.Point(100, 280);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(200, 40);
            this.btnHowToPlay.TabIndex = 4;
            this.btnHowToPlay.Text = "How to Play";
            this.btnHowToPlay.UseVisualStyleBackColor = false;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MemoryBattle.Properties.Resources.redbutterflies;
            this.pictureBox1.Location = new System.Drawing.Point(320, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.BackgroundImage = global::MemoryBattle.Properties.Resources.SummerSeasonImage;
            this.ClientSize = new System.Drawing.Size(420, 380);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSinglePlayer);
            this.Controls.Add(this.btnBattleMode);
            this.Controls.Add(this.btnScoreInfo);
            this.Controls.Add(this.btnHowToPlay);
            this.Name = "Form1";
            this.Text = "Memory Battle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
