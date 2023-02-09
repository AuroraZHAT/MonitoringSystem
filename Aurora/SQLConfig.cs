using Microsoft.Data.SqlClient;

namespace ServerSetUp
{
    internal class SQLConfig
    {
        private string _serverName;
        private string _databaseName;
        private bool _integratedSecurity;
        private bool _trustServerCertificate;

        public RegistryConfig Config = new RegistryConfig();

        /// <summary>
        /// Возвращает строку подключения к серверу MS SQL
        /// </summary>
        public string ServerConnectionString
        {
            get
            {
                return $"Data Source={_serverName};" +
                       $"Initial Catalog=master;" +
                       $"Integrated Security={_integratedSecurity};" +
                       $"TrustServerCertificate={_trustServerCertificate}";
            }
        }

        /// <summary>
        /// Возвращает строку подключения к базе данных MS SQL сервера
        /// </summary>
        public string DatabaseConnectionString
        {
            get
            {
                return $"Data Source={_serverName};" +
                       $"Initial Catalog={_databaseName};" +
                       $"Integrated Security={_integratedSecurity};" +
                       $"TrustServerCertificate={_trustServerCertificate}";
            }
        }

        /// <summary>
        /// Проверка подключения к серверу
        /// </summary>
        public bool ServerExistConnection
        {
            get
            {
                SqlConnection conn = new SqlConnection(ServerConnectionString);
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Проверка подключения к базе данных
        /// </summary>
        public bool DatabaseExistConnection
        {
            get
            {
                SqlConnection conn = new SqlConnection(DatabaseConnectionString);
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Выгружает настройки из реестра
        /// </summary>
        public void ApplyConfig()
        {
            Config.Unload(out _serverName, out _databaseName, ref _integratedSecurity, ref _trustServerCertificate);
        }

        /// <summary>
        /// True если исполнение query удачно, False если нет.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public bool TryExecuteNonQuery(string query, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Создание базы данных
        /// </summary>
        public bool CreateDataBase()
        {
            if (!ServerExistConnection)
                return false;

            string query = $"CREATE DATABASE [{_databaseName}]";

            return TryExecuteNonQuery(query, ServerConnectionString) &
                   DatabaseExistConnection;
        }

        /// <summary>
        /// Создание таблицы ObjectType 
        /// </summary>
        /// <returns></returns>
        public bool CreateTableObjectType()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE TABLE[dbo].[ObjectsType](" +
                            "[id][int] IDENTITY(1, 1) NOT NULL," +
                            "[TypeName] [nchar] (15) NULL," +
                            "CONSTRAINT[PK_ObjectsType] PRIMARY KEY CLUSTERED" +
                            "( [id] ASC ) WITH (PAD_INDEX = OFF," +
                            " STATISTICS_NORECOMPUTE = OFF," +
                            " IGNORE_DUP_KEY = OFF," +
                            " ALLOW_ROW_LOCKS = ON," +
                            " ALLOW_PAGE_LOCKS = ON," +
                            " OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
                            " ON[PRIMARY]) ON[PRIMARY]";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }

        public bool CreateTableInaterfaces()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE TABLE [dbo].[Interfaces](" +
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
                            "ON [PRIMARY]) ON [PRIMARY]";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }

        public bool CreateTableLocationMap()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE TABLE [dbo].[LocationMap](" +
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
                            "ON [PRIMARY]) ON [PRIMARY]";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }

        public bool CreateTableOS()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE TABLE [dbo].[OS](" +
                            "[id] [int] IDENTITY(1,1) NOT NULL," +
                            "[OS_name] [nchar](30) NOT NULL," +
                            "CONSTRAINT [PK_OS] PRIMARY KEY CLUSTERED" +
                            "( [id] ASC )WITH (PAD_INDEX = OFF," +
                            "STATISTICS_NORECOMPUTE = OFF," +
                            "IGNORE_DUP_KEY = OFF," +
                            "ALLOW_ROW_LOCKS = ON," +
                            "ALLOW_PAGE_LOCKS = ON," +
                            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)" +
                            "ON [PRIMARY]) ON [PRIMARY]";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }

        public bool CreateTableObject()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE TABLE [dbo].[Object](" +
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
                            "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) " +
                            "ON [PRIMARY]) ON [PRIMARY]";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }

        public bool CreateObjectView()
        {
            if (!DatabaseExistConnection)
                return false;

            string query = "CREATE VIEW [dbo].[objectView] " +
                            "AS " +
                            "SELECT dbo.Object.id, dbo.Object.ObjectName, " +
                            "dbo.ObjectsType.TypeName, dbo.OS.OS_name, " +
                            "dbo.LocationMap.Location_Map, dbo.Object.Last_IP, " +
                            "dbo.Object.HVID, dbo.Interfaces.Interface, " +
                            "dbo.Interfaces.MAC_Address, dbo.Object.Last_Date_ON, " +
                            "dbo.Object.Responsible, dbo.Object.Installed " +
                            "FROM dbo.Object " +
                            "INNER JOIN dbo.ObjectsType ON dbo.Object.ObjectType_id = dbo.ObjectsType.id " +
                            "INNER JOIN dbo.OS ON dbo.Object.OS_id = dbo.OS.id " +
                            "INNER JOIN dbo.LocationMap ON dbo.Object.LocationMap_id = dbo.LocationMap.id " +
                            "INNER JOIN dbo.Interfaces ON dbo.Object.Interfaces_ID = dbo.Interfaces.id";

            return TryExecuteNonQuery(query, DatabaseConnectionString);
        }
    }
}