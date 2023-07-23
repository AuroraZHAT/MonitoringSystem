 namespace MonitoringSystem.Config
{
    public static class Tables
    {
        private static readonly Table _objects = new("Objects", "Объекты", false,
            new("Name"), 
            new("Type", isComboBox: true), 
            new("Operating System", isComboBox: true), 
            new("Interface", isComboBox: true), 
            new("Location", isComboBox: true), 
            new("X", dataType: Column.DataType.INT), 
            new("Y", dataType: Column.DataType.INT), 
            new("IP"), 
            new("MAC"), 
            new("HVID"), 
            new("Last Date On", dataType: Column.DataType.DATE), 
            new("Responsible"), 
            new("Installed By"));

        private static readonly Table _types = new("Types", "Типы", true, new Column("Type"));

        private static readonly Table _interfaces = new("Interfaces", "Интерфейсы", true, new Column("Interface"));

        private static readonly Table _locations = new("Locations", "Локации", true, new Column("Location"));

        private static readonly Table _operatingSystems = new("Operating Systems", "Операционные системы", true, new Column("Operating System", false));

        public static List<Table> Items => new() { _objects, _types, _interfaces, _locations, _operatingSystems };
    }
}
