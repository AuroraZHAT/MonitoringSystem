namespace Aurora
{
    partial class Main
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
            this._buttonNewWrite = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._buttonRefresh = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._buttonTracks = new System.Windows.Forms.Button();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewWrite
            // 
            this._buttonNewWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonNewWrite.Location = new System.Drawing.Point(11, 358);
            this._buttonNewWrite.Name = "buttonNewWrite";
            this._buttonNewWrite.Size = new System.Drawing.Size(120, 37);
            this._buttonNewWrite.TabIndex = 1;
            this._buttonNewWrite.Text = "Добавить";
            this._buttonNewWrite.UseVisualStyleBackColor = true;
            this._buttonNewWrite.Click += new System.EventHandler(this.ButtonNewWriteClick);
            // 
            // buttonDelete
            // 
            this._buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonDelete.Location = new System.Drawing.Point(12, 404);
            this._buttonDelete.Name = "buttonDelete";
            this._buttonDelete.Size = new System.Drawing.Size(120, 37);
            this._buttonDelete.TabIndex = 1;
            this._buttonDelete.Text = "Удалить";
            this._buttonDelete.UseVisualStyleBackColor = true;
            this._buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // textBoxSearch
            // 
            this._textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this._textBoxSearch.Location = new System.Drawing.Point(137, 358);
            this._textBoxSearch.Name = "textBoxSearch";
            this._textBoxSearch.Size = new System.Drawing.Size(140, 38);
            this._textBoxSearch.TabIndex = 2;
            this._textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearchTextChanged);
            // 
            // buttonRefresh
            // 
            this._buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonRefresh.Location = new System.Drawing.Point(283, 357);
            this._buttonRefresh.Name = "buttonRefresh";
            this._buttonRefresh.Size = new System.Drawing.Size(120, 39);
            this._buttonRefresh.TabIndex = 1;
            this._buttonRefresh.Text = "Обновить";
            this._buttonRefresh.UseVisualStyleBackColor = true;
            this._buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
            // 
            // dataGridView
            // 
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(12, 28);
            this._dataGridView.Name = "dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(1245, 324);
            this._dataGridView.TabIndex = 3;
            // 
            // buttonTracks
            // 
            this._buttonTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonTracks.Location = new System.Drawing.Point(283, 402);
            this._buttonTracks.Name = "buttonTracks";
            this._buttonTracks.Size = new System.Drawing.Size(120, 39);
            this._buttonTracks.TabIndex = 4;
            this._buttonTracks.Text = "Трасса";
            this._buttonTracks.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "toolStrip1";
            this._toolStrip.Size = new System.Drawing.Size(1270, 25);
            this._toolStrip.TabIndex = 5;
            this._toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this._toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton.Name = "toolStripButton1";
            this._toolStripButton.Size = new System.Drawing.Size(96, 22);
            this._toolStripButton.Text = "Инструменты";
            // 
            // конфигураторToolStripMenuItem
            // 
            this._toolStripMenuItem.Name = "конфигураторToolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this._toolStripMenuItem.Text = "Конфигуратор";
            this._toolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 504);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._buttonTracks);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._textBoxSearch);
            this.Controls.Add(this._buttonDelete);
            this.Controls.Add(this._buttonRefresh);
            this.Controls.Add(this._buttonNewWrite);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonNewWrite;
        private System.Windows.Forms.Button _buttonDelete;
        private System.Windows.Forms.TextBox _textBoxSearch;
        private System.Windows.Forms.Button _buttonRefresh;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Button _buttonTracks;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton _toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem;
    }
}

