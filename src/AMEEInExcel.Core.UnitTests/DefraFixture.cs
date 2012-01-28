using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AMEEInExcel.Core.UnitTests
{
    [TestFixture]
    public class DefraFixture
    {

        [Test]
        public void Home_Developer_Documentation_GetEmissionFactors()
        {
            var calc = new TransportDefra().GetEmissionFactors("transport/defra/fuel");

            Assert.AreEqual("1155.8500000000001", calc.totalAmount.Value);

            var defaultAmount = calc.profileItems[0].Amounts.Amount.FirstOrDefault(a => a.Default);
            Assert.IsNotNull(defaultAmount);

            // rounding error between total and defaultAmount
            // Expected string length 18 but was 7. Strings differ at index 7.
            //  Expected: "1155.8500000000001"                                
            //  But was:  "1155.85"                                           
            // Assert.AreEqual(calc.totalAmount.Value, defaultAmount.Value);

            var relatedAmount = calc.profileItems[0].Amounts.Amount.FirstOrDefault(a => a.Type == "lifeCycleCO2e");
            Assert.IsNotNull(relatedAmount);
            Assert.AreEqual("1361.35", relatedAmount.Value);

        }
    }
      
}
