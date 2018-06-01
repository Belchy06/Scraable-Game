namespace WindowsFormsApp3
{
    partial class frmGame
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
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.pbRack = new System.Windows.Forms.PictureBox();
            this.pbBottomRack = new System.Windows.Forms.PictureBox();
            this.btnEndTurn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottomRack)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBoard
            // 
            this.pbBoard.Location = new System.Drawing.Point(12, 144);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(455, 545);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(12, 751);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(455, 20);
            this.txtDebug.TabIndex = 1;
            // 
            // pbRack
            // 
            this.pbRack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbRack.Location = new System.Drawing.Point(12, 68);
            this.pbRack.Name = "pbRack";
            this.pbRack.Size = new System.Drawing.Size(455, 50);
            this.pbRack.TabIndex = 2;
            this.pbRack.TabStop = false;
            // 
            // pbBottomRack
            // 
            this.pbBottomRack.Location = new System.Drawing.Point(12, 695);
            this.pbBottomRack.Name = "pbBottomRack";
            this.pbBottomRack.Size = new System.Drawing.Size(455, 50);
            this.pbBottomRack.TabIndex = 3;
            this.pbBottomRack.TabStop = false;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(12, 777);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 4;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 803);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.pbBottomRack);
            this.Controls.Add(this.pbRack);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.pbBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottomRack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.PictureBox pbRack;
        private System.Windows.Forms.PictureBox pbBottomRack;
        private System.Windows.Forms.Button btnEndTurn;
    }
}

