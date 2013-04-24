
namespace PayPal.OpenidConnect
{
	public class Address
	{
		/// <summary>
		/// Full street address component, which may include house number, street name.
		/// </summary>
		private string streetAddressValue;
	
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


