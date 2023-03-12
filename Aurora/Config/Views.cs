using static Aurora.Config.Tables;

namespace Aurora.Config
{
    public static class Views
    {
        public const string OBJECTS_VIEW_NAME = "Objects View";



        public static string Objects =>
        (
            $"CREATE VIEW [{OBJECTS_VIEW_NAME}] " +
            $"AS " +
            $"SELECT " +
            $"[{OBJECTS_TABLE_NAME}].[{ID}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_NAME}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_TYPE}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_OS}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_LOCATION}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_X}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_Y}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_IP}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_HVID}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_MAC_ADRESS}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_INTERFACE}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_LAST_DATE_ON}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_RESPONSIBLE}], " +
            $"[{OBJECTS_TABLE_NAME}].[{OBJECT_INSTALLED_BY}] " +
            $"FROM [{OBJECTS_TABLE_NAME}]"
        );
    }
}
