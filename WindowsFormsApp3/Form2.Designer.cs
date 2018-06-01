namespace WindowsFormsApp3
{
    partial class frmSettings
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
            this.btnMorePlayers = new System.Windows.Forms.Button();
            this.btnLessPlayers = new System.Windows.Forms.Button();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMorePlayers
            // 
            this.btnMorePlayers.Location = new System.Drawing.Point(173, 4);
            this.btnMorePlayers.Name = "btnMorePlayers";
            this.btnMorePlayers.Size = new System.Drawing.Size(20, 23);
            this.btnMorePlayers.TabIndex = 0;
            this.btnMorePlayers.Text = ">";
            this.btnMorePlayers.UseVisualStyleBackColor = true;
            this.btnMorePlayers.Click += new System.EventHandler(this.btnMorePlayers_Click);
            // 
            // btnLessPlayers
            // 
            this.btnLessPlayers.Location = new System.Drawing.Point(147, 4);
            this.btnLessPlayers.Name = "btnLessPlayers";
            this.btnLessPlayers.Size = new System.Drawing.Size(20, 23);
            this.btnLessPlayers.TabIndex = 1;
            this.btnLessPlayers.Text = "<";
            this.btnLessPlayers.UseVisualStyleBackColor = true;
            this.btnLessPlayers.Click += new System.EventHandler(this.btnLessPlayers_Click);
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(12, 9);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(95, 13);
            this.lblPlayers.TabIndex = 2;
            this.lblPlayers.Text = "Number of players:";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(15, 368);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(15, 342);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(100, 20);
            this.txtFilePath.TabIndex = 4;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 403);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.btnLessPlayers);
            this.Controls.Add(this.btnMorePlayers);
            this.Name = "frmSettings";
            this.Text = "Scrabble Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMorePlayers;
        private System.Windows.Forms.Button btnLessPlayers;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}