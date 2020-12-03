// Kyle Fraser
// 10/11/2020
// Revision History:
// Drafted: 10/5/2020
// revised: 10/6/2020
// revised: 10/7/2020
// revised: 10/8/2020
// revised: 10/9/2020
// revised: 10/10/2020
// revised: 10/11/2020
// revised: 11/6/2020
// revised: 11/7/2020


// Interface Invariants
//----------------------------------------------------------------------------------------------------------------------------------------------------

// Arrays returned from filter will have 1 less elements than the array sent into scramble.

// Arrays returned from scramble will be of variable size, depending on the next scramble call. 

// Deep copying is not supported. 

// The filter function will delete either the maximum or minimum number in the sequence. Then normal filter 
// functionality is applied. 

// The scramble function will delete all numbers that occurred in the previous scramble request. Then normal 
// filter functionality is applied. 


// Class Invariants
//-----------------------------------------------------------------------------------------------------------------------------------------------------

// The filter function will delete either the maximum or minimum number in the sequence. Then normal 
// filter functionality is applied. 

// The scramble function will delete all numbers that occurred in the previous scramble request. Then
// normal scramble functionality is applied. 

// Deep copying not supported

using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{
    public class dataCut : dataFilter
    {

        private int newSize;
        

        // Pre: None
        // Post: Object constructed; Data members initialized. 
        public dataCut(bool userModeSet) : base(userModeSet)
        {

            newSize = 0;
            

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
                    for (int j = 0; j < sequenceSize; j++)
                    {
                        if (sequence[j] > prime)
                        {
                            constructListLargeMode++;
                        }

                    }

                    Array.Resize(ref filterArray, constructListLargeMode);
                    constructListLargeMode = 0;

                    for (int j = 0; j < sequenceSize; j++)
                    {

                        if (sequence[j] > prime)
                        {

                            filterArray[constructListLargeMode] = sequence[j];
                            constructListLargeMode++;

                        }

                    }

                    


                    
                    int max = findMax(filterArray);
                    
                    for(int i = 0; i < constructListLargeMode; i++)
                    {

                        if(filterArray[i] == max)
                        {

                            
                            swap(ref filterArray[i], ref filterArray[constructListLargeMode - 1]);
                            constructListLargeMode--;
                            Array.Resize(ref filterArray, constructListLargeMode);


                        }

                        

                    }


                }


                else
                {


                    int constructListSmallMode = 0;

                    for (int j = 0; j < sequenceSize; j++)
                    {
                        if (sequence[j] < prime)
                        {

                            constructListSmallMode++;
                        }
                    }


                    
                    Array.Resize(ref filterArray, constructListSmallMode);
                    constructListSmallMode = 0;

                    for (int j = 0; j < sequenceSize; j++)
                    {

                        if (sequence[j] < prime)
                        {

                            filterArray[constructListSmallMode] = sequence[j];
                            constructListSmallMode++;


                        }
                    }

                    

                  
                    int min = findMin(filterArray);
                    
                    for(int i = 0; i < constructListSmallMode; i++)
                    {

                        if (filterArray[i] == min)
                        {
                           
                            swap(ref filterArray[i], ref filterArray[constructListSmallMode - 1]);
                            constructListSmallMode--;
                            Array.Resize(ref filterArray, constructListSmallMode);

                        }


                    }

                }

                return filterArray;

            }


        }



        // Pre: None
        // Post: Internal sequence is initialized 
        public override int[] scramble(int[] seq)
        {

            sequenceSize = seq.Length;
            newSize = sequenceSize;
            scrambleArray = new int[sequenceSize];
            sequence = new int[sequenceSize];

            for (int i = 0; i < sequenceSize; i++)
            {
                scrambleArray[i] = seq[i];
                sequence[i] = seq[i];

            }

            if (noPrevious)
            {

                previousScramble = new int[sequenceSize];
                for (int i = 0; i < sequenceSize; i++)
                {

                    previousScramble[i] = sequence[i];
                }

                noPrevious = false;

            }

            else
            {
                // i < newSize?
                // scrambleArray.length
                for (int i = 0; i < previousScramble.Length; i++)

                {

                    
                   for (int j = 0; j < scrambleArray.Length; j++) { 


                        if (scrambleArray[j] == previousScramble[i])
                        {
                            
                            swap(ref scrambleArray[j], ref scrambleArray[newSize - 1]);
                            newSize--;
                            Array.Resize(ref scrambleArray, newSize);
                           
                        }

                    }

                }


               

            }


            if (large)
            {

                if (newSize % 2 != 0)
                {

                    for (int i = 0; i < (newSize + 1) / 2; i++)
                    {

                        if (i == newSize - i - 1)
                        {

                            if (scrambleArray[i] < scrambleArray[newSize - 1])
                            {

                                swap(ref scrambleArray[i], ref scrambleArray[newSize - 1]);
                            }
                        }

                        if (scrambleArray[i] < scrambleArray[newSize - i - 1])
                        {


                            swap(ref scrambleArray[i], ref scrambleArray[newSize - i - 1]);


                        }

                    }


                }

                else
                {
                    for (int i = 0; i < (newSize / 2); i++)
                    {

                        if (scrambleArray[i] < scrambleArray[newSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[newSize - i - 1]);


                        }

                    }

                }




            }

            else
            {

                if (newSize % 2 != 0)
                {

                    for (int i = 0; i < (newSize + 1) / 2; i++)
                    {


                        if (i == newSize - i - 1)
                        {

                            if (scrambleArray[i] < scrambleArray[0])
                            {

                                swap(ref scrambleArray[i], ref scrambleArray[0]);
                            }
                        }

                        if (scrambleArray[i] > scrambleArray[newSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[newSize - i - 1]);

                        }


                    }

                }

                else
                {
                    for (int i = 0; i < newSize / 2; i++)
                    {

                        if (scrambleArray[i] > scrambleArray[newSize - i - 1])
                        {

                            swap(ref scrambleArray[i], ref scrambleArray[newSize - i - 1]);

                        }

                    }
                }

            }


            Array.Resize(ref previousScramble, newSize);
            for (int i = 0; i < newSize; i++)
            {

                previousScramble[i] = scrambleArray[i];

            }

            noPrevious = false;
            return scrambleArray;
        }

        // Pre: None
        // Post: None
        private int findMax(int[] findMaxOfThis)
        {
            int maxNumber;
            if (findMaxOfThis.Length > 0)
            {
                maxNumber = findMaxOfThis[0];
            }
            else
            {
                maxNumber = 0;  // = findMaxOfThis
            }
            for (int i = 0; i < findMaxOfThis.Length; i++)
            {
                if (findMaxOfThis[i] > maxNumber)
                {

                    maxNumber = findMaxOfThis[i];

                }


            }

            return maxNumber;

        }

        // Pre: None
        // Post: None
        private int findMin(int[] findMinOfThis)
        {
           

            int minNumber;
            if (findMinOfThis.Length > 0)
            {
                minNumber = findMinOfThis[0];
            }
            else
            {
                minNumber = 0;  // = findMaxOfThis
            }

            for (int i = 0; i < findMinOfThis.Length; i++)
            {
                if (findMinOfThis[i] < minNumber)
                {

                    minNumber = findMinOfThis[i];

                }

            }

            return minNumber;
        }


    }
}



// Implementation invariants
//-----------------------------------------------------------------------------------


// Find minimum and find maximum functions are used to find the minimum and 
// maximum integers in a sequences. 

// An Array is used to store the encapsulated the sequence.
// An array is used as a copy of the encapsulated sequence so that it may be
// returned to the user. 

// array function library used for resize. 

// The filter function deletes either the maximum number in a sequence, or 
// the minimum number in a sequence. Then applies normal parent filter functionality. 


// The scramble function deletes all numbers from the sequence that occured in the 
// previous scramble request. Then applies normal parent scramble functionality.


// Deep copying is not supported.














