namespace Aurora.Forms
{
    partial class Map
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.pictureBoxPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComputerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
            // 
            // ComputerToolStripMenuItem
            // 
            this.ComputerToolStripMenuItem.Name = "ComputerToolStripMenuItem";
            this.ComputerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ComputerToolStripMenuItem.Text = "Компьютер";
            // 
            // pictureBoxPanel
            // 
            this.pictureBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pictureBoxPanel.Controls.Add(this.panel2);
            this.pictureBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPanel.Name = "pictureBoxPanel";
            this.pictureBoxPanel.Size = new System.Drawing.Size(981, 624);
            this.pictureBoxPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 524);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 100);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnLoadImageButtonClick);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(981, 624);
            this.Controls.Add(this.pictureBoxPanel);
            this.Name = "Map";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.pictureBoxPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ComputerToolStripMenuItem;
        private System.Windows.Forms.Panel pictureBoxPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}

