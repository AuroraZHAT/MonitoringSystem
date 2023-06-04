namespace Aurora.Config
{
    /// <summary>
    /// Таблица для конфигурации
    /// </summary>
    public class Table
    {
        private readonly string _name;
        private readonly string _header;
        private readonly bool _isComboBoxData;

        private readonly ColumnCollection _columns = new ColumnCollection();

        public string Name => _name;
        public ColumnCollection Columns => _columns;
        public string Header => _header;
        public bool IsComboBoxData => _isComboBoxData;
        
        public Table(string name, string header, bool IsComboBoxData,params Column[] columns) 
        {
            _name = name;
            _header = header;
            _isComboBoxData = IsComboBoxData;

            _columns.Add(new Column("ID", dataType: Column.DataType.INT, isNull: false));

            foreach (var column in columns)
            {
                _columns.Add(column);
            }
        }

        /// <summary>
        /// Процедурная генерация таблицы на основе данных из коллекции
        /// </summary>
        public string CreationQuery
        {
            get 
            {
                string query = $"CREATE TABLE [dbo].[{Name}]( ";

                for (int i = 0; i < _columns.Count; i++)
                {
                    query += $"[{_columns[i].Name}] ";

                    switch (_columns[i].Type)
                    {
                        case Column.DataType.INT:
                            query += $"[int] ";
                            break;

                        case Column.DataType.NVARCHAR:
                            query += $"[nvarchar] ({_columns[i].Length}) ";
                            break;

                        case Column.DataType.DATE:
                            query += $"[datetime] ";
                            break;
                    }

                    if (_columns[i].Name == "ID")
                        query += "IDENTITY(1, 1) ";

                    if (_columns[i].IsNull)
                        query += "NULL, ";
                    else
                        query += "NOT NULL, ";
                }

                query +=    $"CONSTRAINT[PK_{Name}] PRIMARY KEY CLUSTERED" +
                            $"( [{_columns[0].Name}] ASC ) WITH (PAD_INDEX = OFF," +
                            $" STATISTICS_NORECOMPUTE = OFF," +
                            $" IGNORE_DUP_KEY = OFF," +
                            $" ALLOW_ROW_LOCKS = ON," +
                            $" ALLOW_PAGE_LOCKS = ON," +
                            $" OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
                            $" ON[PRIMARY]) ON[PRIMARY]";

                return query;
            }
        }
    }
}
