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
        private string IPNEndpoint = string.Empty;
        private bool IsIPNVerified = false;
        private ConfigManager config = ConfigManager.Instance;
        private NameValueCollection ipnMap = new NameValueCollection();

        /// <summary>
        /// Exception log
        /// </summary>
        private static readonly ILog logger = LogManagerWrapper.GetLogger(typeof(IPNMessage));

        /// <summary>
        /// Constructs a QueryString (string).
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string ConstructQueryString(NameValueCollection parameters)
        {
            List<string> items = new List<string>();
            foreach (string name in parameters)
            {
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));
            }
            return string.Join("&", items.ToArray());
        }
        
        public IPNMessage(NameValueCollection nvc)
        {
            if (nvc.HasKeys())
            {
                foreach (string key in nvc.Keys)
                {
                    ipnMap.Add(key, nvc[key]);
                }           

                string ipnRequest = ConstructQueryString(nvc);

                ProcessRequest(ipnRequest);
            }

        }
        
        public void ProcessRequest(string ipnRequest)
        {
            IPNEndpoint = config.GetProperty(BaseConstants.IPNEndpoint);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(IPNEndpoint);
            
            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            ipnRequest += "&cmd=_notify-validate";
            req.ContentLength = ipnRequest.Length;
          
            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(ipnRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment

                IsIPNVerified = true;
                logger.Info(strResponse);
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation
                logger.Debug(strResponse);
            }
            else
            {
                //log response/ipn data for manual investigation
                logger.Debug(strResponse);
            }
        }

        public bool IPNVerification
        {
            get
            {
                return IsIPNVerified;
            }
        }

        public string IPNParameterValue(string ipnName)
        {
            return this.ipnMap[ipnName] != null ? this.ipnMap[ipnName] : null;
        }

        public string TransactionType
        {
            get
            {
                return this.ipnMap["txn_type"] != null ? this.ipnMap["txn_type"] :
                    (this.ipnMap["transaction_type"] != null ? this.ipnMap["transaction_type"] : null);
            }
        }
    }
}
