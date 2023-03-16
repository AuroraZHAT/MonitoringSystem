using System.Windows.Forms;

namespace Aurora
{
    public static class BoxConverter
    {
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
