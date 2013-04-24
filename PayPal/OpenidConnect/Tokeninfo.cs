using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;

namespace PayPal.OpenidConnect
{
	public class Tokeninfo
	{
		/// <summary>
		/// OPTIONAL, if identical to the scope requested by the client; otherwise, REQUIRED.
		/// </summary>
		private string scopeValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string scope
		{
			get
			{
				return scopeValue;
			}
			set
			{
				scopeValue = value;
			}
		}
		/// <summary>
		/// The access token issued by the authorization server.
		/// </summary>
		private string accessTokenValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string accessToken
		{
			get
			{
				return accessTokenValue;
			}
			set
			{
				accessTokenValue = value;
			}
		}
		/// <summary>
		/// The refresh token, which can be used to obtain new access tokens using the same authorization grant as described in OAuth2.0 RFC6749 in Section 6.
		/// </summary>
		private string refreshTokenValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string refreshToken
		{
			get
			{
				return refreshTokenValue;
			}
			set
			{
				refreshTokenValue = value;
			}
		}
		/// <summary>
		/// The type of the token issued as described in OAuth2.0 RFC6749 (Section 7.1).  Value is case insensitive.
		/// </summary>
		private string tokenTypeValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string tokenType
		{
			get
			{
				return tokenTypeValue;
			}
			set
			{
				tokenTypeValue = value;
			}
		}
		/// <summary>
		/// The lifetime in seconds of the access token.
		/// </summary>
		private int expiresInValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int expiresIn
		{
			get
			{
				return expiresInValue;
			}
			set
			{
				expiresInValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Tokeninfo()
		{
		
		}
		
		/// <summary>
		/// 
		/// </summary>
		public Tokeninfo(string accessToken, string tokenType, int expiresIn)
		{
			this.accessToken = accessToken;
			this.tokenType = tokenType;
			this.expiresIn = expiresIn;
		}
		
	/// <summary>
	/// Creates an Access Token from an Authorization Code.
	/// <param name="createFromAuthorizationCodeParameters">Query parameters used for API call</param>
	/// </summary>
	public static Tokeninfo CreateFromAuthorizationCode(CreateFromAuthorizationCodeParameters createFromAuthorizationCodeParameters)
	{
		string pattern = "v1/identity/openidconnect/tokenservice ?grant_type={0}&code={1}&redirect_uri={2}";
		object[] parameters = new object[] { createFromAuthorizationCodeParameters.ContainerMap };
		string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
		string payLoad = resourcePath.Substring(resourcePath.IndexOf('?') + 1);
		resourcePath = resourcePath.Substring(0, resourcePath.IndexOf("?"));
		Dictionary<string, string> headersMap = new Dictionary<string, string>();
		headersMap.Add("Content-Type", "application/x-www-form-urlencoded");
		return PayPalResource.ConfigureAndExecute<Tokeninfo>(null, HttpMethod.POST,
				resourcePath, headersMap, payLoad);
	}

	/// <summary>
	/// Creates an Access Token from an Authorization Code.
	/// <param name="apiContext">APIContext to be used for the call.</param>
	/// <param name="createFromAuthorizationCodeParameters">Query parameters used for API call</param>
	/// </summary>
	public static Tokeninfo CreateFromAuthorizationCode(APIContext apiContext, CreateFromAuthorizationCodeParameters createFromAuthorizationCodeParameters)
	{
		string pattern = "v1/identity/openidconnect/tokenservice ?grant_type={0}&code={1}&redirect_uri={2}";
		object[] parameters = new object[] { createFromAuthorizationCodeParameters.ContainerMap };
		string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
		string payLoad = resourcePath.Substring(resourcePath.IndexOf('?') + 1);
		resourcePath = resourcePath.Substring(0, resourcePath.IndexOf("?"));
		Dictionary<string, string> headersMap = new Dictionary<string, string>();
		headersMap.Add("Content-Type", "application/x-www-form-urlencoded");
		return PayPalResource.ConfigureAndExecute<Tokeninfo>(apiContext, HttpMethod.POST,
				resourcePath, headersMap, payLoad);
	}

	/// <summary>
	/// Creates an Access Token from an Refresh Token.
	/// <param name="createFromRefreshTokenParameters">Query parameters used for API call</param>
	/// </summary>
	public Tokeninfo CreateFromRefreshToken(CreateFromRefreshTokenParameters createFromRefreshTokenParameters)
	{
		string pattern = "v1/identity/openidconnect/tokenservice ?grant_type={0}&refresh_token={1}&scope={2}&client_id={3}&client_secret={4}";
		Dictionary<string, string> paramsMap = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> entry in createFromRefreshTokenParameters.ContainerMap)
        {
            paramsMap.Add(entry.Key, entry.Value);
        }
		paramsMap.Add("refresh_token", refreshToken);
		object[] parameters = new object[] { paramsMap };
		string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
		string payLoad = resourcePath.Substring(resourcePath.IndexOf('?') + 1);
		resourcePath = resourcePath.Substring(0, resourcePath.IndexOf("?"));
		Dictionary<string, string> headersMap = new Dictionary<string, string>();
		headersMap.Add("Content-Type", "application/x-www-form-urlencoded");
		return PayPalResource.ConfigureAndExecute<Tokeninfo>(null, HttpMethod.POST,
				resourcePath, headersMap, payLoad);
	}

	/// <summary>
	/// Creates an Access Token from an Refresh Token
	/// <param name="apiContext">APIContext to be used for the call</param>
	/// <param name="createFromRefreshTokenParameters">Query parameters used for API call</param>
	/// </summary>
	public Tokeninfo CreateFromRefreshToken(APIContext apiContext, CreateFromRefreshTokenParameters createFromRefreshTokenParameters)
	{
		string pattern = "v1/identity/openidconnect/tokenservice ?grant_type={0}&refresh_token={1}&scope={2}&client_id={3}&client_secret={4}";
		Dictionary<string, string> paramsMap = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> entry in createFromRefreshTokenParameters.ContainerMap)
        {
            paramsMap.Add(entry.Key, entry.Value);
        }
		paramsMap.Add("refresh_token", refreshToken);
		object[] parameters = new object[] { paramsMap };
		string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
		string payLoad = resourcePath.Substring(resourcePath.IndexOf('?') + 1);
		resourcePath = resourcePath.Substring(0, resourcePath.IndexOf("?"));
		Dictionary<string, string> headersMap = new Dictionary<string, string>();
		headersMap.Add("Content-Type", "application/x-www-form-urlencoded");
		return PayPalResource.ConfigureAndExecute<Tokeninfo>(apiContext,
				HttpMethod.POST, resourcePath, headersMap, payLoad);
	}
	}
}


