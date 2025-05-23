﻿using System.Collections;

namespace MonitoringSystem.Config
{
    /// <summary>
    /// Коллекция колонн для конфигурации
    /// </summary>
    public class ColumnCollection : IEnumerable<Column>
    {
        private readonly List<Column> _items = new();
        public Column this[int index] => _items[index];
        public int Count => _items.Count;

        public Column this[string columnName]
        {
            get
            {
                if (columnName == null)
                {
                    throw new ArgumentNullException(nameof(columnName));
                }

                int count = _items.Count;
                for (int i = 0; i < count; i++)
                {
                    Column column = _items[i];
                    if (string.Equals(column.Name, columnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return column;
                    }
                }

                throw new ArgumentOutOfRangeException($"Колонки по названием {columnName} не существует");
            }
        }

        public void Add(Column column)
        {
            _items.Add(column);
        }

        public IEnumerator<Column> GetEnumerator()
        {
            return ((IEnumerable<Column>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }
    }
}
