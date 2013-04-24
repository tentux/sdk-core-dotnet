using System;
using System.Collections.Generic;
using System.Text;

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

        public void setSchema(String schema)
        {
            ContainerMap.Add(SCHEMA, schema);
        }

        public void setAccessToken(String accessToken)
        {
            ContainerMap.Add(ACCESSTOKEN, accessToken);
        }
    }
    
}
