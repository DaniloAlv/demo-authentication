namespace AuthDemo.Models
{
    public class Settings
    {
        public string SecretKey { get; set; }
        public int ExpiresIn { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}