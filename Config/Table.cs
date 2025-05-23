﻿using System.Text;

namespace MonitoringSystem.Config
{
    /// <summary>
    /// Таблица для конфигурации
    /// </summary>
    public class Table
    {
        private readonly string _name;
        private readonly string _header;
        private readonly bool _isComboBoxData;

        private readonly ColumnCollection _columns = new();

        public string Name => _name;
        public ColumnCollection Columns => _columns;
        public string Header => _header;
        public bool IsComboBoxData => _isComboBoxData;
        
        public Table(string name, string header, bool IsComboBoxData, params Column[] columns) 
        {
            (_name, _header, _isComboBoxData) = (name, header, IsComboBoxData)

            _columns.Add(new Column("ID", dataType: Column.DataType.INT, isNull: false));

            foreach (var column in columns)
            {
                _columns.Add(column);
            }
        }

        private string CreateColumns()
        {
            StringBuilder sb = new();

            for (int i = 0; i < _columns.Count; i++)
            {
                sb.Append($"[{_columns[i].Name}] ");
                
                sb.Append(new {"[int] ", "[nvarchar] ({_columns[i].Length}) ", "[datetime] "}[_columns[i].Type])

                if (_columns[i].Name == "ID")
                    sb.Append("IDENTITY(1, 1) ");

                sb.Append(_columns[i].IsNull ? "NULL, " : "NOT NULL, ");
            }

            return sb.ToString();
        }

        private string CreatePrimaryKey()
        {
            return $"CONSTRAINT[PK_{Name}] PRIMARY KEY CLUSTERED" +
                   $"( [{_columns[0].Name}] ASC ) WITH (PAD_INDEX = OFF," +
                   $" STATISTICS_NORECOMPUTE = OFF," +
                   $" IGNORE_DUP_KEY = OFF," +
                   $" ALLOW_ROW_LOCKS = ON," +
                   $" ALLOW_PAGE_LOCKS = ON," +
                   $" OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
                   $" ON[PRIMARY]) ON[PRIMARY]";
        }

        /// <summary>
        /// Процедурная генерация таблицы на основе данных из коллекции
        /// </summary>
        public string CreationQuery
        {
            get
            {
                return $"CREATE TABLE [dbo].[{Name}]( " + CreateColumns() + CreatePrimaryKey();
            }
        }
    }
}
