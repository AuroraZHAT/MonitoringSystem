namespace ServerSetUp
{
    partial class ServerSetUpConf
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxServername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDBname = new System.Windows.Forms.TextBox();
            this.checkBoxIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.checkBoxTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сервер";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxServername
            // 
            this.textBoxServername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.textBoxServername.Location = new System.Drawing.Point(17, 38);
            this.textBoxServername.Name = "textBoxServername";
            this.textBoxServername.Size = new System.Drawing.Size(180, 32);
            this.textBoxServername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "База данных";
            // 
            // textBoxDBname
            // 
            this.textBoxDBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.textBoxDBname.Location = new System.Drawing.Point(17, 102);
            this.textBoxDBname.Name = "textBoxDBname";
            this.textBoxDBname.Size = new System.Drawing.Size(180, 32);
            this.textBoxDBname.TabIndex = 2;
            // 
            // checkBoxIntegratedSecurity
            // 
            this.checkBoxIntegratedSecurity.AutoSize = true;
            this.checkBoxIntegratedSecurity.Location = new System.Drawing.Point(17, 140);
            this.checkBoxIntegratedSecurity.Name = "checkBoxIntegratedSecurity";
            this.checkBoxIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.checkBoxIntegratedSecurity.TabIndex = 3;
            this.checkBoxIntegratedSecurity.Text = "Integrated Security";
            this.checkBoxIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrustServerCertificate
            // 
            this.checkBoxTrustServerCertificate.AutoSize = true;
            this.checkBoxTrustServerCertificate.Location = new System.Drawing.Point(17, 163);
            this.checkBoxTrustServerCertificate.Name = "checkBoxTrustServerCertificate";
            this.checkBoxTrustServerCertificate.Size = new System.Drawing.Size(134, 17);
            this.checkBoxTrustServerCertificate.TabIndex = 3;
            this.checkBoxTrustServerCertificate.Text = "Trust Server Certificate";
            this.checkBoxTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // ServerSetUpConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 310);
            this.Controls.Add(this.checkBoxTrustServerCertificate);
            this.Controls.Add(this.checkBoxIntegratedSecurity);
            this.Controls.Add(this.textBoxDBname);
            this.Controls.Add(this.textBoxServername);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ServerSetUpConf";
            this.Text = "ServerSetUpConf";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxServername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDBname;
        private System.Windows.Forms.CheckBox checkBoxIntegratedSecurity;
        private System.Windows.Forms.CheckBox checkBoxTrustServerCertificate;
    }
}