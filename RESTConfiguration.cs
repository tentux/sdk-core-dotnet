using System;
using System.Collections.Generic;
using System.Text;
using PayPal.Manager;
using PayPal.Exception;

namespace PayPal
{
    public class RESTConfiguration
    {
        private string authorizeToken;

        public string authorizationToken
        {
            get
            {
                return authorizeToken;
            }
            set

            {
                authorizeToken = value;
            }
        }

        private string requestIdentity;
        public string requestId
        {
            private get
            {
                return requestIdentity;
            }
            set
            {
                requestIdentity = value;
            }
        }

        private Dictionary<string, string> config;

        private Dictionary<string, string> headersMap;

        public RESTConfiguration(Dictionary<string, string> config)
        {
            this.config = ConfigManager.getConfigWithDefaults(config);
        }

        public RESTConfiguration(Dictionary<string, string> config, Dictionary<string, string> headersMap)
        {
            this.config = ConfigManager.getConfigWithDefaults(config);
		    this.headersMap = (headersMap == null) ? new Dictionary<string, string>() : headersMap;
        }

        public Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(authorizationToken))
            {
                headers.Add("Authorization", authorizationToken);
            }
            else if (!string.IsNullOrEmpty(GetClientID()) && !string.IsNullOrEmpty(GetClientSecret()))
            {
                headers.Add("Authorization", "Basic " + EncodeToBase64(GetClientID(), GetClientSecret()));
            }
            headers.Add("User-Agent", FormUserAgentHeader());
            if (!string.IsNullOrEmpty(requestId))
            {
                headers.Add("PayPal-Request-Id", requestId);
            }
            
            return headers;
        }

        /*
	 * Return Client ID from configuration Map
	 */
        private String GetClientID()
        {
            return this.config[BaseConstants.CLIENT_ID];
        }

        /*
         * Returns Client Secret from configuration Map
         */
        private String GetClientSecret()
        {
            return this.config[BaseConstants.CLIENT_SECRET];
        }

        private String EncodeToBase64(string clientID, string clientSecret)
        {
            try
            {
            byte[] bytes = Encoding.UTF8.GetBytes(clientID + ":" + clientSecret);
		string base64ClientID = Convert.ToBase64String(bytes);
		return base64ClientID;
    }
    catch (ArgumentOutOfRangeException ex)
    {
        throw new PayPalException(ex.Message, ex);
    }
    catch (ArgumentException ex)
    {
        throw new PayPalException(ex.Message, ex);
    }
    catch (NotSupportedException ex)
    {
        throw new PayPalException(ex.Message, ex);
    }
    catch (System.Exception ex)
    {
        throw new PayPalException(ex.Message, ex);
    } 
	    }

        private string FormUserAgentHeader()
        {
            string header = null;
            StringBuilder stringBuilder = new StringBuilder("PayPalSDK/"
                    + PayPalResource.SdkID + " " + PayPalResource.SdkVersion
                    + " ");
            string dotNETVersion = GetDotNetVersionHeader();
            stringBuilder.Append(";").Append(dotNETVersion);
            string osVersion = GetOSHeader();
            if (osVersion.Length > 0)
            {
                stringBuilder.Append(";").Append(osVersion);
            }
            header = stringBuilder.ToString();
            return header;
        }

        private string GetOSHeader()
        {
            string osHeader = string.Empty;
            if (JCS.OSVersionInfo.OSBits.Equals(JCS.OSVersionInfo.SoftwareArchitecture.Bit64))
            {
                osHeader += "bit=" + 64 + ";";
            }
            else if (JCS.OSVersionInfo.OSBits.Equals(JCS.OSVersionInfo.SoftwareArchitecture.Bit32))
            {
                osHeader += "bit=" + 32 + ";";
            }
            else
            {
                osHeader += "bit=" + "Unknown" + ";";
            }

            osHeader += "os=" + JCS.OSVersionInfo.Name + " " + JCS.OSVersionInfo.Version + ";";
            return osHeader;
        }

        private string GetDotNetVersionHeader()
        {
            string DotNetVersionHeader = "lang=" + "DOTNET;" + "v=" + Environment.Version.ToString().Trim();
            return DotNetVersionHeader;
        }          
    }
}
