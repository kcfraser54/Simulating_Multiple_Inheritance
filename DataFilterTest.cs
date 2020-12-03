// Kyle Fraser
// 10/11/2020
// revision History:
// Drafted: 10/8/2020
// Revised: 10/11/2020
// Revised: 11/7/2020
// Revised: 11/8/2020




using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace P5
{
    [TestClass]
    public class dataFilterTest
    {
        [TestMethod]
        public void correctScrambleSequenceLargeMode()
        {

            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] expectedArray1 = new int[10] { 2000, 500, 42, 100, -5, -100, 5, 9, 18, 25 };
            int[] testArray2 = new int[5] { 65, 24, 55, 98, 110 };
            int[] expectedArray2 = new int[5] { 110, 98, 65, 24, 55 };
            int[] testArray3;

            dataFilter test1 = new dataFilter(true);

            testArray3 = test1.scramble(testArray1);


            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(testArray3[i], expectedArray1[i], 0);
            }

            testArray3 = test1.scramble(testArray2);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(testArray3[i], expectedArray2[i], 0);
            }


        }

        [TestMethod]
        public void correctScrambleSequenceSmallMode()
        {


            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] expectedArray1 = new int[10] { 25, 18, 9, 5, -100, -5, 100, 42, 500, 2000 };
            int[] testArray2 = new int[5] { 65, 24, 55, 98, 110 };
            int[] expectedArray2 = new int[5] { 55, 24, 65, 98, 110 };
            int[] testArray3;

            dataFilter test1 = new dataFilter(false);

            testArray3 = test1.scramble(testArray1);


            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(testArray3[i], expectedArray1[i], 0);
            }

            testArray3 = test1.scramble(testArray2);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(testArray3[i], expectedArray2[i], 0);
            }


        }



        [TestMethod]
        public void correctScrambleSizeLargeMode()
        {


            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] testArray2;
            int sizeCount = 0;
            int expectedSize = 10;
            dataFilter test2 = new dataFilter(true);

            testArray2 = test2.scramble(testArray1);

            foreach (int i in testArray2)
            {

                sizeCount++;

            }

            Assert.AreEqual(expectedSize, sizeCount, 0);

        }


        [TestMethod]

        public void correctScrambleSizeSmallMode()
        {

            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] testArray2;
            int sizeCount = 0;
            int expectedSize = 10;
            dataFilter test2 = new dataFilter(false);

            testArray2 = test2.scramble(testArray1);

            foreach (int i in testArray2)
            {

                sizeCount++;

            }

            Assert.AreEqual(expectedSize, sizeCount, 0);

        }



        [TestMethod]
        public void nullSequenceTest()
        {
            bool cmon = true;
            int sizeTest = 0;
            int[] testArray;
            dataFilter test3 = new dataFilter(cmon);

            testArray = test3.filter();

            foreach (int i in testArray)
            {

                sizeTest++;
            }

            Assert.AreEqual(1, sizeTest, 0);

        }


    }
}

