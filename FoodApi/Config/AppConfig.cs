namespace FoodApp
{

    public class FoodConfig    {
        public AppConfig App { get; set; } 
        public Logging Logging { get; set; } 
        public ConnectionStrings ConnectionStrings { get; set; } 
        public Azure Azure { get; set; } 
        public GraphCfg GraphCfg { get; set; } 
    }

     public class AppConfig    {
        public string FrontendUrl { get; set; } 
        public string AllowedHosts { get; set; } 
        public string MailSender { get; set; } 
        public bool AuthEnabled { get; set; } 
        public bool UseLocalConfig { get; set; } 
    }

    public class LogLevel    {
        public string Default { get; set; } 
        public string Microsoft { get; set; }     
    }

    public class Logging    {
        public LogLevel LogLevel { get; set; } 
    }

    public class ConnectionStrings    {
        public string SQLiteDBConnection { get; set; } 
        public string SQLServerConnection { get; set; } 
    }

    public class ApplicationInsights    {
        public string InstrumentationKey { get; set; } 
    }

    public class Azure    {
        public ApplicationInsights ApplicationInsights { get; set; } 
        public string AppConfiguration { get; set; } 
        public string KeyVault { get; set; } 
    }

    public class Endpoints    {
        public string graphApiUri { get; set; } 
    }

    public class GraphCfg    {
        public string tenantId { get; set; } 
        public string clientId { get; set; } 
        public string clientSecret { get; set; } 
        public string cacheLocation { get; set; } 
        public Endpoints endpoints { get; set; } 
        public string returnUrl { get; set; } 
    }



}