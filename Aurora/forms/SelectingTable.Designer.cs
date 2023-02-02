namespace Aurora
{
    partial class SelectingTable
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
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonChoising = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(12, 12);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(130, 39);
            this.comboBoxTables.TabIndex = 0;
            // 
            // buttonChoising
            // 
            this.buttonChoising.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.buttonChoising.Location = new System.Drawing.Point(12, 57);
            this.buttonChoising.Name = "buttonChoising";
            this.buttonChoising.Size = new System.Drawing.Size(130, 39);
            this.buttonChoising.TabIndex = 1;
            this.buttonChoising.Text = "Выбрать";
            this.buttonChoising.UseVisualStyleBackColor = true;
            this.buttonChoising.Click += new System.EventHandler(this.buttonChoising_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.buttonExit.Location = new System.Drawing.Point(12, 102);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(130, 39);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ChoiseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 156);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonChoising);
            this.Controls.Add(this.comboBoxTables);
            this.Name = "ChoiseTable";
            this.Text = "ChoiseTable";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Button buttonChoising;
        private System.Windows.Forms.Button buttonExit;
    }
}