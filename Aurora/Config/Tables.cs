namespace Aurora.Config
{
    public static class Tables
    {
        public static readonly string ID = "ID";

        public static readonly string OBJECT_TYPES_TABLE_NAME = "Object Types";
        public static readonly string TYPE_NAME = "Type";

        public static readonly string INTERFACES_TABLE_NAME = "Interfaces";
        public static readonly string INTERFACE_NAME = "Interface";

        public static readonly string LOCATIONS_TABLE_NAME = "Locations";
        public static readonly string LOCATION_NAME = "Location";
        public static readonly string OBJECT_X = "X";
        public static readonly string OBJECT_Y = "Y";

        public static readonly string OS_TABLE_NAME = "Operating Systems";
        public static readonly string OS_NAME = "OS";

        public static readonly string OBJECTS_TABLE_NAME = "Objects";
        public static readonly string OBJECT_NAME = "Object";
        public static readonly string OBJECT_TYPE_ID = "Type ID";
        public static readonly string OBJECT_OS_ID = "OS ID";
        public static readonly string OBJECT_INTERFACE_ID = "Interface ID";
        public static readonly string OBJECT_LOCATION_ID = "Location ID";
        public static readonly string OBJECT_IP = "IP";
        public static readonly string OBJECT_MAC_ADRESS = "MAC";
        public static readonly string OBJECT_HVID = "HVID";
        public static readonly string OBJECT_LAST_DATE_ON = "Last Date On";
        public static readonly string OBJECT_RESPONSIBLE = "Responsible";
        public static readonly string OBJECT_INSTALLED_BY = "Installed By";

        public static string ObjectTypes =>
        (
            $"CREATE TABLE [dbo].[{OBJECT_TYPES_TABLE_NAME}](" +
            $"[{ID}][int] IDENTITY(1, 1) NOT NULL," +
            $"[{TYPE_NAME}] [nvarchar] (15) NULL," +
            $"CONSTRAINT[PK_{OBJECT_TYPES_TABLE_NAME}] PRIMARY KEY CLUSTERED" +
            $"( [{ID}] ASC ) WITH (PAD_INDEX = OFF," +
            $" STATISTICS_NORECOMPUTE = OFF," +
            $" IGNORE_DUP_KEY = OFF," +
            $" ALLOW_ROW_LOCKS = ON," +
            $" ALLOW_PAGE_LOCKS = ON," +
            $" OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            $" ON[PRIMARY]) ON[PRIMARY]"
        );

        public static string Interfaces =>
        (
            $"CREATE TABLE [dbo].[{INTERFACES_TABLE_NAME}](" +
            $"[{ID}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{INTERFACE_NAME}] [nvarchar](10) NOT NULL," +
            $"CONSTRAINT [PK_{INTERFACES_TABLE_NAME}] PRIMARY KEY CLUSTERED" +
            $"( [{ID}] ASC) WITH (PAD_INDEX = OFF, " +
            $"STATISTICS_NORECOMPUTE = OFF, " +
            $"IGNORE_DUP_KEY = OFF, " +
            $"ALLOW_ROW_LOCKS = ON, " +
            $"ALLOW_PAGE_LOCKS = ON, " +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string Locations =>
        (
            $"CREATE TABLE [dbo].[{LOCATIONS_TABLE_NAME}](" +
            $"[{ID}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{LOCATION_NAME}] [nvarchar](20) NOT NULL," +
            $"[{OBJECT_X}] [int] NULL," +
            $"[{OBJECT_Y}] [int] NULL," +
            $" CONSTRAINT [PK_{LOCATIONS_TABLE_NAME}] PRIMARY KEY CLUSTERED " +
            $"( [{ID}] ASC )WITH (PAD_INDEX = OFF, " +
            $"STATISTICS_NORECOMPUTE = OFF, " +
            $"IGNORE_DUP_KEY = OFF, " +
            $"ALLOW_ROW_LOCKS = ON, " +
            $"ALLOW_PAGE_LOCKS = ON, " +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string OperatingSystems =>
        (
            $"CREATE TABLE [dbo].[{OS_TABLE_NAME}](" +
            $"[{ID}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{OS_NAME}] [nchar](30) NOT NULL," +
            $"CONSTRAINT [PK_{OS_TABLE_NAME}] PRIMARY KEY CLUSTERED" +
            $"( [{ID}] ASC )WITH (PAD_INDEX = OFF," +
            $"STATISTICS_NORECOMPUTE = OFF," +
            $"IGNORE_DUP_KEY = OFF," +
            $"ALLOW_ROW_LOCKS = ON," +
            $"ALLOW_PAGE_LOCKS = ON," +
            $"OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            $"ON [PRIMARY]) ON [PRIMARY]"
        );

        public static string Objects =>
        (
            $"CREATE TABLE [dbo].[{OBJECTS_TABLE_NAME}](" +
            $"[{ID}] [int] IDENTITY(1,1) NOT NULL," +
            $"[{OBJECT_NAME}] [nvarchar](25) NULL," +
            $"[{OBJECT_TYPE_ID}] [int] NULL," +
            $"[{OBJECT_OS_ID}] [int] NULL," +
            $"[{OBJECT_LOCATION_ID}] [int] NULL," +
            $"[{OBJECT_INTERFACE_ID}] [int] NULL," +
            $"[{OBJECT_IP}] [nvarchar](15) NULL," +
            $"[{OBJECT_HVID}] [nvarchar](24) NULL," +
            $"[{OBJECT_MAC_ADRESS}] [nvarchar](15) NULL," +
            $"[{OBJECT_LAST_DATE_ON}] [datetime] NULL," +
            $"[{OBJECT_RESPONSIBLE}] [nvarchar](20) NULL," +
            $"[{OBJECT_INSTALLED_BY}] [nvarchar](20) NULL," +
            $" CONSTRAINT [PK_{OBJECTS_TABLE_NAME}] PRIMARY KEY CLUSTERED ( [{ID}] ASC ) " +
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
