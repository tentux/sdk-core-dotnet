using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.OpenidConnect
{
    public class CreateFromRefreshTokenParameters
    {
        
	private const string SCOPE = "scope";
	
	
        private const string GRANTTYPE = "grant_type";

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

        public void setScope(String scope)
        {
            ContainerMap.Add(SCOPE, scope);
        }

        public void setGrantType(String grantType)
        {
            ContainerMap.Add(GRANTTYPE, grantType);
        }
    }
    
}
