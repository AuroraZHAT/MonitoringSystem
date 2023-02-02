namespace Aurora
{
    partial class DeletingColumnInSelectedTable
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
            this.buttonDeleting = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // buttonDeleting
            // 
            this.buttonDeleting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleting.Location = new System.Drawing.Point(17, 82);
            this.buttonDeleting.Name = "buttonDeleting";
            this.buttonDeleting.Size = new System.Drawing.Size(140, 38);
            this.buttonDeleting.TabIndex = 1;
            this.buttonDeleting.Text = "Удалить";
            this.buttonDeleting.UseVisualStyleBackColor = true;
            this.buttonDeleting.Click += new System.EventHandler(this.buttonDeleting_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.textBox.Location = new System.Drawing.Point(17, 38);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(140, 38);
            this.textBox.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonExit.Location = new System.Drawing.Point(17, 126);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(140, 38);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // DeletingColumnInSelectedTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 179);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDeleting);
            this.Controls.Add(this.label1);
            this.Name = "DeletingColumnInSelectedTable";
            this.Text = "DeletingColumnInSelectedTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleting;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonExit;
    }
}