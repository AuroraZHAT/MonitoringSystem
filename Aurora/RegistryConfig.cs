using Microsoft.Win32;
using System;

namespace AuroraGit.ServerSetUp
{
    internal class RegistryConfig
    {
        /// <summary>
        /// Место хранения настроек подключения к SQL серверу
        /// </summary>
        private readonly string _registryPath = @"Software\Aurora\NetMonitor\SQL_Config";
        private readonly string _nullParam = "None";
        private readonly string _serverNameParam = "ServerName";
        private readonly string _databaseParam = "DatabaseName";
        private readonly string _integratedSecurityParam = "IntegratedSecurity";
        private readonly string _trustServerCertificateParam = "TrustServerCertificate";
        private readonly string _userIDParam = "User ID";
        private readonly string _passwordParam = "Password";

        /// <summary>
        /// Возвращает True если ветка реестра доступна.
        /// </summary>
        public bool IsRegistryPathExist
        {
            get
            {
                return Registry.LocalMachine.OpenSubKey(_registryPath) != null;
            }
        }

        public bool IsParametersExist
        {
            get
            {
                return IsRegistryPathExist &&
                        ServerName != _nullParam &&
                        DatabaseName != _nullParam;

            }
        }

        /// <summary>
        /// Отдает и сохраняет имя MS SQL сервера.
        /// Если выдал "None" - параметра не существует.
        /// </summary>
        public string ServerName
        {
            get
            {
                return ConfigRegKey().GetValue(_serverNameParam, _nullParam).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(_serverNameParam, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Отдает и сохраняет название базы данных.
        /// Если выдал "None" - параметр не существует.
        /// </summary>
        public string DatabaseName
        {
            get
            {
                return ConfigRegKey().GetValue(_databaseParam, _nullParam).ToString();
            }
            set
            {
                ConfigRegKey(true).SetValue(_databaseParam, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Отдает и сохраняет параметр IntegratedSecurity.
        /// Аутентификация пользователя:
        /// True - Используется текущая учетная запись в ОС Windows.
        /// False - Необходимо указать логин и пароль.
        /// </summary>
        private bool IntegratedSecurity
        {
            get
            {
                return Convert.ToBoolean(ConfigRegKey().GetValue(_integratedSecurityParam, false));
            }
            set
            {
                ConfigRegKey(true).SetValue(_integratedSecurityParam, value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Отдает и сохраняет параметр TrustServerCertificate.
        /// Шифрование канала обход цепочки сертификатов для проверки доверия.
        /// True - Доверять даже без сертификатов.
        /// False - Доверять только с сертификатом.
        /// </summary>
        private bool TrustServerCertificate
        {
            get
            {
                return Convert.ToBoolean(ConfigRegKey().GetValue(_trustServerCertificateParam, false));
            }
            set
            {
                ConfigRegKey(true).SetValue(_trustServerCertificateParam, value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Отдает и сохраняет параметр User ID.
        /// Если отдает "None" - параметр не существует.
        /// </summary>
        private string UserID
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
        /// Отдает и сохраняет пароль.
        /// Если отдает "None" - параметр не существует.
        /// </summary>
        private string Password
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

        /// <summary>
        /// Загружает настройки в реестр
        /// </summary>
        /// <param name="serverName">Название сервера</param>
        /// <param name="databaseName">Название базы данных</param>
        /// <param name="integratedSecurity">Состояние интегрированной безопасности</param>
        /// <param name="trustServerCertificate">Состояние сертификата сервера</param>
        public void Load(string serverName, string databaseName, bool integratedSecurity, bool trustServerCertificate)
        {
            if (!IsRegistryPathExist)
                CreateRegPath();

            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = integratedSecurity;
            TrustServerCertificate = trustServerCertificate;
        }

        /// <summary>
        /// Выгружвкт настройки из реестра
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="integratedSecurity"></param>
        /// <param name="trustServerCertificate"></param>
        public void Unload(string serverName, string databaseName, bool integratedSecurity, bool trustServerCertificate)
        {
            if (!IsRegistryPathExist)
                CreateRegPath();

            serverName = ServerName;
            databaseName = DatabaseName;
            integratedSecurity = IntegratedSecurity;
            trustServerCertificate = TrustServerCertificate;
        }

        /// <summary>
        /// Ветка реестра для хранения настроек
        /// </summary>
        /// <param name="wr">если true, запись в реестр разрешена</param>
        /// <returns></returns>
        private RegistryKey ConfigRegKey(bool wr)
        {
            return Registry.LocalMachine.OpenSubKey(_registryPath, wr);
        }
        private RegistryKey ConfigRegKey()
        {
            return Registry.LocalMachine.OpenSubKey(_registryPath, false);
        }

        /// <summary>
        /// Создание ветки реестра настроек
        /// </summary>
        public void CreateRegPath()
        {
            Registry.LocalMachine.CreateSubKey(_registryPath);
        }
    }
}
