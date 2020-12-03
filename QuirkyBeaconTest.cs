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
    public class QuirkyBeaconTest
    {
        private const int TEST_NUM = 10;
        private const int FORCE_TURN_OFF = 25;
        private const int TURN_OFFS_ALLOWED = 3;

        [TestMethod]
        public void turnOnThreeTimesTest()
        {
            int turnedOnCount = 0;

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new QuirkyBeacon();
            string testOutput;
            

            testBeacon.giveSignalInput(testArray);
            for (int i = 0; i < FORCE_TURN_OFF; i++)
            {
                testOutput = testBeacon.emitSignal();

                if(testOutput == "0")
                {
                    testBeacon.turnOn();
                    testBeacon.recharge();
                    turnedOnCount++;
                    if(turnedOnCount > TURN_OFFS_ALLOWED)
                    {

                        Assert.AreEqual("0", testOutput);
                    }


                }

            }


        }

        [TestMethod]

        public void evenSignalTest()
        {

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 10, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new QuirkyBeacon();
            string testOutput;

            testBeacon.giveSignalInput(testArray);
            testOutput = testBeacon.emitSignal();

            Assert.AreEqual("WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB", testOutput);


        }

        [TestMethod]

        public void oddSignalTest()
        {

            int[] testArray = new int[TEST_NUM] { 2, 4, 6, 8, 9, 10, 12, 14, 16, 18 };
            Beacon testBeacon = new QuirkyBeacon();
            string testOutput;

            testBeacon.giveSignalInput(testArray);
            testOutput = testBeacon.emitSignal();

            Assert.AreEqual("WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB", testOutput);


        }
    }
}
