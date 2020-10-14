namespace Affichage
{
    partial class FormTest
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtNbrCout = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.Jeux = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TxtNbrCout
            // 
            this.TxtNbrCout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNbrCout.Location = new System.Drawing.Point(953, 471);
            this.TxtNbrCout.Name = "TxtNbrCout";
            this.TxtNbrCout.Size = new System.Drawing.Size(183, 22);
            this.TxtNbrCout.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
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
            this.listBox1.Location = new System.Drawing.Point(953, 144);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 308);
            this.listBox1.TabIndex = 6;
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReset.Location = new System.Drawing.Point(953, 514);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(183, 72);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Jeux
            // 
            this.Jeux.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Jeux.Location = new System.Drawing.Point(195, 129);
            this.Jeux.Name = "Jeux";
            this.Jeux.Size = new System.Drawing.Size(565, 490);
            this.Jeux.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 749);
            this.Controls.Add(this.TxtNbrCout);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.Jeux);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNbrCout;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Panel Jeux;
    }
}

