using System;

namespace Aurora.Forms.Interface
{
    partial class Main
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
            this.dataGridViewInterface = new System.Windows.Forms.DataGridView();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInterface)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInterface
            // 
            this.dataGridViewInterface.AllowUserToAddRows = false;
            this.dataGridViewInterface.AllowUserToOrderColumns = true;
            this.dataGridViewInterface.AllowUserToResizeColumns = false;
            this.dataGridViewInterface.AllowUserToResizeRows = false;
            this.dataGridViewInterface.ColumnHeadersHeight = 60;
            this.dataGridViewInterface.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewInterface.MultiSelect = false;
            this.dataGridViewInterface.Name = "dataGridViewInterface";
            this.dataGridViewInterface.RowHeadersVisible = false;
            this.dataGridViewInterface.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewInterface.ShowEditingIcon = false;
            this.dataGridViewInterface.Size = new System.Drawing.Size(185, 467);
            this.dataGridViewInterface.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(206, 12);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(106, 46);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(206, 64);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(106, 46);
            this.ButtonDelete.TabIndex = 2;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // ButtonChange
            // 
            this.ButtonChange.Location = new System.Drawing.Point(206, 116);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(106, 46);
            this.ButtonChange.TabIndex = 3;
            this.ButtonChange.Text = "Изменить";
            this.ButtonChange.UseVisualStyleBackColor = true;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChangeClick);
            // 
            // InterfaceMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(324, 491);
            this.Controls.Add(this.ButtonChange);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.dataGridViewInterface);
            this.Name = "InterfaceMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейсы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInterface)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.DataGridView dataGridViewInterface;
    }
}