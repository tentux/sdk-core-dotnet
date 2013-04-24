using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PayPal.OpenidConnect
{
	public class Address
	{
		/// <summary>
		/// Full street address component, which may include house number, street name.
		/// </summary>
		private string streetAddressValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string streetAddress
		{
			get
			{
				return streetAddressValue;
			}
			set
			{
				streetAddressValue = value;
			}
		}
		/// <summary>
		/// City or locality component.
		/// </summary>
		private string localityValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string locality
		{
			get
			{
				return localityValue;
			}
			set
			{
				localityValue = value;
			}
		}
		/// <summary>
		/// State, province, prefecture or region component.
		/// </summary>
		private string regionValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string region
		{
			get
			{
				return regionValue;
			}
			set
			{
				regionValue = value;
			}
		}
		/// <summary>
		/// Zip code or postal code component.
		/// </summary>
		private string postalCodeValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string postalCode
		{
			get
			{
				return postalCodeValue;
			}
			set
			{
				postalCodeValue = value;
			}
		}
		/// <summary>
		/// Country name component.
		/// </summary>
		private string countryValue;
	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string country
		{
			get
			{
				return countryValue;
			}
			set
			{
				countryValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Address()
		{
		
		}
		
	}
}


