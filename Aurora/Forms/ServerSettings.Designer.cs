namespace Aurora.Forms
{
    partial class ServerSettings
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDatabaseName = new System.Windows.Forms.TextBox();
            this.checkBoxIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.checkBoxTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateDataBase = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateTable = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateView = new System.Windows.Forms.CheckBox();
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
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(12, 270);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(180, 41);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Подтвердить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.textBoxServerName.Location = new System.Drawing.Point(17, 38);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(180, 32);
            this.textBoxServerName.TabIndex = 2;
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
            // textBoxDatabaseName
            // 
            this.textBoxDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.textBoxDatabaseName.Location = new System.Drawing.Point(17, 102);
            this.textBoxDatabaseName.Name = "textBoxDatabaseName";
            this.textBoxDatabaseName.Size = new System.Drawing.Size(180, 32);
            this.textBoxDatabaseName.TabIndex = 2;
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
            // checkBoxCreateDataBase
            // 
            this.checkBoxCreateDataBase.AutoSize = true;
            this.checkBoxCreateDataBase.Location = new System.Drawing.Point(17, 186);
            this.checkBoxCreateDataBase.Name = "checkBoxCreateDataBase";
            this.checkBoxCreateDataBase.Size = new System.Drawing.Size(134, 17);
            this.checkBoxCreateDataBase.TabIndex = 3;
            this.checkBoxCreateDataBase.Text = "Создать базу данных";
            this.checkBoxCreateDataBase.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateTable
            // 
            this.checkBoxCreateTable.AutoSize = true;
            this.checkBoxCreateTable.Location = new System.Drawing.Point(17, 209);
            this.checkBoxCreateTable.Name = "checkBoxCreateTable";
            this.checkBoxCreateTable.Size = new System.Drawing.Size(114, 17);
            this.checkBoxCreateTable.TabIndex = 3;
            this.checkBoxCreateTable.Text = "Создать таблицы";
            this.checkBoxCreateTable.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateView
            // 
            this.checkBoxCreateView.AutoSize = true;
            this.checkBoxCreateView.Location = new System.Drawing.Point(17, 232);
            this.checkBoxCreateView.Name = "checkBoxCreateView";
            this.checkBoxCreateView.Size = new System.Drawing.Size(148, 17);
            this.checkBoxCreateView.TabIndex = 3;
            this.checkBoxCreateView.Text = "Создать представления";
            this.checkBoxCreateView.UseVisualStyleBackColor = true;
            // 
            // ServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 344);
            this.Controls.Add(this.checkBoxTrustServerCertificate);
            this.Controls.Add(this.checkBoxCreateView);
            this.Controls.Add(this.checkBoxCreateTable);
            this.Controls.Add(this.checkBoxCreateDataBase);
            this.Controls.Add(this.checkBoxIntegratedSecurity);
            this.Controls.Add(this.textBoxDatabaseName);
            this.Controls.Add(this.textBoxServerName);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ServerSettings";
            this.Text = "Конфигуратор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDatabaseName;
        private System.Windows.Forms.CheckBox checkBoxIntegratedSecurity;
        private System.Windows.Forms.CheckBox checkBoxTrustServerCertificate;
        private System.Windows.Forms.CheckBox checkBoxCreateDataBase;
        private System.Windows.Forms.CheckBox checkBoxCreateTable;
        private System.Windows.Forms.CheckBox checkBoxCreateView;
    }
}