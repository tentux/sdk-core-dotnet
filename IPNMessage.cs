using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.IO;
using log4net;
using PayPal.Manager;

namespace PayPal
{
    public class IPNMessage
    {
        
        /// <summary>
        /// Result from ipn validation call
        /// </summary>
        private bool? ipnValidationResult;        
        /// <summary>
        /// Name value collection containing incoming IPN message key / value pair
        /// </summary>
        private NameValueCollection nvcMap = new NameValueCollection();
        /// <summary>
        /// Incoming IPN message converted to query string format. Used when validating the IPN message.
        /// </summary>
        private string ipnRequest = string.Empty;

        private ConfigManager configMgr = ConfigManager.Instance;

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog logger = LogManagerWrapper.GetLogger(typeof(IPNMessage));

        /// <summary>
        /// Constructs a query string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string ConstructQueryString(NameValueCollection parameters)
        {
            List<string> items = new List<string>();
            foreach (string name in parameters)
            {
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name], Encoding.GetEncoding("windows-1252"))));
            }
            return string.Join("&", items.ToArray());
        }

        /// <summary>
        /// IPNMessage constructor
        /// </summary>
        /// <param name="nvc"></param>
        public IPNMessage(NameValueCollection nvc)
        {
            try
            {
                if (nvc.HasKeys())
                {
                    foreach (string key in nvc.Keys)
                    {
                        nvcMap.Add(key, nvc[key]);
                    }
                    ipnRequest = ConstructQueryString(nvc);
                    ipnRequest += "&cmd=_notify-validate";
                }
            }
            catch (System.Exception ex)
            {
                logger.Debug(this.GetType().Name + " : " + ex.Message);
            }
        }

        /// <summary>
        /// IPNMessage constructor
        /// </summary>
        /// <param name="request"></param>
        public IPNMessage(HttpRequest request) : this(request.Params) { }
        
        /// <summary>
        /// Returns the IPN request validation
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            /// If ipn has been previously validated, do not repeat the validation process.
            if (this.ipnValidationResult != null)
            {
                return this.ipnValidationResult.Value;
            }
            else
            {
                try
                {
                    string ipnEndpoint = configMgr.GetProperty(BaseConstants.IPNEndpoint);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ipnEndpoint);

                    //Set values for the request back
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = ipnRequest.Length;

                    //Send the request to PayPal and get the response
                    StreamWriter streamOut = new StreamWriter(request.GetRequestStream(), Encoding.GetEncoding("windows-1252"));
                    streamOut.Write(ipnRequest);
                    streamOut.Close();
                    StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream());
                    string strResponse = streamIn.ReadToEnd();
                    streamIn.Close();

                    if (strResponse.Equals("VERIFIED"))
                    {
                        this.ipnValidationResult = true;
                    }
                    else
                    {
                        logger.Info("IPN validation failed. Got response: " + strResponse);
                        this.ipnValidationResult = false;
                    }
                }
                catch (System.Exception ex)
                {
                    logger.Info(this.GetType().Name + " : " + ex.Message);

                }
                return this.ipnValidationResult.HasValue ? this.ipnValidationResult.Value : false;
            }
        }

        /// <summary>
        /// Gets the IPN request NameValueCollection
        /// </summary>
        public NameValueCollection IpnMap
        {
            get
            {
                return nvcMap;
            }
        }
      
        /// <summary>
        /// Gets the IPN request parameter value for the given name
        /// </summary>
        /// <param name="ipnName"></param>
        /// <returns></returns>
        public string IpnValue(string ipnName)
        {
            return this.nvcMap[ipnName];
        }
        
        /// <summary>
        /// Gets the IPN request transaction type
        /// </summary>
        public string TransactionType
        {
            get
            {
                return this.nvcMap["txn_type"] != null ? this.nvcMap["txn_type"] :
                    (this.nvcMap["transaction_type"] != null ? this.nvcMap["transaction_type"] : null);
            }
        }
    }
}
