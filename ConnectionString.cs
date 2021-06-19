namespace API
{
    public class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString()
        {
            string username = "cf0mnqzhruq0eaje";
            string password = "th4js05qg33jeljz";
            string host = "grp6m5lz95d9exiz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string port = "3306";
            string database = "uxmyeqa05jlmetgk";
            cs = $@"host={host};username={username};database={database};port={port};password={password}";
        }
    }
}