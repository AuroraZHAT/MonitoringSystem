namespace Aurora.Forms.OS
{
    partial class OsAdd
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
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.MainNameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.UpdateNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(12, 105);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(368, 61);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "Добавить";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainNameLabel
            // 
            this.MainNameLabel.AutoSize = true;
            this.MainNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainNameLabel.Location = new System.Drawing.Point(12, 9);
            this.MainNameLabel.Name = "MainNameLabel";
            this.MainNameLabel.Size = new System.Drawing.Size(365, 31);
            this.MainNameLabel.TabIndex = 1;
            this.MainNameLabel.Text = "Добавление новой системы";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(12, 51);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(68, 31);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Имя";
            // 
            // UpdateNameTextBox
            // 
            this.UpdateNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateNameTextBox.Location = new System.Drawing.Point(86, 51);
            this.UpdateNameTextBox.Name = "UpdateNameTextBox";
            this.UpdateNameTextBox.Size = new System.Drawing.Size(291, 38);
            this.UpdateNameTextBox.TabIndex = 3;
            // 
            // OsAddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 178);
            this.Controls.Add(this.UpdateNameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.MainNameLabel);
            this.Controls.Add(this.ButtonUpdate);
            this.Name = "OsAddWindow";
            this.Text = "Добавление системы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Label MainNameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox UpdateNameTextBox;
    }
}