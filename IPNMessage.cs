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
        private ConfigManager configMgr = ConfigManager.Instance;
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
                    ipnMap.Add(key, nvc[key]);
                }

                string ipnRequest = ConstructQueryString(nvc);

                ProcessRequest(ipnRequest);
            }
        }

        /// <summary>
        /// Processes request for IPN verification
        /// </summary>
        /// <param name="ipnRequest"></param>
        public void ProcessRequest(string ipnRequest)
        {
            IPNEndpoint = configMgr.GetProperty(BaseConstants.IPNEndpoint);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(IPNEndpoint);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            ipnRequest += "&cmd=_notify-validate";
            req.ContentLength = ipnRequest.Length;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(ipnRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                IsIPNVerified = true;
                logger.Info("--IPN--VERIFIED--Start");
                logger.Info(strResponse);
                logger.Info("--IPN--VERIFIED--End");
            }
            else if (strResponse == "INVALID")
            {
                logger.Info("--IPN--INVALID--Start");
                logger.Debug(strResponse);
                logger.Info("--IPN--INVALID--End");
            }
            else
            {
                logger.Info("--IPN--Null--Or--Error--Start");
                logger.Debug(strResponse);
                logger.Info("--IPN--Null--Or--Error--End");
            }
        }

        /// <summary>
        /// Gets the IPN request verification status
        /// </summary>
        public bool IPNVerification
        {
            get
            {
                return IsIPNVerified;
            }
        }

        /// <summary>
        /// Gets the IPN request parameter value for the given name
        /// </summary>
        /// <param name="ipnName"></param>
        /// <returns></returns>
        public string IPNParameter(string ipnName)
        {
            return this.ipnMap[ipnName] != null ? this.ipnMap[ipnName] : null;
        }

        /// <summary>
        /// Gets the IPN request transaction type
        /// </summary>
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
