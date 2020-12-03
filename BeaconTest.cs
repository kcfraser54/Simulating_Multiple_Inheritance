// Kyle Fraser
// 11/9/2020
// revision History:
// Drafted: 10/8/2020
// Revised: 10/11/2020
// Revised: 11/7/2020
// Revised: 11/8/2020

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P5{


    [TestClass]
    public class BeaconTest
    {


        private const int TEST_NUM = 10;

        [TestMethod]
        public void TurnOffIfEmptyArray()
        {
            int[] testArray = new int[0];
            Beacon testBeacon = new Beacon();
            string signal;
            testBeacon.giveSignalInput(testArray);
            signal = testBeacon.emitSignal();

            Assert.AreEqual(signal, "0");

        }


        [TestMethod]

        public void turnOffIfNotCharged()
        {

            Beacon testBeacon = new Beacon();
            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20};
            string signal;

            for(int i = 0; i < TEST_NUM; i++)
            {
               testBeacon.giveSignalInput(testArray); 
               signal =  testBeacon.emitSignal();

            }

            Assert.AreEqual(testBeacon.emitSignal(), "0");


        }


        [TestMethod]

        public void correctSignal()
        {
            Beacon testBeacon = new Beacon();
            int[] testArray = new int[10] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            string expected = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";

            testBeacon.giveSignalInput(testArray);
            Assert.AreEqual(testBeacon.emitSignal(), expected);

        }

        [TestMethod]

        public void onAndNotChargedTest()
        {

            Beacon testBeacon = new Beacon();
            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            string signal;

            for (int i = 0; i < TEST_NUM; i++)
            {
                testBeacon.giveSignalInput(testArray);
                signal = testBeacon.emitSignal();

            }

            testBeacon.turnOn();

            Assert.AreEqual(testBeacon.emitSignal(), "-1");

        }

        [TestMethod]
        public void rechargeTest()
        {

            Beacon testBeacon = new Beacon();
            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            string signal;

            for (int i = 0; i < TEST_NUM; i++)
            {
                testBeacon.giveSignalInput(testArray);
                signal = testBeacon.emitSignal();

            }

            Assert.AreEqual(testBeacon.emitSignal(), "0");

            testBeacon.turnOn();
            testBeacon.recharge();

            Assert.AreEqual(testBeacon.emitSignal(), "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuB");

        }

        [TestMethod]

        public void isOnCorrectlyWorkingTest() 
        {

            Beacon testBeacon = new Beacon();
            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            testBeacon.giveSignalInput(testArray);
            testBeacon.turnOn();
            Assert.AreEqual(testBeacon.emitSignal(), "0");

            testBeacon.turnOn();
            Assert.AreEqual(testBeacon.emitSignal(), "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuB");





        }


    }
}
