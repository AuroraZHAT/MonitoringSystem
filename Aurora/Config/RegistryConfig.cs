using Microsoft.Win32;
using System;

namespace Aurora.Config
{
    public static class RegistryConfig
    {
        private const string RegistryPath = @"SOFTWARE\Aurora\NetMonitor\SQL_Config";
        private const string None = "None";
        private const string ServerNameKey = "ServerName";
        private const string DatabaseNameKey = "DatabaseName";
        private const string IntegratedSecurityKey = "IntegratedSecurity";
        private const string TrustServerCertificateKey = "TrustServerCertificate";
        private const string UserIdKey = "User ID";
        private const string PasswordKey = "Password";

        public static bool IsRegistryPathExist => Registry.LocalMachine.OpenSubKey(RegistryPath) != null;

        public static bool IsParametersExist => IsRegistryPathExist && ServerName != None && DatabaseName != None;

        public static string ServerName
        {
            get => GetRegistryValue<string>(ServerNameKey, None);
            private set => SetRegistryValue(ServerNameKey, value);
        }

        public static string DatabaseName
        {
            get => GetRegistryValue<string>(DatabaseNameKey, None);
            private set => SetRegistryValue(DatabaseNameKey, value);
        }

        public static bool IntegratedSecurity
        {
            get => GetRegistryValue<bool>(IntegratedSecurityKey, false);
            private set => SetRegistryValue(IntegratedSecurityKey, value);
        }

        public static bool TrustServerCertificate
        {
            get => GetRegistryValue<bool>(TrustServerCertificateKey, false);
            private set => SetRegistryValue(TrustServerCertificateKey, value);
        }

        private static string UserId
        {
            get => GetRegistryValue<string>(UserIdKey, None);
            set => SetRegistryValue(UserIdKey, value);
        }

        private static string Password
        {
            get => GetRegistryValue<string>(PasswordKey, None);
            set => SetRegistryValue(PasswordKey, value);
        }

        public static void Load(string serverName, string databaseName, bool integratedSecurity, bool trustServerCertificate)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = integratedSecurity;
            TrustServerCertificate = trustServerCertificate;
        }

        private static RegistryKey ConfigRegKey(bool writable = false) => Registry.LocalMachine.OpenSubKey(RegistryPath, writable);

        public static void CreateRegPath() => Registry.LocalMachine.CreateSubKey(RegistryPath);

        private static T GetRegistryValue<T>(string key, T defaultValue)
        {
            var value = ConfigRegKey()?.GetValue(key, defaultValue);
            return value is T typeValue ? typeValue : defaultValue;
        }

        private static void SetRegistryValue<T>(string key, T value)
        {
            var kind = value switch
            {
                string _ => RegistryValueKind.String,
                int _ => RegistryValueKind.DWord,
                bool _ => RegistryValueKind.DWord,
                _ => throw new NotSupportedException($"Type {value.GetType()} is not supported for registry operations.")
            };

            ConfigRegKey(true)?.SetValue(key, value, kind);
        }
    }
}