// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/5/2020
// Revised: 11/6/2020
// Revised: 11/7/2020
// Revised: 11/8/2020
// Revised: 11/9/2020
// Revised: 11/10/2020


// Program Overview
//---------------------------------------------------------------------------------------

// This program is designed to test functionality defined for the cross product 
// of the dataFilter and Beacon class hierarchies. 


// Assumptions
//---------------------------------------------------------------------------------------

// The user must specify which dataFilter is in use.

// The user must specify which beacon is in use.

// The user must specify what mode the dataFilter is in. 

// The user may change the mode. 

// Depending on the type of beacon, the user may recharge the beacon.

// The user may turn the beacon on.

// The object may function as a beacon.

// The object may function as a dataFilter. 


using System;

namespace P5
{
    class Program
    {

        const int DATAFILTER_OR_BEACON = 1;
        const int DATAMOD_OR_STROBEBEACON = 2;
        const int DATACUT_OR_QUIRKYBEACON = 3;
        const int TEST_ITERATION1 = 0;
        const int TEST_ITERATION2 = 1;
        const int TEST_ITERATION3 = 2;
        const int TEST_ITERATION4 = 3;
        const int TEST_ITERATION5 = 4;
        const int TEST_ITERATIONS = 5;
        const int SEQUENCE_STARTING_LENGTH = 10;
        const bool DATAFILTERLARGEMODE = true;
        const int MODE_CHANGE = 3;
        
        
        static void Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine("Welcome, this program demonstrates the functionality of the composition of");
            Console.WriteLine("dataFilter and Beacon Objects");
            Console.WriteLine();

            dataFilterBeaconTest();
            dataFilterStrobeBeaconTest();
            dataFilterQuirkyBeaconTest();

            dataModBeaconTest();
            dataModStrobeBeaconTest();
            dataModQuirkyBeaconTest();

            dataCutBeaconTest();
            dataCutStrobeBeaconTest();
            dataCutQuirkyBeaconTest();

            Console.WriteLine();
            Console.WriteLine("End of Tests");
            Console.WriteLine();

        }

