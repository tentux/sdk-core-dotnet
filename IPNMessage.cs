using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Specialized;

namespace PayPal
{
    public class IPNMessage
    {
        private bool IsIPNVerified = false;
        
        public void ProcessRequest(string ipnRequest)
        {
            //Post back to either sandbox or live
            string ipnSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            //string ipnLive = "https://www.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ipnSandbox);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            //byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);   
            //string strRequest = Encoding.ASCII.GetString(param);

            //string strRequest = ConstructQueryString(parameters);

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
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation
            }
            else
            {
                //log response/ipn data for manual investigation
            }
        }

        public bool IPNVerification       
        {
            get
            {
                return IsIPNVerified;
            }
        }
    }
}
