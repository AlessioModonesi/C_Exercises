namespace Sparatutto_Zombie
{
    partial class Home
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
            this.NomeLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.nomeUtenteBox = new System.Windows.Forms.TextBox();
            this.CreditiLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NomeLabel
            // 
            this.NomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BackColor = System.Drawing.Color.White;
            this.NomeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeLabel.ForeColor = System.Drawing.Color.Black;
            this.NomeLabel.Location = new System.Drawing.Point(400, 80);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(276, 32);
            this.NomeLabel.TabIndex = 1;
            this.NomeLabel.Text = "Inserisci il tuo nome";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.BackColor = System.Drawing.Color.White;
            this.StartLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabel.ForeColor = System.Drawing.Color.Black;
            this.StartLabel.Location = new System.Drawing.Point(485, 215);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(83, 34);
            this.StartLabel.TabIndex = 3;
            this.StartLabel.Text = "Start";
            this.StartLabel.Click += new System.EventHandler(this.StartLabel_Click);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.BackColor = System.Drawing.Color.White;
            this.ExitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExitLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLabel.ForeColor = System.Drawing.Color.Black;
            this.ExitLabel.Location = new System.Drawing.Point(495, 282);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(66, 34);
            this.ExitLabel.TabIndex = 4;
            this.ExitLabel.Text = "Exit";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            // 
            // nomeUtenteBox
            // 
            this.nomeUtenteBox.BackColor = System.Drawing.Color.White;
            this.nomeUtenteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeUtenteBox.ForeColor = System.Drawing.Color.Black;
            this.nomeUtenteBox.Location = new System.Drawing.Point(424, 135);
            this.nomeUtenteBox.Name = "nomeUtenteBox";
            this.nomeUtenteBox.Size = new System.Drawing.Size(225, 26);
            this.nomeUtenteBox.TabIndex = 5;
            this.nomeUtenteBox.TextChanged += new System.EventHandler(this.nomeUtenteBox_TextChanged);
            // 
            // CreditiLabel
            // 
            this.CreditiLabel.AutoSize = true;
            this.CreditiLabel.BackColor = System.Drawing.Color.White;
            this.CreditiLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditiLabel.ForeColor = System.Drawing.Color.Black;
            this.CreditiLabel.Location = new System.Drawing.Point(593, 437);
            this.CreditiLabel.Name = "CreditiLabel";
            this.CreditiLabel.Size = new System.Drawing.Size(119, 15);
            this.CreditiLabel.TabIndex = 6;
            this.CreditiLabel.Text = "Alessio Modonesi";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Sparatutto_Zombie.Properties.Resources.sfondo;
            this.ClientSize = new System.Drawing.Size(724, 461);
            this.Controls.Add(this.CreditiLabel);
            this.Controls.Add(this.nomeUtenteBox);
            this.Controls.Add(this.ExitLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.NomeLabel);
            this.Name = "Home";
            this.Text = "Sparatutto Zombie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.TextBox nomeUtenteBox;
        private System.Windows.Forms.Label CreditiLabel;
    }
}