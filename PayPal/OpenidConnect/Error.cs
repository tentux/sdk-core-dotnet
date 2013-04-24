
namespace PayPal.OpenidConnect
{
	public class Error
	{
		/// <summary>
		/// A single ASCII error code from the following enum.
		/// </summary>
		private string errorValue;
	
		public string error
		{
			get
			{
				return errorValue;
			}
			set
			{
				errorValue = value;
			}
		}
		/// <summary>
		/// A resource ID that indicates the starting resource in the returned results.
		/// </summary>
		private string errorDescriptionValue;
	
		public string errorDescription
		{
			get
			{
				return errorDescriptionValue;
			}
			set
			{
				errorDescriptionValue = value;
			}
		}
		/// <summary>
		/// A URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error.
		/// </summary>
		private string errorUriValue;
	
		public string errorUri
		{
			get
			{
				return errorUriValue;
			}
			set
			{
				errorUriValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Error()
		{
		
		}
		
		/// <summary>
		/// 
		/// </summary>
		public Error(string error)
		{
			this.error = error;
		}
		
	}
}


