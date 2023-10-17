namespace MonitoringSystem.Config
{
    public class Column
    {
        public enum DataType
        {
            NVARCHAR,
            DATE,
            INT
        }

        public string Name { get; private set; }
        public bool IsComboBox { get; private set; }
        public DataType Type { get; private set; }
        public int Length { get; private set; }

        public bool IsNull { get; private set; }

        public Column (string name, 
                       bool isComboBox = false, 
                       DataType dataType = DataType.NVARCHAR, 
                       bool isNull = true, 
                       int length = 25)
        {
            (Name, IsComboBox, Type, Length, IsNull) = (name, isComboBox, dataType, length, isNull)
        }
    }
}
