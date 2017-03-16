using System.Configuration;

namespace OnlineShoppingStore.Domain.Entities
{
    public class EmailSettings
    {
        public string MailToAddress
        {
            get { return ConfigurationManager.AppSettings["EmailToAddress"]; }
        } 
        public string MailFromAddress
        {
            get { return ConfigurationManager.AppSettings["EmailFromAddress"]; }
        }
        public bool UseSsl
        {
            get { return ConfigurationManager.AppSettings["UseSsl"].ToUpper() == "YES" ? true : false; }
        }
        public string UserName
        {
            get { return ConfigurationManager.AppSettings["UserName"]; }
        }
        public string Password
        {
            get { return ConfigurationManager.AppSettings["Password"];}
        }
        public string ServerName
        {
            get { return ConfigurationManager.AppSettings["ServerName"]; }
        }
        public int ServerPort = 587;
    }
}
