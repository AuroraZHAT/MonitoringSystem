namespace Aurora.Config
{
    public struct Tables
    {
        public string ObjectTypes =>
        (
            "ALTER TABLE[dbo].[ObjectsType](" +
            "[id][int] IDENTITY(1, 1) NOT NULL," +
            "[TypeName] [nchar] (15) NULL," +
            "CONSTRAINT[PK_ObjectsType] PRIMARY KEY CLUSTERED" +
            "( [id] ASC ) WITH (PAD_INDEX = OFF," +
            " STATISTICS_NORECOMPUTE = OFF," +
            " IGNORE_DUP_KEY = OFF," +
            " ALLOW_ROW_LOCKS = ON," +
            " ALLOW_PAGE_LOCKS = ON," +
            " OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            " ON[PRIMARY]) ON[PRIMARY]"
        );

        public string Interfaces =>
        (
            "ALTER TABLE [dbo].[Interfaces](" +
            "[id] [int] IDENTITY(1,1) NOT NULL," +
            "[Interface] [nchar](10) NOT NULL," +
            "[MAC_Address] [nchar](12) NULL," +
            "CONSTRAINT [PK_Interfaces] PRIMARY KEY CLUSTERED" +
            "( [id] ASC) WITH (PAD_INDEX = OFF, " +
            "STATISTICS_NORECOMPUTE = OFF, " +
            "IGNORE_DUP_KEY = OFF, " +
            "ALLOW_ROW_LOCKS = ON, " +
            "ALLOW_PAGE_LOCKS = ON, " +
            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            "ON [PRIMARY]) ON [PRIMARY]"
        );

        public string MapLocations =>
        (
            "ALTER TABLE [dbo].[LocationMap](" +
            "[id] [int] IDENTITY(1,1) NOT NULL," +
            "[Location_Map] [nvarchar](20) NULL," +
            "[Path_Map] [nchar](50) NULL," +
            "[X] [int] NULL," +
            "[Y] [int] NULL," +
            " CONSTRAINT [PK_LocationMap] PRIMARY KEY CLUSTERED " +
            "( [id] ASC )WITH (PAD_INDEX = OFF, " +
            "STATISTICS_NORECOMPUTE = OFF, " +
            "IGNORE_DUP_KEY = OFF, " +
            "ALLOW_ROW_LOCKS = ON, " +
            "ALLOW_PAGE_LOCKS = ON, " +
            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
            "ON [PRIMARY]) ON [PRIMARY]"
        );

        public string OperatingSystems =>
        (
            "ALTER TABLE [dbo].[OS](" +
            "[id] [int] IDENTITY(1,1) NOT NULL," +
            "[OS_name] [nchar](30) NOT NULL," +
            "CONSTRAINT [PK_OS] PRIMARY KEY CLUSTERED" +
            "( [id] ASC )WITH (PAD_INDEX = OFF," +
            "STATISTICS_NORECOMPUTE = OFF," +
            "IGNORE_DUP_KEY = OFF," +
            "ALLOW_ROW_LOCKS = ON," +
            "ALLOW_PAGE_LOCKS = ON," +
            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
            "ON [PRIMARY]) ON [PRIMARY]"
        );

        public string Objects =>
        (
            "ALTER TABLE [dbo].[Object](" +
            "[id] [int] IDENTITY(1,1) NOT NULL," +
            "[ObjectName] [nchar](25) NULL," +
            "[ObjectType_id] [int] NULL," +
            "[OS_id] [int] NULL," +
            "[LocationMap_id] [int] NULL," +
            "[Last_IP] [nchar](15) NULL," +
            "[HVID] [nchar](24) NULL," +
            "[Interfaces_ID] [int] NULL," +
            "[Last_Date_ON] [datetime] NULL," +
            "[Responsible] [nvarchar](20) NULL," +
            "[Installed] [nvarchar](20) NULL," +
            " CONSTRAINT [PK_Object] PRIMARY KEY CLUSTERED " +
            "( [id] ASC )WITH (PAD_INDEX = OFF, " +
            "STATISTICS_NORECOMPUTE = OFF, " +
            "IGNORE_DUP_KEY = OFF, " +
            "ALLOW_ROW_LOCKS = ON, " +
            "ALLOW_PAGE_LOCKS = ON, " +
            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) "
            + "ON [PRIMARY]) ON [PRIMARY]"
        );
    }
}
