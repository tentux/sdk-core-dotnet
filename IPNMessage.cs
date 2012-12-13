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
        private string ipnEndpoint = string.Empty;
        private bool isIpnVerified = false;
        private ConfigManager configMgr = ConfigManager.Instance;
        private NameValueCollection nvcMap = new NameValueCollection();
        string ipnRequest = string.Empty;
      

        /// <summary>
        /// Exception log
        /// </summary>
        private static readonly ILog logger = LogManagerWrapper.GetLogger(typeof(IPNMessage));

        /// <summary>
        ///  Constructs a QueryString
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
            if (nvc.HasKeys())
            {
                foreach (string key in nvc.Keys)
                {
                    nvcMap.Add(key, nvc[key]);
                }
                ipnRequest = ConstructQueryString(nvc);
                ipnRequest += "&cmd=_notify-validate";
                Validate();
            }
        }      

        public bool Validate()
        {
            ipnEndpoint = configMgr.GetProperty(BaseConstants.IPNEndpoint);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ipnEndpoint);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";            
            req.ContentLength = ipnRequest.Length;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.GetEncoding("windows-1252"));
            streamOut.Write(ipnRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse.Equals("VERIFIED"))
            {
                isIpnVerified = true;
            }
            return isIpnVerified;           
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
