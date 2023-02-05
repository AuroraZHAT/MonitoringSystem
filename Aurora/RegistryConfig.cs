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
        /// Загружает настройки в реестр
        /// </summary>
        /// <param name="serverName">Название сервера</param>
        /// <param name="databaseName">Название базы данных</param>
        public void Load(string serverName, string databaseName)
        {
            if (!IsRegistryPathExist)
                CreateRegPath();

            ServerName = serverName;
            DatabaseName = databaseName;
        }

        /// <summary>
        /// Выгружвкт настройки из реестра
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        public void Unload(string serverName, string databaseName)
        {
            if (!IsRegistryPathExist)
                CreateRegPath();

            serverName = ServerName;
            databaseName = DatabaseName;
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
    }
}
