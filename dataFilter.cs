// kyle Fraser
// 10/11/2020
// Revision History:
// Drafted: 10/4/2020
// Revised: 10/5/2020
//          10/6/2020
//          10/7/2020
//          10/8/2020
//          10/9/2020
//          10/10/2020
//          11/6/2020
//          11/7/2020


// Interface invariants
//----------------------------------------------------------------------------------------------------------------

// If an array is not sent to the class through scramble, then a single prime number will be returned to the user. 
// Uses functional dependency so that the integer sequence may be reset. 

// Any size array may be used.  


// Uses constructor injection so that the user may specify mode. 

// User may change the mode. 
 
// the sequence returned from the filter will be of variable size and always smaller
// than the sequence array. 

// The sequence used for filter and scramble will not change internally. If a 
// new sequence is not entered, the sequence returned will not change if a 
// scramble or filter has already occured. 

// deep copying is not supported.

// Class invariants
//------------------------------------------------------------------------------------------------------------------

// Deep copying not supported.

// The Sequence returned from filter is of variable size

// The sequence returned from filter will be smaller than or equal to the original array 

// the encapsulated prime number is set when the object is constructed 

//  Arrays were implemented to encapsulate the sequence and copy and return a new sequence. 

// Method injection implemented so that datamembers may be reset. 

// Functions are non-destructive for the internal sequence.


using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{
    public class dataFilter
    {


        protected const int MAX_LIST_SIZE = 500;

        protected bool large;

        protected int[] sequence;
        protected int[] filterArray;
        protected int[] scrambleArray;
        protected int[] previousScramble;

        protected int sequenceSize;

        protected int prime;
        protected bool noPrevious;

        protected int[] nullSequence = new int[1];

        // Pre: None
        // Post: Class data members are initialized, the encapsulated prime number is set, and the mode is set.
        public dataFilter(bool userModeSet)
        {


            large = userModeSet;
            noPrevious = true;
            sequenceSize = 0;
            prime = setPrime();
            nullSequence[0] = prime;

        }


        // Pre: None
        // Post: None
        public virtual int[] filter()
        {


            if (sequence == null)
            {

                return nullSequence;

            }


            else
            {
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

                            filterArray[constructListLargeMode] = sequence[i];
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

                            filterArray[constructListSmallMode] = sequence[i];
                            constructListSmallMode++;


                        }
                    }




                }

                return filterArray;

            }
        }
        // Pre: None
        // Post: Internal sequence is initialized. 
        public virtual int[] scramble(int[] seq)
        {

            sequenceSize = seq.Length;
            scrambleArray = new int[sequenceSize];
            sequence = new int[sequenceSize];



            for (int i = 0; i < sequenceSize; i++)
            {
                scrambleArray[i] = seq[i];
                sequence[i] = seq[i];
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
        // Pre: None
        // Post: None
        private int findHighPrime(int possiblePrime)
        {

            int findPrime = possiblePrime;
            bool primeNumberCheck = isThisPrime(findPrime);

            while (!primeNumberCheck)
            {


                findPrime++;
                primeNumberCheck = isThisPrime(findPrime);


            }



            return findPrime;

        }

        // Pre: None
        // Post: None
        protected bool isThisPrime(int numberToCheck)
        {

            int currentNumber = 2;
            int factors = 0;

            int numberFirstHalf = numberToCheck / 2;

            while (currentNumber <= numberFirstHalf)
            {
                if (factors < 1)
                {

                    if (numberToCheck % currentNumber == 0)
                    {
                        factors++;

                    }

                }
                currentNumber++;
            }


            return factors < 1;
        }



        // Pre: None
        // Post: Encapsulated prime number is set. 
        private int setPrime()
        {

            Random r = new Random();

            return findHighPrime(r.Next(1, MAX_LIST_SIZE));
        }


        protected void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;

        }

        // Pre: None
        // Post: The mode is changed.
        public void changeMode(bool userModeSet)
        {
            large = userModeSet;

        }

    }


}


// Implementation Invariants
//---------------------------------------------------------------------------------------------------

// When numbers are paired, the number at the beginning of the list may be swapped with the number at the end of the list.
// Then the start number is incremented and the end number decremented until all numbers are potentially swapped with pairs.

// An odd sequence pairs and potentially swaps all of the elements except the middle element in the sequence. This is 
// then paired with the first or last element in the sequence depending on the mode. 

// The encapsulated prime is set when the objects is constructed. This number is the first prime greater than 
// a random number between 1 and 500. 

// Arrays were implemented to encapsulate the sequence and copy and return a new sequence. 

// The virtual filter function may be overridden by a child object. 

// the virtual scramble function may be overridden by a child object. 

// deep copying not supported 

// Protected variables are used to send the mode, max list size, sequence, an arrays needed for copying and returning to the user.
 
