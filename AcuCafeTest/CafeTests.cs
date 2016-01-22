using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcuCafe;

namespace AcuCafeTest
{
    [TestClass]
    public class CafeTests
    {

        /// <summary>
        /// this is a real unit test to check IceTea
        /// </summary>
        [TestMethod]
        public void IceTeaTest()
        {
            AcuCafe.IceTea myiceTea = new AcuCafe.IceTea();
            Assert.AreEqual(null, myiceTea.HasError);
            myiceTea.HasMilk = true;
            Assert.AreEqual("IceTea can not be made with Milk, no drink made.", myiceTea.HasError);
        }
        /// <summary>
        /// this is a real unit test to check Expresso
        /// </summary>
        [TestMethod]
        public void ExpressoTest()
        {
            AcuCafe.Expresso myexpresso = new AcuCafe.Expresso();
            Assert.AreEqual(null, myexpresso.HasError);
            myexpresso.HasMilk = true;
            Assert.AreEqual(null, myexpresso.HasError);
        }

        /// <summary>
        /// this was only for debug tests, no assertions are here
        /// </summary>
        [TestMethod]
        public void OrderDrinkTest()
        {
            AcuCafe.AcuCafe.OrderDrink("IceTea", true, true);
        }

        //more test methods to fol;low
    }
}
