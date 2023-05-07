namespace eProdaja.WinUI {
    partial class frmKorisnici {
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
            dgvKorisnici = new DataGridView();
            btnShow = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Location = new Point(12, 65);
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.RowTemplate.Height = 25;
            dgvKorisnici.Size = new Size(749, 260);
            dgvKorisnici.TabIndex = 0;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(686, 36);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 337);
            Controls.Add(btnShow);
            Controls.Add(dgvKorisnici);
            Name = "frmKorisnici";
            Text = "frmKorisnici";
            Load += frmKorisnici_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvKorisnici;
        private Button btnShow;
    }
}