namespace Aurora.Config
{
    public class Table
    {
        private readonly string _name;
        private readonly ColumnCollection _columns = new ColumnCollection();

        public string Name => _name;
        public ColumnCollection Columns => _columns;
        
        public Table(string name, params Column[] columns) 
        {
            _name = name;
            foreach (var column in columns)
            {
                _columns.Add(column);
            }
        }
    }
}
