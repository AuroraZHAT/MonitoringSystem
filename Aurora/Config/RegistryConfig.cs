using Microsoft.Win32;
using System;

namespace Aurora.Config
{
    public static class RegistryConfig
    {
        /// <summary>
        /// Место хранения настроек подключения к SQL серверу
        /// </summary>
        private static readonly string _registryPath = @"SOFTWARE\Aurora\NetMonitor\SQL_Config";
        private static readonly string _nullParam = "None";
        private static readonly string _serverNameParam = "ServerName";
        private static readonly string _databaseParam = "DatabaseName";
        private static readonly string _integratedSecurityParam = "IntegratedSecurity";
        private static readonly string _trustServerCertificateParam = "TrustServerCertificate";
        private static readonly string _userIDParam = "User ID";
        private static readonly string _passwordParam = "Password";

        /// <summary>
        /// Возвращает True если ветка реестра доступна.
        /// </summary>
        public static bool IsRegistryPathExist
        {
            get
            {
                return Registry.LocalMachine.OpenSubKey(_registryPath) != null;
            }
        }

        public static bool IsParametersExist
        {
            get
            {
                return IsRegistryPathExist &&
                        ServerName != _nullParam &&
                        DatabaseName != _nullParam;

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
                return ConfigRegKey().GetValue(_serverNameParam, _nullParam).ToString();
            }
            private set
            {
                ConfigRegKey(true).SetValue(_serverNameParam, value, RegistryValueKind.String);
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
                return ConfigRegKey().GetValue(_databaseParam, _nullParam).ToString();
            }
            private set
            {
                ConfigRegKey(true).SetValue(_databaseParam, value, RegistryValueKind.String);
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
                return Convert.ToBoolean(ConfigRegKey().GetValue(_integratedSecurityParam, false));
            }
            private set
            {
                ConfigRegKey(true).SetValue(_integratedSecurityParam, value, RegistryValueKind.DWord);
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
                return Convert.ToBoolean(ConfigRegKey().GetValue(_trustServerCertificateParam, false));
            }
            private set
            {
                ConfigRegKey(true).SetValue(_trustServerCertificateParam, value, RegistryValueKind.DWord);
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
                return ConfigRegKey().GetValue(_userIDParam, _nullParam).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(_userIDParam, value, RegistryValueKind.String);
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
                return ConfigRegKey().GetValue(_passwordParam, _nullParam).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(_passwordParam, value, RegistryValueKind.String);
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
            return Registry.LocalMachine.OpenSubKey(_registryPath, wr);
        }

        /// <summary>
        /// Создание ветки реестра настроек
        /// </summary>
        public static void CreateRegPath()
        {
            Registry.LocalMachine.CreateSubKey(_registryPath);
        }
    }
}