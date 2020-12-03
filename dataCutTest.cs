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
    public class dataCutTest
    {
        [TestMethod]
        public void correctScrambleSequenceLargeMode()
        {
            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };    
            int[] testArray2 = new int[10] { 25, 26, 27, 28, 29, 30, 31, 18, 32, 33 };
            int[] expectedArray = new int[8] { 33, 31, 30, 29, 28, 27, 26, 32 };
            int[] testArray3;



            dataCut test1 = new dataCut(true);

            testArray3 = test1.scramble(testArray1);
            testArray3 = test1.scramble(testArray2);

            for (int i = 0; i < 8; i++)
            {

                Assert.AreEqual(testArray3[i], expectedArray[i], 0);


            }

        }

        [TestMethod]
        public void correctScrambleSequenceSmallMode()
        {

            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] testArray2 = new int[10] { 25, 26, 27, 28, 29, 30, 31, 18, 32, 33 };
            int[] expectedArray = new int[8] { 32, 26, 27, 28, 29, 30, 31, 33 };
            int[] testArray3;



            dataCut test1 = new dataCut(false);

            testArray3 = test1.scramble(testArray1);
            testArray3 = test1.scramble(testArray2);

            for (int i = 0; i < 8; i++)
            {

                Assert.AreEqual(testArray3[i], expectedArray[i], 0);


            }



        }

        [TestMethod]

        public void correctScrambleSizeLargeMode()   
        {


            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };    
            int[] testArray2 = new int[10] { 25, 26, 27, 28, 29, 30, 31, 18, 32, 33 };
            int[] expectedArray = new int[8] { 33, 31, 30, 29, 28, 27, 26, 32 };
            int[] testArray3;



            dataCut test1 = new dataCut(true);

            testArray3 = test1.scramble(testArray1);
            testArray3 = test1.scramble(testArray2);

            Assert.AreEqual(testArray3.Length, expectedArray.Length, 0);

           

        }

        public void correctScrambleSizeSmallMode()
        {

            int[] testArray1 = new int[10] { 25, 18, 42, 100, -100, -5, 5, 9, 500, 2000 };
            int[] testArray2 = new int[10] { 25, 26, 27, 28, 29, 30, 31, 18, 32, 33 };
            int[] expectedArray = new int[8] { 33, 31, 30, 29, 28, 27, 26, 32 };
            int[] testArray3;



            dataCut test1 = new dataCut(false);

            testArray3 = test1.scramble(testArray1);
            testArray3 = test1.scramble(testArray2);

            Assert.AreEqual(testArray3.Length, expectedArray.Length, 0);

        }

        [TestMethod]
        public void nullSequenceTest()
        {

            int sizeTest = 0;
            int[] testArray;

            dataCut test3 = new dataCut(true);

            testArray = test3.filter();
            foreach (int i in testArray)
            {

                sizeTest++;
            }

            Assert.AreEqual(1, sizeTest, 0);

        }

    }
}

