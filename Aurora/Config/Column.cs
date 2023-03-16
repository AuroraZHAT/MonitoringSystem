namespace Aurora.Config
{
    public class Column
    {
        public string Name { get; private set; }
        public bool IsComboBox { get; private set; }

        public Column (string name, bool isComboBox)
        {
            Name = name;
            IsComboBox = isComboBox;
        }
    }
}
