namespace GrandCircusReferralsAPI.HelperClasses
{
    public class DatabaseConnectionHelper
    {
        public static string GetDatabaseConnection()
        {
            return "Server=.\\SQLEXPRESS;Database=GrandCircusReferrals;Integrated Security=true;";
        }
    }
}
