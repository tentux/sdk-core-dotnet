using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace PayPal.OpenidConnect
{
    public class UserinfoParameters
    {
        /**
	 * Schema
	 */
	private const string SCHEMA = "schema";
	
	/**
	 * Access Token
	 */
	private const string ACCESSTOKEN = "access_token";

        private Dictionary<string, string> containerMapValue;

        public UserinfoParameters()
        {
            containerMapValue = new Dictionary<string, string>();
            containerMapValue.Add(SCHEMA, "openid");
        }

        public Dictionary<string, string> ContainerMap
        {
            get
            {
                return containerMapValue;
            }
            set
            {
                containerMapValue = value;
            }
        }

        public void setSchema(string schema)
        {
            ContainerMap.Add(SCHEMA, schema);
        }

        public void setAccessToken(string accessToken)
        {
            ContainerMap.Add(ACCESSTOKEN, HttpUtility.UrlEncode(accessToken));
        }
    }
    
}
