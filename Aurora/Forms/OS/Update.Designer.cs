namespace Aurora.Forms.OS
{
    partial class Update
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
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.UpdateOsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(12, 108);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(317, 65);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "Изменить";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
            // 
            // MainNameLabel
            // 
            this.MainNameLabel.AutoSize = true;
            this.MainNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainNameLabel.Location = new System.Drawing.Point(31, 9);
            this.MainNameLabel.Name = "MainNameLabel";
            this.MainNameLabel.Size = new System.Drawing.Size(278, 31);
            this.MainNameLabel.TabIndex = 1;
            this.MainNameLabel.Text = "Изменение Системы";
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewNameLabel.Location = new System.Drawing.Point(12, 58);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(149, 31);
            this.NewNameLabel.TabIndex = 2;
            this.NewNameLabel.Text = "Новое имя";
            // 
            // UpdateOsTextBox
            // 
            this.UpdateOsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateOsTextBox.Location = new System.Drawing.Point(167, 55);
            this.UpdateOsTextBox.Name = "UpdateOsTextBox";
            this.UpdateOsTextBox.Size = new System.Drawing.Size(162, 38);
            this.UpdateOsTextBox.TabIndex = 3;
            // 
            // OsUpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 178);
            this.Controls.Add(this.UpdateOsTextBox);
            this.Controls.Add(this.NewNameLabel);
            this.Controls.Add(this.MainNameLabel);
            this.Controls.Add(this.ButtonUpdate);
            this.Name = "OsUpdateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OsUpdateWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Label MainNameLabel;
        private System.Windows.Forms.Label NewNameLabel;
        private System.Windows.Forms.TextBox UpdateOsTextBox;
    }
}