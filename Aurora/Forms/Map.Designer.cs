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
            this.компьютерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеОбъектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.измениеИнтерфейсовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьТипОбъектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюСистемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добвитьНовыйОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.объектыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компьютерToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 28);
            // 
            // компьютерToolStripMenuItem
            // 
            this.компьютерToolStripMenuItem.Name = "компьютерToolStripMenuItem";
            this.компьютерToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.компьютерToolStripMenuItem.Text = "Компьютер";
            this.компьютерToolStripMenuItem.Click += new System.EventHandler(this.компьютерToolStripMenuItem_Click);
            // 
            // объектыToolStripMenuItem
            // 
            this.объектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеОбъектыToolStripMenuItem,
            this.измениеИнтерфейсовToolStripMenuItem,
            this.добавитьТипОбъектаToolStripMenuItem,
            this.добавитьНовуюСистемуToolStripMenuItem,
            this.добвитьНовыйОбъектToolStripMenuItem,
            this.toolStripSeparator1});
            this.объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            this.объектыToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.объектыToolStripMenuItem.Text = "Объекты";
            // 
            // всеОбъектыToolStripMenuItem
            // 
            this.всеОбъектыToolStripMenuItem.Name = "всеОбъектыToolStripMenuItem";
            this.всеОбъектыToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
            this.всеОбъектыToolStripMenuItem.Text = "Все объекты";
            // 
            // измениеИнтерфейсовToolStripMenuItem
            // 
            this.измениеИнтерфейсовToolStripMenuItem.Name = "измениеИнтерфейсовToolStripMenuItem";
            this.измениеИнтерфейсовToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
            this.измениеИнтерфейсовToolStripMenuItem.Text = "Измение интерфейсов";
            this.измениеИнтерфейсовToolStripMenuItem.Click += new System.EventHandler(this.измениеИнтерфейсовToolStripMenuItem_Click);
            // 
            // добавитьТипОбъектаToolStripMenuItem
            // 
            this.добавитьТипОбъектаToolStripMenuItem.Name = "добавитьТипОбъектаToolStripMenuItem";
            this.добавитьТипОбъектаToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
            this.добавитьТипОбъектаToolStripMenuItem.Text = "Добавить тип объекта";
            this.добавитьТипОбъектаToolStripMenuItem.Click += new System.EventHandler(this.добавитьТипОбъектаToolStripMenuItem_Click);
            // 
            // добавитьНовуюСистемуToolStripMenuItem
            // 
            this.добавитьНовуюСистемуToolStripMenuItem.Name = "добавитьНовуюСистемуToolStripMenuItem";
            this.добавитьНовуюСистемуToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
            this.добавитьНовуюСистемуToolStripMenuItem.Text = "Добавить новую систему";
            this.добавитьНовуюСистемуToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовуюСистемуToolStripMenuItem_Click);
            // 
            // добвитьНовыйОбъектToolStripMenuItem
            // 
            this.добвитьНовыйОбъектToolStripMenuItem.Name = "добвитьНовыйОбъектToolStripMenuItem";
            this.добвитьНовыйОбъектToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
            this.добвитьНовыйОбъектToolStripMenuItem.Text = "Добвить новую запись";
            this.добвитьНовыйОбъектToolStripMenuItem.Click += new System.EventHandler(this.добвитьНовыйОбъектToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 581);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(981, 624);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьТипОбъектаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеОбъектыToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem компьютерToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem измениеИнтерфейсовToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem добвитьНовыйОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовуюСистемуToolStripMenuItem;
    }
}