        public static void dataFilterBeaconTest()
        {

            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900};
            int[] testArray2 = new int[10] {21, 23, 543, 34, 28, 1, 6, 200, 201, 198};
            int[] testArray3 = new int[10] {35, 15, 55, -55, 85, 92, 93, 94, 95, 12};
            int[] testArray4 = new int[10] {35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5};
            int[] testArray5 = new int[10] {100, 50, 200, 150, 300, 350, 275, 957, 857, 999};
           
            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++) {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATAFILTER_OR_BEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATAFILTER_OR_BEACON, !DATAFILTERLARGEMODE);

                }
            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of beacon...");
            Console.WriteLine();

            for(int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {

                    DFB[i].inputSignal(testArray1);
                    Console.WriteLine();
                    Console.WriteLine("Signal 1: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if(i == TEST_ITERATION2)
                {
                    DFB[i].inputSignal(testArray2);
                    Console.WriteLine();
                    Console.WriteLine("Signal 2: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if(i == TEST_ITERATION3)
                {

                    DFB[i].inputSignal(testArray3);
                    Console.WriteLine();
                    Console.WriteLine("Signal 3: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if(i == TEST_ITERATION4)
                {
                    DFB[i].inputSignal(testArray4);
                    Console.WriteLine();
                    Console.WriteLine("Signal 4: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if(i == TEST_ITERATION5)
                {
                    DFB[i].inputSignal(testArray5);
                    Console.WriteLine();
                    Console.WriteLine("Signal 5: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }


            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataFilter...");
            Console.WriteLine();

            for(int i = 0; i < TEST_ITERATIONS; i++)
            {

                int[] expectedScrambleArray;
                int[] expectedFilterArray;
                if (i == TEST_ITERATION1)
                {
                    Console.Write("Scrambled sequence 1: ");

                    expectedScrambleArray = DFB[i].simpleScramble(testArray1);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if(i == TEST_ITERATION2)    
                {
                    Console.Write("Scrambled sequence 2: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray2);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION3)
                {
                    Console.Write("Scrambled sequence 3: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray3);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION4)
                {
                    Console.Write("Scrambled sequence 4: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray4);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION5)
                {
                    Console.Write("Scrambled sequence 5: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray5);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }


                expectedFilterArray = DFB[i].simpleFilter();
                Console.WriteLine();

                Console.Write("Filtered sequence: " + (i + 1) + ": ");
                for (int j = 0; j < expectedFilterArray.Length; j++)
                {
                   
                    Console.Write(expectedFilterArray[j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
                Console.WriteLine();

            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataFilter and Beacon combined...");
            Console.WriteLine();

            for(int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }


            }

            Console.WriteLine();

        }

        
        public static void dataFilterStrobeBeaconTest()
        {

            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };


            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATAMOD_OR_STROBEBEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATAMOD_OR_STROBEBEACON, !DATAFILTERLARGEMODE);

                }
            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of strobeBeacon...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {

                    DFB[i].inputSignal(testArray1);
                    Console.WriteLine();
                    Console.WriteLine("High oscillating signal 1: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine("Low oscillating sigal 1: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if (i == TEST_ITERATION2)
                {
                    DFB[i].inputSignal(testArray2);
                    Console.WriteLine();
                    Console.WriteLine("High oscillating signal 2: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine("Low oscillating signal 2: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if (i == TEST_ITERATION3)
                {

                    DFB[i].inputSignal(testArray3);
                    Console.WriteLine();
                    Console.WriteLine("High oscillating signal 3: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine("Low oscillating signal 3: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if (i == TEST_ITERATION4)
                {
                    DFB[i].inputSignal(testArray4);
                    Console.WriteLine();
                    Console.WriteLine("High oscillating signal 4: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine("Low oscillating signal 4: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if (i == TEST_ITERATION5)
                {
                    DFB[i].inputSignal(testArray5);
                    Console.WriteLine();
                    Console.WriteLine("Hiigh oscillating signal 5: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine("Low oscillating signal 5: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

            }

           

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataFilter and StrobeBeacon combined...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                    
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered Signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }



            }

            Console.WriteLine();

        }

        public static void dataFilterQuirkyBeaconTest()
        {

         
            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] {18, 22, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 28, 958, 856, 999 };

            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                if (i < MODE_CHANGE)
                {
                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATACUT_OR_QUIRKYBEACON, DATAFILTERLARGEMODE);
                }
                else
                {
                    DFB[i] = new dataFilterBeaconComposition(DATAFILTER_OR_BEACON, DATACUT_OR_QUIRKYBEACON, !DATAFILTERLARGEMODE);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of QuirkyBeacon...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {

                    DFB[i].inputSignal(testArray1);
                    Console.WriteLine();
                    Console.WriteLine("Signal 1: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if (i == TEST_ITERATION2)
                {
                    DFB[i].inputSignal(testArray2);
                    Console.WriteLine();
                    Console.WriteLine("Signal 2: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }

                else if (i == TEST_ITERATION3)
                {

                    DFB[i].inputSignal(testArray3);
                    Console.WriteLine();
                    Console.WriteLine("Signal 3: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if (i == TEST_ITERATION4)
                {
                    DFB[i].inputSignal(testArray4);
                    Console.WriteLine();
                    Console.WriteLine("Signal 4: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();
                }

                else if (i == TEST_ITERATION5)
                {
                    DFB[i].inputSignal(testArray5);
                    Console.WriteLine();
                    Console.WriteLine("Signal 5: " + DFB[i].SimpleEmitSignal());
                    Console.WriteLine();

                }



            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataFilter and QuirkyBeacon combined...");
            Console.WriteLine();

        
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }

            }

            Console.WriteLine();

        }

        public static void dataModBeaconTest()
        {

            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };

            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATAFILTER_OR_BEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATAFILTER_OR_BEACON, !DATAFILTERLARGEMODE);

                }
            }

          

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataMod...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                int[] expectedScrambleArray;
                int[] expectedFilterArray;
                if (i == TEST_ITERATION1)
                {
                    Console.Write("Scrambled sequence 1: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray1);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION2)
                {
                    Console.Write("Scrambled sequence 2: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray2);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION3)
                {
                    Console.Write("Scrambled sequence 3: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray3);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION4)
                {
                    Console.Write("Scrambled sequence 4: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray4);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION5)
                {
                    Console.Write("Scrambled sequence 5: ");
                    expectedScrambleArray = DFB[i].simpleScramble(testArray5);
                    for (int j = 0; j < SEQUENCE_STARTING_LENGTH; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                expectedFilterArray = DFB[i].simpleFilter();
                Console.WriteLine();

                Console.Write("Filtered sequence " + (i + 1) + ": ");
                for (int j = 0; j < expectedFilterArray.Length; j++)
                {
                    Console.Write(expectedFilterArray[j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
                Console.WriteLine();


            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataMod and Beacon combined...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled sigal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }

            }

            Console.WriteLine();

        }

        public static void dataModStrobeBeaconTest()
        {
 
            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };


            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATAMOD_OR_STROBEBEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATAMOD_OR_STROBEBEACON, !DATAFILTERLARGEMODE);

                }
            }

      
            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataMod and StrobeBeacon combined...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }

            }

            Console.WriteLine();


        }

        public static void dataModQuirkyBeaconTest()
        {


            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };


            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATACUT_OR_QUIRKYBEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATAMOD_OR_STROBEBEACON, DATACUT_OR_QUIRKYBEACON, !DATAFILTERLARGEMODE);

                }
            }


            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataMod and QuirkyBeacon combined...");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }


            }

            Console.WriteLine();


        }

        public static void dataCutBeaconTest()
        {

           
            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 21, 22, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 21, 22, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 21, 22, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 22, 21, 275, 957, 857, 999 };


            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATAFILTER_OR_BEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATAFILTER_OR_BEACON, !DATAFILTERLARGEMODE);

                }
            }


            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataCut");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                int[] expectedScrambleArray;
                int[] expectedFilterArray;
                if (i == TEST_ITERATION1)
                {
                    DFB[i].simpleScramble(testArray1);
                    expectedScrambleArray = DFB[i].simpleScramble(testArray2);
                    Console.Write("Scrambled sequence 1: ");
                    for (int j = 0; j < expectedScrambleArray.Length; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION2)
                {
                    DFB[i].simpleScramble(testArray2);
                    expectedScrambleArray = DFB[i].simpleScramble(testArray3);
                    Console.Write("Scrambled sequence 2: ");
                    for (int j = 0; j < expectedScrambleArray.Length; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION3)
                {
                    DFB[i].simpleScramble(testArray3);
                    expectedScrambleArray = DFB[i].simpleScramble(testArray4);
                    Console.Write("Scrambled sequence 3: ");
                    for (int j = 0; j < expectedScrambleArray.Length; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION4)
                {
                    DFB[i].simpleScramble(testArray4);
                    expectedScrambleArray = DFB[i].simpleScramble(testArray5);
                    Console.Write("Scrambled sequence 4: ");
                    for (int j = 0; j < expectedScrambleArray.Length; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                else if (i == TEST_ITERATION5)
                {
                    DFB[i].simpleScramble(testArray1);
                    expectedScrambleArray = DFB[i].simpleScramble(testArray5);
                    Console.Write("Scrambled equence 5: ");
                    for (int j = 0; j < expectedScrambleArray.Length; j++)
                    {
                        Console.Write(expectedScrambleArray[j]);
                        Console.Write(" ");
                    }
                }

                expectedFilterArray = DFB[i].simpleFilter();
                Console.WriteLine();

                Console.Write("Filtered sequence " + (i + 1) + ": ");
                for (int j = 0; j < expectedFilterArray.Length; j++)
                {
                    Console.Write(expectedFilterArray[j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
                Console.WriteLine();

            }

            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataCut and Beacon combined");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                if (i == TEST_ITERATION1)
                {
                    Console.WriteLine();
                    DFB[i].simpleScramble(testArray1);
                    Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray2));
                    Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                }


                else if (i == TEST_ITERATION2)
                {
                    Console.WriteLine();
                    DFB[i].simpleScramble(testArray2);
                    Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray3));
                    Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION3)
                {
                    Console.WriteLine();
                    DFB[i].simpleScramble(testArray3);
                    Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray4));
                    Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION4)
                {
                    Console.WriteLine();
                    DFB[i].simpleScramble(testArray4);
                    Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray5));
                    Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                }


                if (i == TEST_ITERATION5)
                {
                    Console.WriteLine();
                    DFB[i].simpleScramble(testArray5);
                    Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray1));
                    Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                }

            }

            Console.WriteLine();
        }

        public static void dataCutStrobeBeaconTest()
        {

          
            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };

            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATAMOD_OR_STROBEBEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATAMOD_OR_STROBEBEACON, !DATAFILTERLARGEMODE);

                }
            }

           
            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataCut and StrobeBeacon combined");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                    if (i == TEST_ITERATION1)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray1);
                        Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray2));
                        Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                    }


                    else if (i == TEST_ITERATION2)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray2);
                        Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray3));
                        Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION3)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray3);
                        Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray4));
                        Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION4)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray4);
                        Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray5));
                        Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION5)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray5);
                        Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray1));
                        Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                    }


                

                Console.WriteLine();
            }

        }

        public static void dataCutQuirkyBeaconTest()
        {
            
            int[] testArray1 = new int[10] { -25, 18, 45, 226, 856, -3, 44, 21, 22, 900 };
            int[] testArray2 = new int[10] { 21, 23, 543, 34, 28, 1, 6, 200, 201, 198 };
            int[] testArray3 = new int[10] { 35, 15, 55, -55, 85, 92, 93, 94, 95, 12 };
            int[] testArray4 = new int[10] { 35, 15, 24, 1000, -1000, 999, -999, 28, 36, 5 };
            int[] testArray5 = new int[10] { 100, 50, 200, 150, 300, 350, 275, 957, 857, 999 };

            dataFilterBeaconComposition[] DFB = new dataFilterBeaconComposition[TEST_ITERATIONS];

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                if (i < MODE_CHANGE)
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATACUT_OR_QUIRKYBEACON, DATAFILTERLARGEMODE);
                }

                else
                {

                    DFB[i] = new dataFilterBeaconComposition(DATACUT_OR_QUIRKYBEACON, DATACUT_OR_QUIRKYBEACON, !DATAFILTERLARGEMODE);

                }
            }


            Console.WriteLine();
            Console.WriteLine("Now testing the functionality of dataCut and QuirkyBeacon combined");
            Console.WriteLine();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {

                    if (i == TEST_ITERATION1)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray1);
                        Console.WriteLine("Scrambled signal 1: " + DFB[i].EmitScrambledSignal(testArray2));
                        Console.WriteLine("Filtered signal 1: " + DFB[i].EmitFilteredSignal());
                    }


                    else if (i == TEST_ITERATION2)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray2);
                        Console.WriteLine("Scrambled signal 2: " + DFB[i].EmitScrambledSignal(testArray3));
                        Console.WriteLine("Filtered signal 2: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION3)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray3);
                        Console.WriteLine("Scrambled signal 3: " + DFB[i].EmitScrambledSignal(testArray4));
                        Console.WriteLine("Filtered signal 3: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION4)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray4);
                        Console.WriteLine("Scrambled signal 4: " + DFB[i].EmitScrambledSignal(testArray5));
                        Console.WriteLine("Filtered signal 4: " + DFB[i].EmitFilteredSignal());
                    }


                    if (i == TEST_ITERATION5)
                    {
                        Console.WriteLine();
                        DFB[i].simpleScramble(testArray5);
                        Console.WriteLine("Scrambled signal 5: " + DFB[i].EmitScrambledSignal(testArray1));
                        Console.WriteLine("Filtered signal 5: " + DFB[i].EmitFilteredSignal());
                    }



                }

            Console.WriteLine();


        }

    }


   
}
