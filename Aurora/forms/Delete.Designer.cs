namespace Avrora
{
    partial class Delete
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
            this.components = new System.ComponentModel.Container();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonDeleting = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.textBoxID.Location = new System.Drawing.Point(17, 38);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(120, 38);
            this.textBoxID.TabIndex = 0;
            this.toolTip2.SetToolTip(this.textBoxID, "Введите номер записи которую вы хотите удалить.");
            this.toolTip1.SetToolTip(this.textBoxID, "Введите номер записи которую вы хотите удалить.");
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(188, 26);
            this.label.TabIndex = 1;
            this.label.Text = "Удаление записи";
            // 
            // buttonDeleting
            // 
            this.buttonDeleting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleting.Location = new System.Drawing.Point(17, 82);
            this.buttonDeleting.Name = "buttonDeleting";
            this.buttonDeleting.Size = new System.Drawing.Size(120, 40);
            this.buttonDeleting.TabIndex = 2;
            this.buttonDeleting.Text = "Удалить";
            this.buttonDeleting.UseVisualStyleBackColor = true;
            this.buttonDeleting.Click += new System.EventHandler(this.buttonDeleting_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonExit.Location = new System.Drawing.Point(17, 128);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(120, 40);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 199);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDeleting);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxID);
            this.Name = "Delete";
            this.Text = "Delete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonDeleting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button buttonExit;
    }
}