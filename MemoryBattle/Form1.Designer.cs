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
            this.SuspendLayout();
            // 
            // label1 (Título)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(120, 30);
            this.label1.Text = "Memory Battle";
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Location = new System.Drawing.Point(100, 100);
            this.btnSinglePlayer.Size = new System.Drawing.Size(200, 40);
            this.btnSinglePlayer.Text = "1 Player";
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // btnBattleMode
            // 
            this.btnBattleMode.Location = new System.Drawing.Point(100, 160);
            this.btnBattleMode.Size = new System.Drawing.Size(200, 40);
            this.btnBattleMode.Text = "Battle Mode";
            this.btnBattleMode.Click += new System.EventHandler(this.btnBattleMode_Click);
            // 
            // btnScoreInfo
            // 
            this.btnScoreInfo.Location = new System.Drawing.Point(100, 220);
            this.btnScoreInfo.Size = new System.Drawing.Size(200, 40);
            this.btnScoreInfo.Text = "Score Info";
            this.btnScoreInfo.Click += new System.EventHandler(this.btnScoreInfo_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Location = new System.Drawing.Point(100, 280);
            this.btnHowToPlay.Size = new System.Drawing.Size(200, 40);
            this.btnHowToPlay.Text = "How to Play";
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(420, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSinglePlayer);
            this.Controls.Add(this.btnBattleMode);
            this.Controls.Add(this.btnScoreInfo);
            this.Controls.Add(this.btnHowToPlay);
            this.Name = "Form1";
            this.Text = "Memory Battle";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
