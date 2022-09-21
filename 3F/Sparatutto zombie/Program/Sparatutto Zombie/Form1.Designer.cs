namespace Sparatutto_Zombie
{
    partial class Game
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtHealth = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            this.txtAmmo = new System.Windows.Forms.Label();
            this.PlayLabel = new System.Windows.Forms.Label();
            this.PauseLabel = new System.Windows.Forms.Label();
            this.RestartLabel = new System.Windows.Forms.Label();
            this.HelpButton = new System.Windows.Forms.Label();
            this.HomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHealth
            // 
            this.txtHealth.AutoSize = true;
            this.txtHealth.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHealth.ForeColor = System.Drawing.Color.White;
            this.txtHealth.Location = new System.Drawing.Point(285, 8);
            this.txtHealth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(80, 22);
            this.txtHealth.TabIndex = 2;
            this.txtHealth.Text = "Health: ";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(357, 10);
            this.healthBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(162, 19);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // player
            // 
            this.player.Image = global::Sparatutto_Zombie.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(434, 300);
            this.player.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(155, 8);
            this.txtScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(71, 22);
            this.txtScore.TabIndex = 6;
            this.txtScore.Text = "Kills: 0";
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.White;
            this.txtAmmo.Location = new System.Drawing.Point(10, 8);
            this.txtAmmo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(91, 22);
            this.txtAmmo.TabIndex = 7;
            this.txtAmmo.Text = "Ammo: 0";
            // 
            // PlayLabel
            // 
            this.PlayLabel.AutoSize = true;
            this.PlayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayLabel.ForeColor = System.Drawing.Color.White;
            this.PlayLabel.Location = new System.Drawing.Point(650, 8);
            this.PlayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PlayLabel.Name = "PlayLabel";
            this.PlayLabel.Size = new System.Drawing.Size(51, 24);
            this.PlayLabel.TabIndex = 12;
            this.PlayLabel.Text = "Play";
            this.PlayLabel.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseLabel
            // 
            this.PauseLabel.AutoSize = true;
            this.PauseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PauseLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseLabel.ForeColor = System.Drawing.Color.White;
            this.PauseLabel.Location = new System.Drawing.Point(715, 8);
            this.PauseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PauseLabel.Name = "PauseLabel";
            this.PauseLabel.Size = new System.Drawing.Size(68, 24);
            this.PauseLabel.TabIndex = 13;
            this.PauseLabel.Text = "Pause";
            this.PauseLabel.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // RestartLabel
            // 
            this.RestartLabel.AutoSize = true;
            this.RestartLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RestartLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartLabel.ForeColor = System.Drawing.Color.White;
            this.RestartLabel.Location = new System.Drawing.Point(797, 8);
            this.RestartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RestartLabel.Name = "RestartLabel";
            this.RestartLabel.Size = new System.Drawing.Size(80, 24);
            this.RestartLabel.TabIndex = 14;
            this.RestartLabel.Text = "Restart";
            this.RestartLabel.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.AutoSize = true;
            this.HelpButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(892, 8);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(23, 24);
            this.HelpButton.TabIndex = 17;
            this.HelpButton.Text = "?";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // HomeLabel
            // 
            this.HomeLabel.AutoSize = true;
            this.HomeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HomeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeLabel.ForeColor = System.Drawing.Color.White;
            this.HomeLabel.Location = new System.Drawing.Point(571, 8);
            this.HomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HomeLabel.Name = "HomeLabel";
            this.HomeLabel.Size = new System.Drawing.Size(65, 24);
            this.HomeLabel.TabIndex = 18;
            this.HomeLabel.Text = "Home";
            this.HomeLabel.Click += new System.EventHandler(this.HomeLabel_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.HomeLabel);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.RestartLabel);
            this.Controls.Add(this.PauseLabel);
            this.Controls.Add(this.PlayLabel);
            this.Controls.Add(this.txtAmmo);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.txtHealth);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Game";
            this.Text = "Sparatutto Zombie";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtHealth;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Label PlayLabel;
        private System.Windows.Forms.Label PauseLabel;
        private System.Windows.Forms.Label RestartLabel;
        private new System.Windows.Forms.Label HelpButton;
        private System.Windows.Forms.Label HomeLabel;
    }
}

