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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeInterfacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddObjectTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ObjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.ComputerToolStripMenuItem.Click += new System.EventHandler(this.ComputerToolStripMenuItemClick);
            // 
            // ObjectsToolStripMenuItem
            // 
            this.ObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllObjectsToolStripMenuItem,
            this.ChangeInterfacesToolStripMenuItem,
            this.AddObjectTypeToolStripMenuItem,
            this.AddNewOSToolStripMenuItem,
            this.AddNewObjectToolStripMenuItem,
            this.toolStripSeparator1});
            this.ObjectsToolStripMenuItem.Name = "ObjectsToolStripMenuItem";
            this.ObjectsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.ObjectsToolStripMenuItem.Text = "Объекты";
            // 
            // AllObjectsToolStripMenuItem
            // 
            this.AllObjectsToolStripMenuItem.Name = "AllObjectsToolStripMenuItem";
            this.AllObjectsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.AllObjectsToolStripMenuItem.Text = "Все объекты";
            // 
            // ChangeInterfacesToolStripMenuItem
            // 
            this.ChangeInterfacesToolStripMenuItem.Name = "ChangeInterfacesToolStripMenuItem";
            this.ChangeInterfacesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.ChangeInterfacesToolStripMenuItem.Text = "Измение интерфейсов";
            this.ChangeInterfacesToolStripMenuItem.Click += new System.EventHandler(this.ChangeInterfacesToolStripMenuItemClick);
            // 
            // AddObjectTypeToolStripMenuItem
            // 
            this.AddObjectTypeToolStripMenuItem.Name = "AddObjectTypeToolStripMenuItem";
            this.AddObjectTypeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.AddObjectTypeToolStripMenuItem.Text = "Добавить тип объекта";
            // 
            // AddNewSystemToolStripMenuItem
            // 
            this.AddNewOSToolStripMenuItem.Name = "AddNewSystemToolStripMenuItem";
            this.AddNewOSToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.AddNewOSToolStripMenuItem.Text = "Добавить новую систему";
            this.AddNewOSToolStripMenuItem.Click += new System.EventHandler(this.AddNewOSToolStripMenuItemClick);
            // 
            // AddNewObjectToolStripMenuItem
            // 
            this.AddNewObjectToolStripMenuItem.Name = "AddNewObjectToolStripMenuItem";
            this.AddNewObjectToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.AddNewObjectToolStripMenuItem.Text = "Добвить новую запись";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel.BackgroundImage")));
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.pictureBox2);
            this.panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel.Location = new System.Drawing.Point(12, 31);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(957, 581);
            this.panel.TabIndex = 1;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(981, 624);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Map";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddObjectTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllObjectsToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ComputerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem ChangeInterfacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AddNewObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewOSToolStripMenuItem;
    }
}

