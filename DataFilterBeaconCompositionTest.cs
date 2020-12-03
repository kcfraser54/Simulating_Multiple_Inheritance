// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/7/2020
// Revised: 11/8/2020
// Revised: 11/9/2020


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P5
{
    [TestClass]
    public class dataFilterBeaconCompositionTest
    {

        const int dataFilterOrBeacon = 1;
        const int dataModOrStrobeBeacon = 2;
        const int dataCutOrQuirkyBeacon = 3;
        const bool dataFilterLargeMode = true;
        const int SEQUENCE_SIZE_TEST_NUM = 10;

        [TestMethod]
        public void dataFilterBeaconScrambleSignal()
        {
            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};
            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataFilterOrBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataFilterOrBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuB";

            string actualLarge = test1.EmitScrambledSignal(testArray1);
            string actualSmall = test2.EmitScrambledSignal(testArray2);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }

        [TestMethod]
        public void dataFilterStrobeBeaconSignal()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataModOrStrobeBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataModOrStrobeBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";

            test1.EmitScrambledSignal(testArray1);
            string actualLarge = test1.EmitScrambledSignal(testArray1);
            string actualSmall = test2.EmitScrambledSignal(testArray2);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);


        }

        [TestMethod]
        public void dataFilterQuirkyBeaconSignal()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataCutOrQuirkyBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataFilterOrBeacon, dataCutOrQuirkyBeacon, !dataFilterLargeMode);

            string expectedLarge = "";
            string expectedSmall = "";

            for(int i = 0; i < 48; i++)
            {

                expectedSmall += "WuB";
            }

            string actualLarge = test1.EmitScrambledSignal(testArray1);
            string actualSmall = test2.EmitScrambledSignal(testArray2);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);
        }

        [TestMethod]
        public void dataModBeaconScramble()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] { 419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952 };

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataFilterOrBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataFilterOrBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";

            string actualLarge = test1.EmitScrambledSignal(testArray1);
            string actualSmall = test2.EmitScrambledSignal(testArray2);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }

        [TestMethod]
        public void dataModStrobeBeaconScramble()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] { 419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952 };

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataModOrStrobeBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataModOrStrobeBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuB";

            string actualLarge = test1.EmitScrambledSignal(testArray1);
            test2.EmitScrambledSignal(testArray2);
            string actualSmall = test2.EmitScrambledSignal(testArray2);
            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }

        [TestMethod]
        public void dataModQuirkyBeaconScramble()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataCutOrQuirkyBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataModOrStrobeBeacon, dataCutOrQuirkyBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";

            string actualLarge = test1.EmitScrambledSignal(testArray1);
            string actualSmall = test2.EmitScrambledSignal(testArray1);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }

        [TestMethod]
        public void dataCutBeaconScramble()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};
            int[] testArray3 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 88, 25, 11764, 912, 952, 5, 6, 7, 999};
            int[] testArray4 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, -250, -16874, 21, -21, 75, 76, 115, 116, 224};

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataFilterOrBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataFilterOrBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuB";

            test1.EmitScrambledSignal(testArray1);
            test2.EmitScrambledSignal(testArray2);

            string actualLarge = test1.EmitScrambledSignal(testArray3);
            string actualSmall = test2.EmitScrambledSignal(testArray4);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }

        [TestMethod]
        public void dataCutStrobeBeaconScramble()
        {
            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};
            int[] testArray3 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 88, 25, 11764, 912, 952, 5, 6, 7, 999};
            int[] testArray4 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, -250, -16874, 21, -21, 75, 76, 115, 116, 224};

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataModOrStrobeBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataModOrStrobeBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuB";

            test1.EmitScrambledSignal(testArray1);
            test2.EmitScrambledSignal(testArray2);

            string actualLarge = test1.EmitScrambledSignal(testArray3);
            string actualSmall = test2.EmitScrambledSignal(testArray4);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);
        }

        [TestMethod]
        public void dataCutQuirkyBeaconScramble()
        {

            int[] testArray1 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 2003, 11764, 8000, 912, 1000, 45, 13227, 6636, 952};
            int[] testArray2 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, 17, -4045, 1608, -250, -16874, 7113, -3987, -21, 500};
            int[] testArray3 = new int[SEQUENCE_SIZE_TEST_NUM] {419, 88, 25, 11764, 912, 952, 5, 6, 7, 999};
            int[] testArray4 = new int[SEQUENCE_SIZE_TEST_NUM] {18520, -250, -16874, 21, -21, 75, 76, 115, 116, 224};

            dataFilterBeaconComposition test1 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataCutOrQuirkyBeacon, dataFilterLargeMode);
            dataFilterBeaconComposition test2 = new dataFilterBeaconComposition(dataCutOrQuirkyBeacon, dataCutOrQuirkyBeacon, !dataFilterLargeMode);

            string expectedLarge = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";
            string expectedSmall = "WuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuBWuB";

            test1.EmitScrambledSignal(testArray1);
            test2.EmitScrambledSignal(testArray2);

            string actualLarge = test1.EmitScrambledSignal(testArray3);
            string actualSmall = test2.EmitScrambledSignal(testArray4);

            Assert.AreEqual(expectedLarge, actualLarge);
            Assert.AreEqual(expectedSmall, actualSmall);

        }
    }
}



