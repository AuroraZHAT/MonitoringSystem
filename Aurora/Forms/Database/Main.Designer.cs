﻿using Aurora.Config;
using System;
using System.Windows.Forms;

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
            this._buttonLoad = new System.Windows.Forms.Button();
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._buttonRefresh = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._buttonTracks = new System.Windows.Forms.Button();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._toolStripServerSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._searchButton = new System.Windows.Forms.Button();
            this._resetButton = new System.Windows.Forms.Button();
            this._buttonsPanel = new System.Windows.Forms.Panel();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._objectsTabPage = new System.Windows.Forms.TabPage();
            this._typesTabPage = new System.Windows.Forms.TabPage();
            this._interfacesTabPage = new System.Windows.Forms.TabPage();
            this._OSTabPage = new System.Windows.Forms.TabPage();
            this._locationTabPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this._buttonsPanel.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._objectsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonLoad
            // 
            this._buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._buttonLoad.Location = new System.Drawing.Point(12, 11);
            this._buttonLoad.Name = "_buttonLoad";
            this._buttonLoad.Size = new System.Drawing.Size(120, 84);
            this._buttonLoad.TabIndex = 1;
            this._buttonLoad.Text = "Загрузить изменения";
            this._buttonLoad.UseVisualStyleBackColor = true;
            this._buttonLoad.Click += new System.EventHandler(this.OnButtonLoadClick);
            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this._textBoxSearch.Location = new System.Drawing.Point(563, 11);
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
            this._buttonRefresh.Click += new System.EventHandler(this.OnButtonRefreshClick);
            // 
            // _dataGridView
            // 
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(3, 3);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(807, 433);
            this._dataGridView.TabIndex = 3;
            this._dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this._dataGridView_CellBeginEdit);
            this._dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValueChanged);
            this._dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataError);
            this._dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.OnRowDeleted);
            this._dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnRowDeleting);
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
            this._toolStripServerSettings});
            this._toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton.Name = "_toolStripButton";
            this._toolStripButton.Size = new System.Drawing.Size(96, 22);
            this._toolStripButton.Text = "Инструменты";
            // 
            // _toolStripServerSettings
            // 
            this._toolStripServerSettings.Name = "_toolStripServerSettings";
            this._toolStripServerSettings.Size = new System.Drawing.Size(154, 22);
            this._toolStripServerSettings.Text = "Конфигуратор";
            this._toolStripServerSettings.Click += new System.EventHandler(this.OnToolStripServerSettingsClick);
            // 
            // _searchButton
            // 
            this._searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._searchButton.Location = new System.Drawing.Point(563, 55);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(120, 40);
            this._searchButton.TabIndex = 6;
            this._searchButton.Text = "Поиск";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.OnButtonSearchClick);
            // 
            // _resetButton
            // 
            this._resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this._resetButton.Location = new System.Drawing.Point(689, 55);
            this._resetButton.Name = "_resetButton";
            this._resetButton.Size = new System.Drawing.Size(120, 40);
            this._resetButton.TabIndex = 7;
            this._resetButton.Text = "Сбросить";
            this._resetButton.UseVisualStyleBackColor = true;
            this._resetButton.Click += new System.EventHandler(this.OnButtonResetClick);
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._comboBox);
            this._buttonsPanel.Controls.Add(this._buttonLoad);
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
            // _comboBox
            // 
            this._comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Location = new System.Drawing.Point(359, 10);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(198, 39);
            this._comboBox.TabIndex = 8;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._objectsTabPage);
            this._tabControl.Controls.Add(this._typesTabPage);
            this._tabControl.Controls.Add(this._interfacesTabPage);
            this._tabControl.Controls.Add(this._OSTabPage);
            this._tabControl.Controls.Add(this._locationTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 25);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(821, 465);
            this._tabControl.TabIndex = 9;
            this._tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
            // 
            // _objectsTabPage
            // 
            this._objectsTabPage.Controls.Add(this._dataGridView);
            this._objectsTabPage.Location = new System.Drawing.Point(4, 22);
            this._objectsTabPage.Name = "_objectsTabPage";
            this._objectsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._objectsTabPage.Size = new System.Drawing.Size(813, 439);
            this._objectsTabPage.TabIndex = 0;
            this._objectsTabPage.Text = "Объекты";
            this._objectsTabPage.UseVisualStyleBackColor = true;
            // 
            // _typesTabPage
            // 
            this._typesTabPage.Location = new System.Drawing.Point(4, 22);
            this._typesTabPage.Name = "_typesTabPage";
            this._typesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._typesTabPage.Size = new System.Drawing.Size(813, 439);
            this._typesTabPage.TabIndex = 1;
            this._typesTabPage.Text = "Типы";
            this._typesTabPage.UseVisualStyleBackColor = true;
            // 
            // _interfacesTabPage
            // 
            this._interfacesTabPage.Location = new System.Drawing.Point(4, 22);
            this._interfacesTabPage.Name = "_interfacesTabPage";
            this._interfacesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._interfacesTabPage.Size = new System.Drawing.Size(813, 439);
            this._interfacesTabPage.TabIndex = 2;
            this._interfacesTabPage.Text = "Интерфейсы";
            this._interfacesTabPage.UseVisualStyleBackColor = true;
            // 
            // _OSTabPage
            // 
            this._OSTabPage.Location = new System.Drawing.Point(4, 22);
            this._OSTabPage.Name = "_OSTabPage";
            this._OSTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._OSTabPage.Size = new System.Drawing.Size(813, 439);
            this._OSTabPage.TabIndex = 3;
            this._OSTabPage.Text = "Операционные системы";
            this._OSTabPage.UseVisualStyleBackColor = true;
            // 
            // _locationTabPage
            // 
            this._locationTabPage.Location = new System.Drawing.Point(4, 22);
            this._locationTabPage.Name = "_locationTabPage";
            this._locationTabPage.Size = new System.Drawing.Size(813, 439);
            this._locationTabPage.TabIndex = 4;
            this._locationTabPage.Text = "Локации";
            this._locationTabPage.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 490);
            this.Controls.Add(this._buttonsPanel);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._toolStrip);
            this.Name = "Main";
            this.Text = "База данных";
            this.Load += new System.EventHandler(this.OnMainLoad);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._objectsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonLoad;
        private System.Windows.Forms.TextBox _textBoxSearch;
        private System.Windows.Forms.Button _buttonRefresh;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Button _buttonTracks;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton _toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem _toolStripServerSettings;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.Button _resetButton;
        private System.Windows.Forms.Panel _buttonsPanel;
        private TabControl _tabControl;
        private TabPage _objectsTabPage;
        private TabPage _typesTabPage;
        private TabPage _interfacesTabPage;
        private TabPage _OSTabPage;
        private ComboBox _comboBox;
        private TabPage _locationTabPage;
    }
}

