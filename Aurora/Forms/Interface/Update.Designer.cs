namespace Aurora.Forms.Interface
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.interfaceNameTextBox = new System.Windows.Forms.TextBox();
            this.MainNameLabel = new System.Windows.Forms.Label();
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButton.Location = new System.Drawing.Point(12, 101);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(317, 65);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Изменить";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButtonClick);
            // 
            // interfaceNameTextBox
            // 
            this.interfaceNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interfaceNameTextBox.Location = new System.Drawing.Point(167, 43);
            this.interfaceNameTextBox.Name = "interfaceNameTextBox";
            this.interfaceNameTextBox.Size = new System.Drawing.Size(162, 38);
            this.interfaceNameTextBox.TabIndex = 1;
            this.interfaceNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.interfaceNameTextBoxKeyDown);
            // 
            // MainNameLabel
            // 
            this.MainNameLabel.AutoSize = true;
            this.MainNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainNameLabel.Location = new System.Drawing.Point(12, 9);
            this.MainNameLabel.Name = "MainNameLabel";
            this.MainNameLabel.Size = new System.Drawing.Size(317, 31);
            this.MainNameLabel.TabIndex = 2;
            this.MainNameLabel.Text = "Изменение интерфейса";
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewNameLabel.Location = new System.Drawing.Point(12, 46);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(149, 31);
            this.NewNameLabel.TabIndex = 3;
            this.NewNameLabel.Text = "Новое имя";
            // 
            // InterfaceUpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 178);
            this.Controls.Add(this.NewNameLabel);
            this.Controls.Add(this.MainNameLabel);
            this.Controls.Add(this.interfaceNameTextBox);
            this.Controls.Add(this.UpdateButton);
            this.Name = "InterfaceUpdateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox interfaceNameTextBox;
        private System.Windows.Forms.Label MainNameLabel;
        private System.Windows.Forms.Label NewNameLabel;
    }
}