using System.Windows.Forms;

namespace Aurora
{
    /// <summary>
    /// Конвертатор Box'ев из DataGridView
    /// </summary>
    public static class BoxConverter
    {
        /// <summary>
        /// Конвертирует колонну Box в ComboBox
        /// </summary>
        /// <param name="dataGridViewColumn"></param>
        /// <returns></returns>
        public static DataGridViewComboBoxColumn ToComboBoxColumn(DataGridViewColumn dataGridViewColumn)
        {
            var dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = dataGridViewColumn.HeaderText,
                Name = dataGridViewColumn.Name,
                DataPropertyName = dataGridViewColumn.DataPropertyName
            };

            return dataGridViewComboBoxColumn;
        }
    }
}
