﻿namespace AffichageGame
{
    partial class Form2
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDroite = new System.Windows.Forms.Button();
            this.btnHaut = new System.Windows.Forms.Button();
            this.btnBas = new System.Windows.Forms.Button();
            this.btnGauche = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.Location = new System.Drawing.Point(945, 287);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(200, 73);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Selection LVL";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.listBox1.Location = new System.Drawing.Point(945, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 224);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(65, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 700);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDroite
            // 
            this.btnDroite.Location = new System.Drawing.Point(1085, 534);
            this.btnDroite.Name = "btnDroite";
            this.btnDroite.Size = new System.Drawing.Size(60, 54);
            this.btnDroite.TabIndex = 3;
            this.btnDroite.UseVisualStyleBackColor = true;
            // 
            // btnHaut
            // 
            this.btnHaut.Location = new System.Drawing.Point(1019, 474);
            this.btnHaut.Name = "btnHaut";
            this.btnHaut.Size = new System.Drawing.Size(60, 54);
            this.btnHaut.TabIndex = 3;
            this.btnHaut.UseVisualStyleBackColor = true;
            // 
            // btnBas
            // 
            this.btnBas.Location = new System.Drawing.Point(1019, 534);
            this.btnBas.Name = "btnBas";
            this.btnBas.Size = new System.Drawing.Size(60, 54);
            this.btnBas.TabIndex = 3;
            this.btnBas.UseVisualStyleBackColor = true;
            // 
            // btnGauche
            // 
            this.btnGauche.Location = new System.Drawing.Point(953, 534);
            this.btnGauche.Name = "btnGauche";
            this.btnGauche.Size = new System.Drawing.Size(60, 54);
            this.btnGauche.TabIndex = 3;
            this.btnGauche.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 771);
            this.Controls.Add(this.btnGauche);
            this.Controls.Add(this.btnBas);
            this.Controls.Add(this.btnDroite);
            this.Controls.Add(this.btnHaut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSelect);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDroite;
        private System.Windows.Forms.Button btnHaut;
        private System.Windows.Forms.Button btnBas;
        private System.Windows.Forms.Button btnGauche;
    }
}