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
            Ime = new DataGridViewTextBoxColumn();
            Prezime = new DataGridViewTextBoxColumn();
            RoleNames = new DataGridViewTextBoxColumn();
            Status = new DataGridViewCheckBoxColumn();
            btnShow = new Button();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.AllowUserToAddRows = false;
            dgvKorisnici.AllowUserToDeleteRows = false;
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Columns.AddRange(new DataGridViewColumn[] { Ime, Prezime, RoleNames, Status });
            dgvKorisnici.Location = new Point(12, 114);
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.RowTemplate.Height = 25;
            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKorisnici.Size = new Size(749, 307);
            dgvKorisnici.TabIndex = 0;
            dgvKorisnici.CellDoubleClick += dgvKorisnici_CellDoubleClick;
            // 
            // Ime
            // 
            Ime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Ime.DataPropertyName = "Ime";
            Ime.HeaderText = "Ime";
            Ime.Name = "Ime";
            Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            Prezime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Prezime.DataPropertyName = "Prezime";
            Prezime.HeaderText = "Prezime korisnika";
            Prezime.Name = "Prezime";
            Prezime.ReadOnly = true;
            // 
            // RoleNames
            // 
            RoleNames.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RoleNames.DataPropertyName = "RoleNames";
            RoleNames.HeaderText = "Uloge";
            RoleNames.Name = "RoleNames";
            RoleNames.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(181, 72);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(81, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(175, 23);
            txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 46);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(81, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(175, 23);
            txtName.TabIndex = 4;
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 433);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(btnShow);
            Controls.Add(dgvKorisnici);
            Name = "frmKorisnici";
            Text = "frmKorisnici";
            Load += frmKorisnici_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKorisnici;
        private Button btnShow;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private TextBox txtName;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn RoleNames;
        private DataGridViewCheckBoxColumn Status;
    }
}