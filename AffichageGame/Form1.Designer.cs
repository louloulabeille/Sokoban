﻿namespace AffichageGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Solo = new System.Windows.Forms.ToolStripMenuItem();
            this.Nouvelle_Partie_Solo = new System.Windows.Forms.ToolStripMenuItem();
            this.Multijoueur = new System.Windows.Forms.ToolStripMenuItem();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Solo,
            this.Multijoueur,
            this.Reset});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(86, 568);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            this.menuStrip1.Click += new System.EventHandler(this.click_Reset);
            // 
            // Solo
            // 
            this.Solo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nouvelle_Partie_Solo});
            this.Solo.Name = "Solo";
            this.Solo.Size = new System.Drawing.Size(75, 19);
            this.Solo.Text = "Solo";
            // 
            // Nouvelle_Partie_Solo
            // 
            this.Nouvelle_Partie_Solo.Name = "Nouvelle_Partie_Solo";
            this.Nouvelle_Partie_Solo.Size = new System.Drawing.Size(154, 22);
            this.Nouvelle_Partie_Solo.Text = "Nouvelle Partie";
            this.Nouvelle_Partie_Solo.Click += new System.EventHandler(this.click_Solo);
            // 
            // Multijoueur
            // 
            this.Multijoueur.Name = "Multijoueur";
            this.Multijoueur.Size = new System.Drawing.Size(75, 19);
            this.Multijoueur.Text = "Multijoueur";
            // 
            // Reset
            // 
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 19);
            this.Reset.Text = "Reset";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 568);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "FormMDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Solo;
        private System.Windows.Forms.ToolStripMenuItem Multijoueur;
        private System.Windows.Forms.ToolStripMenuItem Nouvelle_Partie_Solo;
        private System.Windows.Forms.ToolStripMenuItem Reset;
    }
}

