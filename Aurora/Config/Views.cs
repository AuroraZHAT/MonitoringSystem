using static Aurora.Config.Tables;

namespace Aurora.Config
{
    public static class Views
    {
        public const string OBJECTS_VIEW_NAME = "Objects View";

        public enum Columns
        {
            ID,
            ObjectName,
            Type,
            OS,
            Location,
            X,
            Y,
            IP,
            HVID,
            MAC,
            Interface,
            LastDate,
            Responsible,
            InstalledBy
        }

        public static string Objects =>
        (
            $"CREATE VIEW [{OBJECTS_VIEW_NAME}] " +
            $"AS " +
            $"SELECT " +
            $"[{OBJECTS_TABLE_NAME}].[{ID}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_NAME}], " +
            $"[{OBJECT_TYPES_TABLE_NAME}].[{TYPE_NAME}], " +
            $"[{OS_TABLE_NAME}].[{OS_NAME}], " +
            $"[{LOCATIONS_TABLE_NAME}].[{LOCATION_NAME}], " +
            $"[{LOCATIONS_TABLE_NAME}].[{OBJECT_X}], " +
            $"[{LOCATIONS_TABLE_NAME}].[{OBJECT_Y}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_IP}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_HVID}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_MAC_ADRESS}], " +
            $"[{INTERFACES_TABLE_NAME}].[{INTERFACE_NAME}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_LAST_DATE_ON}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_RESPONSIBLE}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_INSTALLED_BY}] " +
            $"FROM [{OBJECTS_TABLE_NAME}] " +
            $"INNER JOIN [{OBJECT_TYPES_TABLE_NAME}] ON [{OBJECTS_TABLE_NAME}].[{OBJECT_TYPE_ID}] = [{OBJECT_TYPES_TABLE_NAME}].[{ID}] " +
            $"INNER JOIN [{OS_TABLE_NAME}] ON [{OBJECTS_TABLE_NAME}].[{OBJECT_OS_ID}] = [{OS_TABLE_NAME}].[{ID}] " +
            $"INNER JOIN [{LOCATIONS_TABLE_NAME}] ON [{OBJECTS_TABLE_NAME}].[{OBJECT_LOCATION_ID}] = [{LOCATIONS_TABLE_NAME}].[{ID}] " +
            $"INNER JOIN [{INTERFACES_TABLE_NAME}] ON [{OBJECTS_TABLE_NAME}].[{ID}] = [{INTERFACES_TABLE_NAME}].[{ID}]"
        );
    }
}
