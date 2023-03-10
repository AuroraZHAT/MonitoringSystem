using Microsoft.Win32;
using System;

namespace Aurora.Config
{
    public static class RegistryConfig
    {
        /// <summary>
        /// Место хранения настроек подключения к SQL серверу
        /// </summary>
        private static readonly string REGISTRY_PATH = @"SOFTWARE\Aurora\NetMonitor\SQL_Config";
        private static readonly string NULL = "None";
        private static readonly string SERVER_NAME = "ServerName";
        private static readonly string DATABASE = "DatabaseName";
        private static readonly string INTEGRATED_SECURITY = "IntegratedSecurity";
        private static readonly string TRUST_SERVER_CERTIFICATE = "TrustServerCertificate";
        private static readonly string USER_ID = "User ID";
        private static readonly string PASSWORD = "Password";

        /// <summary>
        /// Возвращает True если ветка реестра доступна.
        /// </summary>
        public static bool IsRegistryPathExist
        {
            get
            {
                return Registry.LocalMachine.OpenSubKey(REGISTRY_PATH) != null;
            }
        }

        public static bool IsParametersExist
        {
            get
            {
                return IsRegistryPathExist &&
                        ServerName != NULL &&
                        DatabaseName != NULL;

            }
        }

        /// <summary>
        /// Возвращает и принимает имя MS SQL сервера.
        /// Если выдал "None" - параметра не существует.
        /// </summary>
        public static string ServerName
        {
            get
            {
                return ConfigRegKey().GetValue(SERVER_NAME, NULL).ToString();
            }
            private set
            {
                ConfigRegKey(true).SetValue(SERVER_NAME, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Возвращает и принимает название базы данных.
        /// Если выдал "None" - параметр не существует.
        /// </summary>
        public static string DatabaseName
        {
            get
            {
                return ConfigRegKey().GetValue(DATABASE, NULL).ToString();
            }
            private set
            {
                ConfigRegKey(true).SetValue(DATABASE, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Возвращает и принимает параметр IntegratedSecurity.
        /// Аутентификация пользователя:
        /// True - Используется текущая учетная запись в ОС Windows.
        /// False - Необходимо указать логин и пароль.
        /// </summary>
        public static bool IntegratedSecurity
        {
            get
            {
                return Convert.ToBoolean(ConfigRegKey().GetValue(INTEGRATED_SECURITY, false));
            }
            private set
            {
                ConfigRegKey(true).SetValue(INTEGRATED_SECURITY, value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Возвращает и принимает параметр TrustServerCertificate.
        /// Шифрование канала обход цепочки сертификатов для проверки доверия.
        /// True - Доверять даже без сертификатов.
        /// False - Доверять только с сертификатом.
        /// </summary>
        public static bool TrustServerCertificate
        {
            get
            {
                return Convert.ToBoolean(ConfigRegKey().GetValue(TRUST_SERVER_CERTIFICATE, false));
            }
            private set
            {
                ConfigRegKey(true).SetValue(TRUST_SERVER_CERTIFICATE, value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Возвращает и принимает параметр User ID.
        /// Если отдает "None" - параметр не существует.
        /// </summary>
        private static string UserID
        {
            get
            {
                return ConfigRegKey().GetValue(USER_ID, NULL).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(USER_ID, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Возвращает и принимает пароль.
        /// Если отдает "None" - параметр не существует.
        /// </summary>
        private static string Password
        {
            get
            {
                return ConfigRegKey().GetValue(PASSWORD, NULL).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(PASSWORD, value, RegistryValueKind.String);
            }
        }

        public static void Load(string serverName, string databaseName, bool integratedSecurity, bool trustServerCertificate)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = integratedSecurity;
            TrustServerCertificate = trustServerCertificate;
        }

        /// <summary>
        /// Ветка реестра для хранения настроек
        /// </summary>
        /// <param name="wr">если true, запись в реестр разрешена</param>
        /// <returns></returns>
        private static RegistryKey ConfigRegKey(bool wr = false)
        {
            return Registry.LocalMachine.OpenSubKey(REGISTRY_PATH, wr);
        }

        /// <summary>
        /// Создание ветки реестра настроек
        /// </summary>
        public static void CreateRegPath()
        {
            Registry.LocalMachine.CreateSubKey(REGISTRY_PATH);
        }
    }
}