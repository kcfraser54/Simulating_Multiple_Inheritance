// Kyle Fraser
// 10/11/2020
// Revision History:
// Drafted: 10/5/2020
// Revised: 10/6/2020
// Revised: 10/7/2020
// Revised: 10/8/2020
// Revised: 10/9/2020
// Revised  10/10/2020
// Revised  10/11/2020
// Revised  11/6/2020
// Revised  11/7/2020



// Interface invariants
//---------------------------------------------------------------------

// The internal sequence will not be altered unless a new sequence is given to scramble.

// When filter is called, each integer in the sequence will be incremented in large mode and 
// decremented in small mode. Then parent filter function is applied. 

// When scramble is called, each prime integer in the sequence will be set to 2. After this, parent
// scramble functionality will be provided. 

// deep copying is not supported. 

// User may change the mode

// Class invariants
//--------------------------------------------------------------------------------------------------------

// Deep copying is not supported 

// When filter is called, each integer in the sequence will be incremented in large mode, and decremented
// in small mode. Then parent filter is applied. 

// When scramble is called, each prime integer in the sequence is set to 2. Then parent scramble function is 
// applied. 


using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{


    public class dataMod : dataFilter
    {




        private const int PRIME_CHANGE = 2;

        // Pre: None
        // Post: Parent Object constructed, Child Object constructed 
        public dataMod(bool userModeSet) : base(userModeSet)
        {




        }

        // Pre: None
        // Post: None
        public override int[] filter()
        {

            if (sequence == null)
            {
                return nullSequence;
            }

            else
            {


                filterArray = new int[sequenceSize];

                for (int i = 0; i < sequenceSize; i++)
                {

                    filterArray[i] = sequence[i];
                }


                if (large)
                {

                    int constructListLargeMode = 0;
                    for (int i = 0; i < sequenceSize; i++)
                    {
                        if (sequence[i] > prime)
                        {
                            constructListLargeMode++;
                        }

                    }

                    filterArray = new int[constructListLargeMode];
                    constructListLargeMode = 0;

                    for (int i = 0; i < sequenceSize; i++)
                    {

                        if (sequence[i] > prime)
                        {

                            filterArray[constructListLargeMode] = sequence[i]++;
                            constructListLargeMode++;

                        }

                    }


                }

                else
                {
                    int constructListSmallMode = 0;

                    for (int i = 0; i < sequenceSize; i++)
                    {
                        if (sequence[i] < prime)
                        {

                            constructListSmallMode++;
                        }
                    }


                    filterArray = new int[constructListSmallMode];
                    constructListSmallMode = 0;

                    for (int i = 0; i < sequenceSize; i++)
                    {

                        if (sequence[i] < prime)
                        {

                            filterArray[constructListSmallMode] = sequence[i]--;
                            constructListSmallMode++;


                        }
                    }

                }

                return filterArray;

            }

        }

        // Pre: None
        // Post: Initializes the internal sequence 
        public override int[] scramble(int[] seq)
        {


            sequenceSize = seq.Length;
            scrambleArray = new int[sequenceSize];
            sequence = new int[sequenceSize];

            for (int i = 0; i < sequenceSize; i++)
            {
                scrambleArray[i] = seq[i];
                sequence[i] = seq[i];
            }


            for (int i = 0; i < sequenceSize; i++)
            {

                if (isThisPrime(scrambleArray[i]))
                {

                    scrambleArray[i] = PRIME_CHANGE;

                }

            }


            if (large)
            {

                if (sequenceSize % 2 != 0)
                {

                    for (int i = 0; i < (sequenceSize + 1) / 2; i++)
                    {

                        if (i == sequenceSize - i - 1)
                        {

                            if (scrambleArray[i] < scrambleArray[sequenceSize - 1])
                            {

                                swap(ref scrambleArray[i], ref scrambleArray[sequenceSize - 1]);
                            }
                        }

                        if (scrambleArray[i] < scrambleArray[sequenceSize - i - 1])
                        {


                            swap(ref scrambleArray[i], ref scrambleArray[sequenceSize - i - 1]);


                        }

                    }


                }

                else
                {
                    for (int i = 0; i < (sequenceSize / 2); i++)
                    {

                        if (scrambleArray[i] < scrambleArray[sequenceSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[sequenceSize - i - 1]);


                        }

                    }

                }




            }

            else
            {

                if (sequenceSize % 2 != 0)
                {

                    for (int i = 0; i < (sequenceSize + 1) / 2; i++)
                    {


                        if (i == sequenceSize - i - 1)
                        {

                            if (scrambleArray[i] < scrambleArray[0])
                            {

                                swap(ref scrambleArray[i], ref scrambleArray[0]);
                            }
                        }

                        if (scrambleArray[i] > scrambleArray[sequenceSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[sequenceSize - i - 1]);

                        }


                    }




                }

                else
                {
                    for (int i = 0; i < sequenceSize / 2; i++)
                    {

                        if (scrambleArray[i] > scrambleArray[sequenceSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[sequenceSize - i - 1]);


                        }

                    }
                }

            }

            previousScramble = new int[sequenceSize];
            for (int i = 0; i < sequenceSize; i++)
            {

                previousScramble[i] = scrambleArray[i];

            }

            noPrevious = false;




            return scrambleArray;

        }

    }
}


// implementation invariants
//------------------------------------------------------------------------------------------------

// Arrays used to copy, return, and maintain the correct array in the class.

// The filter function overrides the parent object filter.

// the scramble function overrides the parent object scramble. 





