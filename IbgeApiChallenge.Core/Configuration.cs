namespace IbgeApiChallenge.Core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; set; } = new();
    public static DataBaseConfiguration DataBase { get; set; } = new();
    public static EmailConfiguration Email { get; set; } = new();

    
    
    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
    public class EmailConfiguration
    {
        public string DefaultFromEmail { get; set; } = "teste@gmail.com";
        public string DefaultFromName { get; set; } = "Desafio IBGE API";
    }
    public class SecretsConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
        public string JwtPrivateKey { get; set; } = string.Empty;
        public string PasswordSaltKey { get; set; } = string.Empty;
    }
}