namespace WebApp.Strategy.Models
{
    public class Settings
    {
        public static string claimDatabaseType = "DatabaseType";

        public EDatabaseType DatabaseType;

        public EDatabaseType GetDefaultDatabaseType => EDatabaseType.SqlServer;
    }
}
