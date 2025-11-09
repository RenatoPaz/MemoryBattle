namespace MemoryBattle
{
    partial class FormAIGame
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.ComboBox cmbAIDifficulty;
        private System.Windows.Forms.Button btnStartAI;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMode = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.cmbAIDifficulty = new System.Windows.Forms.ComboBox();
            this.btnStartAI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Transparent;
            this.lblMode.Font = new System.Drawing.Font("Cascadia Code", 12F);
            this.lblMode.Location = new System.Drawing.Point(18, 18);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(170, 22);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode: (placeholder)";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblTurn.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.lblTurn.Location = new System.Drawing.Point(18, 48);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(80, 18);
            this.lblTurn.TabIndex = 1;
            this.lblTurn.Text = "Turn: ---";
            // 
            // cmbAIDifficulty
            // 
            this.cmbAIDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAIDifficulty.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.cmbAIDifficulty.FormattingEnabled = true;
            this.cmbAIDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cmbAIDifficulty.Location = new System.Drawing.Point(20, 80);
            this.cmbAIDifficulty.Name = "cmbAIDifficulty";
            this.cmbAIDifficulty.Size = new System.Drawing.Size(140, 26);
            this.cmbAIDifficulty.TabIndex = 2;
            
            // 
            // btnStartAI
            // 
            this.btnStartAI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStartAI.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.btnStartAI.Location = new System.Drawing.Point(20, 116);
            this.btnStartAI.Name = "btnStartAI";
            this.btnStartAI.Size = new System.Drawing.Size(140, 34);
            this.btnStartAI.TabIndex = 3;
            this.btnStartAI.Text = "Start AI";
            this.btnStartAI.UseVisualStyleBackColor = false;
            
            // 
            // FormAIGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Match FormGame default client area so layouts are consistent
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnStartAI);
            this.Controls.Add(this.cmbAIDifficulty);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lblMode);
            this.Name = "FormAIGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAIGame";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}