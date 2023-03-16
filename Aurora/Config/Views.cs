using static Aurora.Config.Tables;

namespace Aurora.Config
{
    public static class Views
    {
        public static string ObjectsQuery =>
        (
            $"CREATE VIEW [{Objects.Name}View] " +
            $"AS " +
            $"SELECT " +
            $"[{Objects.Name}].[{Objects.Columns[0].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[1].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[2].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[3].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[4].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[5].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[6].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[7].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[8].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[9].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[10].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[11].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[12].Name}], " +
            $"[{Objects.Name}].[{Objects.Columns[13].Name}] " +
            $"FROM [{Objects.Name}]"
        );
    }
}
