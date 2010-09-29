namespace Minesweeper
{
    partial class Form1
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
            this.bNewGame = new System.Windows.Forms.Button();
            this.pTablero = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bNewGame
            // 
            this.bNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.bNewGame.Location = new System.Drawing.Point(69, 261);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(134, 23);
            this.bNewGame.TabIndex = 0;
            this.bNewGame.Text = "Juego Nuevo";
            this.bNewGame.UseVisualStyleBackColor = false;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // pTablero
            // 
            this.pTablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTablero.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTablero.Location = new System.Drawing.Point(0, 0);
            this.pTablero.Name = "pTablero";
            this.pTablero.Size = new System.Drawing.Size(264, 255);
            this.pTablero.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 296);
            this.Controls.Add(this.pTablero);
            this.Controls.Add(this.bNewGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Panel pTablero;
    }
}

