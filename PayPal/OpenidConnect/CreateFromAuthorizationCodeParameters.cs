using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.OpenidConnect
{
    public class CreateFromAuthorizationCodeParameters
    {
        
	private const string CODE = "code";

	
	private const string REDIRECTURI = "redirect_uri";

	
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


        
        public void setCode(String code)
        {
            ContainerMap.Add(CODE, code);
        }

        public void setRedirectURI(String redirectURI)
        {
            ContainerMap.Add(REDIRECTURI, redirectURI);
        }

        public void setGrantType(String grantType)
        {
            ContainerMap.Add(GRANTTYPE, grantType);
        }
    }
}
