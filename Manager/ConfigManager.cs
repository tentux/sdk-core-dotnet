using System.Collections.Generic;
using System.Configuration;
using PayPal.Exception;

namespace PayPal.Manager
{    
    /// <summary>
    /// ConfigManager loads the configuration file and hands out
    /// appropriate parameters to application
    /// </summary>
    public sealed class ConfigManager
    {
        private SDKConfigHandler configHandler;

        private Dictionary<string, string> configValues;

        /// <summary>
        /// Singleton instance of the ConfigManager
        /// </summary>
        private static readonly ConfigManager singletonInstance = new ConfigManager();

        /// <summary>
        /// Explicit static constructor to tell C# compiler
        /// not to mark type as beforefieldinit
        /// </summary>
        static ConfigManager() { }

        /// <summary>
        /// Private constructor
        /// </summary>
        private ConfigManager()
        {
            configHandler = (SDKConfigHandler)ConfigurationManager.GetSection("paypal");
            if (configHandler == null)
            {
                throw new ConfigException("Cannot read config file");
            }
            this.configValues = new Dictionary<string, string>();

            NameValueConfigurationCollection settings = this.configHandler.Settings;
            foreach (string key in settings.AllKeys)
            {
                this.configValues.Add(settings[key].Name, settings[key].Value);
            }

            int i = 0;
            foreach (ConfigurationElement elem in this.configHandler.Accounts)
            {
                Account account = (Account)elem;
                if (account.APIUsername != null && account.APIUsername != "")
                {
                    this.configValues.Add("account" + i + ".apiusername", account.APIUsername);
                }
                if (account.APIPassword != null && account.APIPassword != "")
                {
                    this.configValues.Add("account" + i + ".apipassword", account.APIPassword);
                }
                if (account.APISignature != null && account.APISignature != "")
                {
                    this.configValues.Add("account" + i + ".apisignature", account.APISignature);
                }
                if (account.APICertificate != null && account.APICertificate != "")
                {
                    this.configValues.Add("account" + i + ".apicertificate", account.APICertificate);
                }
                if (account.PrivateKeyPassword != null && account.PrivateKeyPassword != "")
                {
                    this.configValues.Add("account" + i + ".privatekeypassword", account.PrivateKeyPassword);
                }
                if (account.CertificateSubject != null && account.CertificateSubject != "")
                {
                    this.configValues.Add("account" + i + ".subject", account.CertificateSubject);
                }
                if (account.ApplicationId != null && account.ApplicationId != "")
                {
                    this.configValues.Add("account" + i + ".applicationId", account.ApplicationId);
                }
                i++;
            }
        }

        /// <summary>
        /// Gets the Singleton instance of the ConfigManager
        /// </summary>
        public static ConfigManager Instance
        {
            get
            {
                return singletonInstance;
            }
        }

        /// <summary>
        /// Returns all properties from the config file
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetProperties()
        {
            return this.configValues;
        }

        /// <summary>
        /// Returns the key from the configuration file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetProperty(string key)
        {
            return configHandler.Setting(key);
        }
    }
}
