using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PayPal;

namespace PayPal.UnitTest
{
    [TestFixture]
    class IPNMessageTest
    {
        [Test]
        public void ProcessRequestTest()
        {
            string ipnPay = "payment_request_date=Fri+Dec+07+06%3A13%3A08+PST+2012&return_url=http%3A//localhost%3A2646/Pay.aspx&fees_payer=EACHRECEIVER&ipn_notification_url=https%3A//paypalipntomato.pagekite.me&sender_email=platfo_1255077030_biz%40gmail.com&verify_sign=A356shdxpagv3WFZg1T-KSV2n84QA88bVSENpWDwz.4qI.LH3cEDzt6U&test_ipn=1&transaction%5B0%5D.id_for_sender_txn=2PY733205A444370A&transaction%5B0%5D.receiver=platfo_1255612361_per%40gmail.com&cancel_url=http%3A//localhost%3A2646/Pay.aspx&transaction%5B0%5D.is_primary_receiver=false&pay_key=AP-9TD446890S775454W&action_type=PAY&transaction%5B0%5D.id=2VC06876VP3217226&memo=AustraliaMemo&transaction%5B0%5D.status=Completed&transaction%5B0%5D.paymentType=SERVICE&transaction%5B0%5D.status_for_sender_txn=Completed&transaction%5B0%5D.pending_reason=NONE&transaction_type=Adaptive+Payment+PAY&transaction%5B0%5D.amount=USD+1.00&status=COMPLETED&log_default_shipping_address_in_transaction=false&charset=windows-1252&notify_version=UNVERSIONED&reverse_all_parallel_payments_on_error=false";
            IPNMessage ipn = new IPNMessage();
            ipn.ProcessRequest(ipnPay);
            Assert.IsTrue(ipn.IPNVerification);
        }
    }
}
