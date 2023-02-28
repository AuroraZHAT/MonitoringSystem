namespace Aurora.Forms.Database
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
            this._toolStripServerSetup = new System.Windows.Forms.ToolStripMenuItem();
            this._searchButton = new System.Windows.Forms.Button();
            this._resetButton = new System.Windows.Forms.Button();
            this._buttonsPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonNewWrite
            // 
            this._buttonNewWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonNewWrite.Location = new System.Drawing.Point(12, 11);
            this._buttonNewWrite.Name = "_buttonNewWrite";
            this._buttonNewWrite.Size = new System.Drawing.Size(120, 40);
            this._buttonNewWrite.TabIndex = 1;
            this._buttonNewWrite.Text = "Добавить";
            this._buttonNewWrite.UseVisualStyleBackColor = true;
            this._buttonNewWrite.Click += new System.EventHandler(this.ButtonNewWriteClick);
            // 
            // _buttonDelete
            // 
            this._buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonDelete.Location = new System.Drawing.Point(12, 57);
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Size = new System.Drawing.Size(120, 40);
            this._buttonDelete.TabIndex = 1;
            this._buttonDelete.Text = "Удалить";
            this._buttonDelete.UseVisualStyleBackColor = true;
            this._buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this._textBoxSearch.Location = new System.Drawing.Point(274, 11);
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.Size = new System.Drawing.Size(246, 38);
            this._textBoxSearch.TabIndex = 2;
            // 
            // _buttonRefresh
            // 
            this._buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonRefresh.Location = new System.Drawing.Point(138, 11);
            this._buttonRefresh.Name = "_buttonRefresh";
            this._buttonRefresh.Size = new System.Drawing.Size(120, 40);
            this._buttonRefresh.TabIndex = 1;
            this._buttonRefresh.Text = "Обновить";
            this._buttonRefresh.UseVisualStyleBackColor = true;
            this._buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
            // 
            // _dataGridView
            // 
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 25);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(821, 358);
            this._dataGridView.TabIndex = 3;
            // 
            // _buttonTracks
            // 
            this._buttonTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonTracks.Location = new System.Drawing.Point(138, 57);
            this._buttonTracks.Name = "_buttonTracks";
            this._buttonTracks.Size = new System.Drawing.Size(120, 40);
            this._buttonTracks.TabIndex = 4;
            this._buttonTracks.Text = "Трасса";
            this._buttonTracks.UseVisualStyleBackColor = true;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(821, 25);
            this._toolStrip.TabIndex = 5;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _toolStripButton
            // 
            this._toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripServerSetup});
            this._toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton.Name = "_toolStripButton";
            this._toolStripButton.Size = new System.Drawing.Size(96, 22);
            this._toolStripButton.Text = "Инструменты";
            // 
            // _toolStripServerSetup
            // 
            this._toolStripServerSetup.Name = "_toolStripServerSetup";
            this._toolStripServerSetup.Size = new System.Drawing.Size(154, 22);
            this._toolStripServerSetup.Text = "Конфигуратор";
            this._toolStripServerSetup.Click += new System.EventHandler(this.ToolStripServerSetupClick);
            // 
            // _searchButton
            // 
            this._searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._searchButton.Location = new System.Drawing.Point(274, 57);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(120, 40);
            this._searchButton.TabIndex = 6;
            this._searchButton.Text = "Поиск";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // _resetButton
            // 
            this._resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._resetButton.Location = new System.Drawing.Point(400, 57);
            this._resetButton.Name = "_resetButton";
            this._resetButton.Size = new System.Drawing.Size(120, 40);
            this._resetButton.TabIndex = 7;
            this._resetButton.Text = "Сбросить";
            this._resetButton.UseVisualStyleBackColor = true;
            this._resetButton.Click += new System.EventHandler(this.ResetButtonClick);
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._buttonNewWrite);
            this._buttonsPanel.Controls.Add(this._buttonDelete);
            this._buttonsPanel.Controls.Add(this._buttonTracks);
            this._buttonsPanel.Controls.Add(this._resetButton);
            this._buttonsPanel.Controls.Add(this._buttonRefresh);
            this._buttonsPanel.Controls.Add(this._searchButton);
            this._buttonsPanel.Controls.Add(this._textBoxSearch);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 383);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(821, 107);
            this._buttonsPanel.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 490);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._buttonsPanel);
            this.Controls.Add(this._toolStrip);
            this.Name = "Main";
            this.Text = "База данных";
            this.Load += new System.EventHandler(this.OnMainLoad);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem _toolStripServerSetup;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.Button _resetButton;
        private System.Windows.Forms.Panel _buttonsPanel;
    }
}

