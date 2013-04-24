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

        public CreateFromAuthorizationCodeParameters()
        {
            containerMapValue = new Dictionary<string, string>();
            containerMapValue.Add(GRANTTYPE, "authorization_code");
        }

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



        public void setCode(string code)
        {
            ContainerMap.Add(CODE, code);
        }

        public void setRedirectURI(string redirectURI)
        {
            ContainerMap.Add(REDIRECTURI, redirectURI);
        }

        public void setGrantType(string grantType)
        {
            ContainerMap.Add(GRANTTYPE, grantType);
        }
    }
}
