namespace Aurora.Forms.Interface
{
    partial class InterfaceAdd
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
            this.InterfaceNameLabel = new System.Windows.Forms.Label();
            this.MainNameLabel = new System.Windows.Forms.Label();
            this.NewNameTextbox = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InterfaceNameLabel
            // 
            this.InterfaceNameLabel.AutoSize = true;
            this.InterfaceNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InterfaceNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.InterfaceNameLabel.Location = new System.Drawing.Point(12, 46);
            this.InterfaceNameLabel.Name = "InterfaceNameLabel";
            this.InterfaceNameLabel.Size = new System.Drawing.Size(137, 31);
            this.InterfaceNameLabel.TabIndex = 0;
            this.InterfaceNameLabel.Text = "Название";
            // 
            // MainNameLabel
            // 
            this.MainNameLabel.AutoSize = true;
            this.MainNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainNameLabel.Location = new System.Drawing.Point(12, 9);
            this.MainNameLabel.Name = "MainNameLabel";
            this.MainNameLabel.Size = new System.Drawing.Size(425, 31);
            this.MainNameLabel.TabIndex = 2;
            this.MainNameLabel.Text = "Добавление Нового интерфейса";
            // 
            // NewNameTextbox
            // 
            this.NewNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewNameTextbox.Location = new System.Drawing.Point(155, 43);
            this.NewNameTextbox.Name = "NewNameTextbox";
            this.NewNameTextbox.Size = new System.Drawing.Size(282, 38);
            this.NewNameTextbox.TabIndex = 3;
            this.NewNameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewNameTextboxKeyDown);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonAdd.Location = new System.Drawing.Point(18, 96);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(419, 68);
            this.ButtonAdd.TabIndex = 5;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // InterfaceAddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(449, 178);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.NewNameTextbox);
            this.Controls.Add(this.MainNameLabel);
            this.Controls.Add(this.InterfaceNameLabel);
            this.Name = "InterfaceAddWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InterfaceNameLabel;
        private System.Windows.Forms.Label MainNameLabel;
        private System.Windows.Forms.TextBox NewNameTextbox;
        private System.Windows.Forms.Button ButtonAdd;
    }
}