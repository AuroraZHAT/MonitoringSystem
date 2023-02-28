namespace Aurora.Config
{
    public struct View
    {
        public string Objects =>
        (
            "ALTER VIEW [dbo].[objectView] " +
            "AS " +
            "SELECT " +
            "dbo.Object.ObjectName, " +
            "dbo.ObjectsType.TypeName, " +
            "dbo.OS.OS_name, " +
            "dbo.LocationMap.Location_Map, " +
            "dbo.Object.Last_IP, " +
            "dbo.Object.HVID, " +
            "dbo.Interfaces.Interface, " +
            "dbo.Interfaces.MAC_Address, " +
            "dbo.Object.Last_Date_ON, " +
            "dbo.Object.Responsible, " +
            "dbo.Object.Installed " +
            "FROM dbo.Object " +
            "INNER JOIN dbo.ObjectsType ON dbo.Object.ObjectType_id = dbo.ObjectsType.id " +
            "INNER JOIN dbo.OS ON dbo.Object.OS_id = dbo.OS.id " +
            "INNER JOIN dbo.LocationMap ON dbo.Object.LocationMap_id = dbo.LocationMap.id " +
            "INNER JOIN dbo.Interfaces ON dbo.Object.Interfaces_ID = dbo.Interfaces.id"
        );
    }
}
