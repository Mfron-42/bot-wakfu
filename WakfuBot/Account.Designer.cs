namespace WakfuBot
{
    partial class AccountForm
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
            this.AccountText = new System.Windows.Forms.TextBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.ConnectAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccountText
            // 
            this.AccountText.Location = new System.Drawing.Point(42, 26);
            this.AccountText.Name = "AccountText";
            this.AccountText.Size = new System.Drawing.Size(153, 22);
            this.AccountText.TabIndex = 0;
            this.AccountText.Text = "linq-query";
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(43, 70);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.PasswordChar = '*';
            this.PasswordText.Size = new System.Drawing.Size(152, 22);
            this.PasswordText.TabIndex = 1;
            this.PasswordText.Text = "leblanc95";
            // 
            // ConnectAccount
            // 
            this.ConnectAccount.Location = new System.Drawing.Point(63, 118);
            this.ConnectAccount.Name = "ConnectAccount";
            this.ConnectAccount.Size = new System.Drawing.Size(119, 23);
            this.ConnectAccount.TabIndex = 4;
            this.ConnectAccount.Text = "Connexion";
            this.ConnectAccount.UseVisualStyleBackColor = true;
            this.ConnectAccount.Click += new System.EventHandler(this.ConnectAccount_Click);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 153);
            this.Controls.Add(this.ConnectAccount);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.AccountText);
            this.Name = "Account";
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectAccount;
        public System.Windows.Forms.TextBox AccountText;
        public System.Windows.Forms.TextBox PasswordText;
    }
}