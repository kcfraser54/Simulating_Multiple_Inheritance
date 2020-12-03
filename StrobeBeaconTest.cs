// Kyle Fraser
// 11/9/2020
// revision History:
// Drafted: 10/8/2020
// Revised: 10/11/2020
// Revised: 11/7/2020
// Revised: 11/8/2020

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P5
{
    [TestClass]
    public class StrobeBeaconTest
    {

        private const int TEST_NUM = 10;

        [TestMethod]
        public void OscillateHighTest()
        { 

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new StrobeBeacon();

            testBeacon.giveSignalInput(testArray);
            string testOutput = testBeacon.emitSignal();

            Assert.AreEqual("WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB", testOutput);


        }

        [TestMethod]
        public void OscillateLowTest()
        {

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new StrobeBeacon();

            testBeacon.giveSignalInput(testArray);
            string testOutput = testBeacon.emitSignal();
            string testOutput2 = testBeacon.emitSignal();

            Assert.AreEqual("WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB", testOutput);

            Assert.AreEqual("WuBWuBWuBWuBWuB", testOutput2);


        }

        [TestMethod]
        public void noRechargeTest()
        {

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new StrobeBeacon();

            testBeacon.giveSignalInput(testArray);
            for (int i = 0; i < TEST_NUM; i++)
            {
                testBeacon.emitSignal();

            }

            testBeacon.turnOn();
            testBeacon.recharge();
            string testOutput = testBeacon.emitSignal();

            Assert.AreEqual("-1", testOutput);
            

        }

        [TestMethod]
        public void turnedOffAfterChargeDepletedTest()
        {

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new StrobeBeacon();

            testBeacon.giveSignalInput(testArray);
            for (int i = 0; i < TEST_NUM; i++)
            {
                testBeacon.emitSignal();

            }

            Assert.AreEqual("0", testBeacon.emitSignal());


        }
    }
}
