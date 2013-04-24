using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.OpenidConnect
{
    public class CreateFromRefreshTokenParameters
    {

        private const string SCOPE = "scope";


        private const string GRANTTYPE = "grant_type";

        private const string REFRESHTOKEN = "refresh_token";

        private Dictionary<string, string> containerMapValue;

        public CreateFromRefreshTokenParameters()
        {
            containerMapValue = new Dictionary<string, string>();
            containerMapValue.Add(GRANTTYPE, "refresh_token");
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

        public void setScope(string scope)
        {
            ContainerMap.Add(SCOPE, scope);
        }

        public void setGrantType(string grantType)
        {
            ContainerMap.Add(GRANTTYPE, grantType);
        }

        public void setRefreshToken(string refreshToken)
        {
            ContainerMap.Add(REFRESHTOKEN, refreshToken);
        }
    }

}
