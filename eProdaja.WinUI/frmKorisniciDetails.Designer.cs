namespace eProdaja.WinUI {
    partial class frmKorisniciDetails {
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
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtPasswordConf = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            clbUloge = new CheckedListBox();
            cbStatus = new CheckBox();
            btnSacuvaj = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtPrezime);
            groupBox1.Controls.Add(txtIme);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(114, 102);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(114, 67);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(255, 23);
            txtPrezime.TabIndex = 4;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(114, 37);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(255, 23);
            txtIme.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 105);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 70);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Prezime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 40);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPasswordConf);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtUsername);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(12, 189);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(390, 157);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Podaci";
            // 
            // txtPasswordConf
            // 
            txtPasswordConf.Location = new Point(114, 102);
            txtPasswordConf.Name = "txtPasswordConf";
            txtPasswordConf.PasswordChar = '*';
            txtPasswordConf.Size = new Size(255, 23);
            txtPasswordConf.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(114, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(255, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(114, 37);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(255, 23);
            txtUsername.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 105);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 2;
            label4.Text = "Confirmation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 70);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 1;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 40);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 0;
            label6.Text = "Username";
            // 
            // clbUloge
            // 
            clbUloge.FormattingEnabled = true;
            clbUloge.Location = new Point(12, 362);
            clbUloge.Name = "clbUloge";
            clbUloge.Size = new Size(142, 94);
            clbUloge.TabIndex = 7;
            // 
            // cbStatus
            // 
            cbStatus.AutoSize = true;
            cbStatus.Location = new Point(167, 365);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(58, 19);
            cbStatus.TabIndex = 8;
            cbStatus.Text = "Status";
            cbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(327, 433);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
            btnSacuvaj.TabIndex = 9;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // frmKorisniciDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 477);
            Controls.Add(btnSacuvaj);
            Controls.Add(cbStatus);
            Controls.Add(clbUloge);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmKorisniciDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmKorisniciDetails";
            Load += frmKorisniciDetails_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private TextBox txtEmail;
        private GroupBox groupBox2;
        private TextBox txtPasswordConf;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckedListBox clbUloge;
        private CheckBox cbStatus;
        private Button btnSacuvaj;
    }
}