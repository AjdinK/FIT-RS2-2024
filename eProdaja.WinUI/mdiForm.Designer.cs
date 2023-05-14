namespace eProdaja.WinUI {
    partial class mdiForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            menuStrip1 = new MenuStrip();
            korisniciToolStripMenuItem = new ToolStripMenuItem();
            pretregaToolStripMenuItem = new ToolStripMenuItem();
            noviKorisnikToolStripMenuItem = new ToolStripMenuItem();
            proizvodiToolStripMenuItem = new ToolStripMenuItem();
            listaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { korisniciToolStripMenuItem, proizvodiToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(439, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // korisniciToolStripMenuItem
            // 
            korisniciToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pretregaToolStripMenuItem, noviKorisnikToolStripMenuItem });
            korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            korisniciToolStripMenuItem.Size = new Size(64, 20);
            korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretregaToolStripMenuItem
            // 
            pretregaToolStripMenuItem.Name = "pretregaToolStripMenuItem";
            pretregaToolStripMenuItem.Size = new Size(180, 22);
            pretregaToolStripMenuItem.Text = "Pretrega";
            pretregaToolStripMenuItem.Click += pretregaToolStripMenuItem_Click;
            // 
            // noviKorisnikToolStripMenuItem
            // 
            noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            noviKorisnikToolStripMenuItem.Size = new Size(143, 22);
            noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            // 
            // proizvodiToolStripMenuItem
            // 
            proizvodiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaToolStripMenuItem });
            proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            proizvodiToolStripMenuItem.Size = new Size(68, 20);
            proizvodiToolStripMenuItem.Text = "Proizvodi";
            // 
            // listaToolStripMenuItem
            // 
            listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            listaToolStripMenuItem.Size = new Size(98, 22);
            listaToolStripMenuItem.Text = "Lista";
            // 
            // mdiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 261);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "mdiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mdiForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem korisniciToolStripMenuItem;
        private ToolStripMenuItem pretregaToolStripMenuItem;
        private ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private ToolStripMenuItem proizvodiToolStripMenuItem;
        private ToolStripMenuItem listaToolStripMenuItem;
    }
}