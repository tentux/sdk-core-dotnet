using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using NUnit.Framework;
using PayPal.Manager;

namespace PayPal.UnitTest.Manager
{
    [TestFixture]
    class ConfigManagerTest
    {
        ConfigManager configMngr;

        [Test]
        public void RetrieveValidProperty()
        {
            configMngr = ConfigManager.Instance;
            string endpoint = configMngr.GetProperty("endpoint");
            Assert.IsNotNull(endpoint);
            Assert.AreEqual(UnitTestConstants.APIEndpointNVP, endpoint);
            string connectionTimeout = configMngr.GetProperty("connectionTimeout");
            Assert.IsNotNull(connectionTimeout);
            Assert.AreEqual("360000", connectionTimeout);
        }

        [Test]
        public void RetrieveNonExistentProperty()
        {
            configMngr = ConfigManager.Instance;
            string endpoint = configMngr.GetProperty("endpointMisspelt");
            Assert.IsNull(endpoint);
        }

    }
}
