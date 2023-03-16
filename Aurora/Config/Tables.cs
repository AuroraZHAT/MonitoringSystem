namespace Aurora.Config
{
    public static class Tables
    {
        public enum ObjectTableColumns
        {
            ID,
            ObjectName,
            Type,
            OS,
            Location,
            X,
            Y,
            Interface,
            IP,
            HVID,
            MAC,
            LastDate,
            Responsible,
            InstalledBy
        }

        public static Table Objects = new Table("Objects", 
            new Column("ID", false), 
            new Column("Object", false), 
            new Column("Type", true), 
            new Column("Operating System", true), 
            new Column("Interface", true), 
            new Column("Location", true), 
            new Column("X", false), 
            new Column("Y", false), 
            new Column("IP", false), 
            new Column("MAC", false), 
            new Column("HVID", false), 
            new Column("Last Date On", false), 
            new Column("Responsible", false), 
            new Column("Installed By", false));

        public static Table Types = new Table("Types", 
            new Column("ID", false), 
            new Column("Type", false));

        public static Table Interfaces = new Table("Interfaces", 
            new Column("ID", false), 
            new Column("Interface", false));

        public static Table Locations = new Table("Locations", 
            new Column("ID", false), 
            new Column("Location", false));

        public static Table OperatingSystems = new Table("Operating Systems", 
            new Column("ID", false), 
            new Column("Operating System", false));

        public static string ObjectTypesQuery =>
        (
            $"CREATE TABLE [dbo].[{Types.Name}](" +
            $"[{Types.Columns[0].Name}][int] IDENTITY(1, 1) NOT NULL," +
            $"[{Types.Columns[1].Name}] [nvarchar] (15) NULL," +
            $"CONSTRAINT[PK_{Types.Name}] PRIMARY KEY CLUSTERED" +
            $"( [{Types.Columns[0].Name}] ASC ) WITH (PAD_INDEX = OFF," +
            $" STATISTICS_NORECOMPUTE = OFF," +
            $" IGNORE_DUP_KEY = OFF," +
            $" ALLOW_ROW_LOCKS = ON," +
            $" ALLOW_PAGE_LOCKS = ON," +
            $" OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            $" ON[PRIMARY]) ON[PRIMARY]"
        );

        public static string InterfacesQuery =>
        (
            $"CREATE TABLE [dbo].[{Interfaces.Name}](" +
            $"[{Interfaces.Columns[0].Name}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{Interfaces.Columns[1].Name}] [nvarchar](10) NOT NULL," +
            $"CONSTRAINT [PK_{Interfaces.Name}] PRIMARY KEY CLUSTERED" +
            $"( [{Interfaces.Columns[0].Name}] ASC) WITH (PAD_INDEX = OFF, " +
            $"STATISTICS_NORECOMPUTE = OFF, " +
            $"IGNORE_DUP_KEY = OFF, " +
            $"ALLOW_ROW_LOCKS = ON, " +
            $"ALLOW_PAGE_LOCKS = ON, " +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string LocationsQuery =>
        (
            $"CREATE TABLE [dbo].[{Locations.Name}](" +
            $"[{Locations.Columns[0].Name}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{Locations.Columns[1].Name}] [nvarchar](20) NOT NULL," +
            $" CONSTRAINT [PK_{Locations.Name}] PRIMARY KEY CLUSTERED " +
            $"( [{Locations.Columns[0].Name}] ASC )WITH (PAD_INDEX = OFF, " +
            $"STATISTICS_NORECOMPUTE = OFF, " +
            $"IGNORE_DUP_KEY = OFF, " +
            $"ALLOW_ROW_LOCKS = ON, " +
            $"ALLOW_PAGE_LOCKS = ON, " +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string OperatingSystemsQuery =>
        (
            $"CREATE TABLE [dbo].[{OperatingSystems.Name}](" +
            $"[{OperatingSystems.Columns[0].Name}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{OperatingSystems.Columns[1].Name}] [nvarchar](30) NOT NULL," +
            $"CONSTRAINT [PK_{OperatingSystems.Name}] PRIMARY KEY CLUSTERED" +
            $"( [{OperatingSystems.Columns[0].Name}] ASC )WITH (PAD_INDEX = OFF," +
            $"STATISTICS_NORECOMPUTE = OFF," +
            $"IGNORE_DUP_KEY = OFF," +
            $"ALLOW_ROW_LOCKS = ON," +
            $"ALLOW_PAGE_LOCKS = ON," +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string ObjectsQuery =>
        (
            $"CREATE TABLE [dbo].[{Objects.Name}](" +
            $"[{Objects.Columns[0].Name}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{Objects.Columns[1].Name}] [nvarchar](25) NULL," +
            $"[{Objects.Columns[2].Name}] [nvarchar](25) NULL," +
            $"[{Objects.Columns[3].Name}] [nvarchar](25) NULL," +
            $"[{Objects.Columns[4].Name}] [nvarchar](25) NULL," +
            $"[{Objects.Columns[5].Name}] [nvarchar](25) NULL," +
            $"[{Objects.Columns[6].Name}] [int] NULL," +
            $"[{Objects.Columns[7].Name}] [int] NULL," +
            $"[{Objects.Columns[8].Name}] [nvarchar](15) NULL," +
            $"[{Objects.Columns[9].Name}] [nvarchar](24) NULL," +
            $"[{Objects.Columns[10].Name}] [nvarchar](15) NULL," +
            $"[{Objects.Columns[11].Name}] [datetime] NULL," +
            $"[{Objects.Columns[12].Name}] [nvarchar](20) NULL," +
            $"[{Objects.Columns[13].Name}] [nvarchar](20) NULL," +
            $" CONSTRAINT [PK_{Objects.Name}] PRIMARY KEY CLUSTERED ( [{Objects.Columns[0].Name}] ASC ) " +
            $"WITH " +
            $"(PAD_INDEX = OFF, " +
            $"STATISTICS_NORECOMPUTE = OFF, " +
            $"IGNORE_DUP_KEY = OFF, " +
            $"ALLOW_ROW_LOCKS = ON, " +
            $"ALLOW_PAGE_LOCKS = ON, " +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) "+ 
            $"ON [PRIMARY]) ON [PRIMARY]"
        );
    }
}
