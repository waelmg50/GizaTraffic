namespace Utilities.Forms
{
    partial class frmDatabaseConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseConfiguration));
            lblServer = new Label();
            txtServer = new TextBox();
            lblDatabase = new Label();
            txtDatabase = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            txtPassword = new TextBox();
            btnTest = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(30, 30);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(53, 20);
            lblServer.TabIndex = 0;
            lblServer.Text = "Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(140, 25);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(300, 27);
            txtServer.TabIndex = 0;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(30, 75);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(75, 20);
            lblDatabase.TabIndex = 0;
            lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(140, 70);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(300, 27);
            txtDatabase.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(30, 120);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(140, 115);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 27);
            txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 165);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(140, 215);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(140, 29);
            btnTest.TabIndex = 4;
            btnTest.Text = "Test Connection";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(300, 215);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmDatabaseConfiguration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 283);
            Controls.Add(btnSave);
            Controls.Add(btnTest);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtDatabase);
            Controls.Add(txtServer);
            Controls.Add(label1);
            Controls.Add(lblUsername);
            Controls.Add(lblDatabase);
            Controls.Add(lblServer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDatabaseConfiguration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblServer;
        private TextBox txtServer;
        private Label lblDatabase;
        private TextBox txtDatabase;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label label1;
        private TextBox txtPassword;
        private Button btnTest;
        private Button btnSave;
    }
}