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
    public class dataModTest
    {
        [TestMethod]
        public void correctScrambleSequenceLargeMode()
        {

            int[] testArray1 = new int[8] { 17, 23, 45, 100, 4, 19, 22, 200 };
            int[] expectedArray1 = new int[8] { 200, 22, 45, 100, 4, 2, 2, 2 };
            int[] testArray2 = new int[5] { 17, 19, 23, 100, 200 };
            int[] expectedArray2 = new int[5] { 200, 100, 2, 2, 2 };
            int[] testArray3;



            dataMod test1 = new dataMod(true);

            testArray3 = test1.scramble(testArray1);

            for (int i = 0; i < 8; i++)
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


            int[] testArray1 = new int[8] { 17, 23, 45, 100, 4, 19, 22, 200 };
            int[] expectedArray1 = new int[8] { 2, 2, 2, 4, 100, 45, 22, 200 };
            int[] testArray2 = new int[5] { 17, 100, 200, 23, 19 };
            int[] expectedArray2 = new int[5] { 2, 2, 200, 100, 2 };
            int[] testArray3;



            dataMod test1 = new dataMod(false);

            testArray3 = test1.scramble(testArray1);

            for (int i = 0; i < 8; i++)
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
            dataMod test2 = new dataMod(true);

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
            dataMod test2 = new dataMod(false);

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
            int sizeTest = 0;
            int[] testArray;
            dataMod test5 = new dataMod(true);

            testArray = test5.filter();
            foreach (int i in testArray)
            {

                sizeTest++;
            }

            Assert.AreEqual(1, sizeTest, 0);

        }





    }
}

