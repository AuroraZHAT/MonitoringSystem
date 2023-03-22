namespace Aurora.Config
{
    public static class Tables
    {
        private static readonly Table _objects = new Table("Objects", "Объекты", false,
            new Column("Name"), 
            new Column("Type", isComboBox: true), 
            new Column("Operating System", isComboBox: true), 
            new Column("Interface", isComboBox: true), 
            new Column("Location", isComboBox: true), 
            new Column("X", dataType: Column.DataType.INT), 
            new Column("Y", dataType: Column.DataType.INT), 
            new Column("IP"), 
            new Column("MAC"), 
            new Column("HVID"), 
            new Column("Last Date On", dataType: Column.DataType.DATE), 
            new Column("Responsible"), 
            new Column("Installed By"));

        private static readonly Table _types = new Table("Types", "Типы", true,
            new Column("Type"));

        private static readonly Table _interfaces = new Table("Interfaces", "Интерфейсы", true,
            new Column("Interface"));

        private static readonly Table _locations = new Table("Locations", "Локации", true,
            new Column("Location"));

        private static readonly Table _operatingSystems = new Table("Operating Systems", "Операционные системы", true,
            new Column("Operating System", false));

        public static Table[] Items => new Table[] { _objects, _types, _interfaces, _locations, _operatingSystems };
    }
}
