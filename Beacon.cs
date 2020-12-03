// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/5/2020
// Revised: 11/6/2020
// Revised: 11/7/2020
// Revised: 11/8/2020


// Interface Invariants
//-----------------------------------------------

// Deep copying is not supported. 

// A beacon may be recharged.

// When recharged, beacon will be fully charged.

// For recharge to be succesfull, the beacon must have no charge. 

// A beacon may be turned on after it has been turned off. 

// A beacon will be turned off if an empty sequence is sent as 
// signal input.

// beacon will turn off when the charge is depleted. 

// If the beacon is on and the client turns on the beacon, the beacon 
// is turned off. 

// Beacon is initially on and fully charged. 

// The signal returned is represented by a string. 

// "WuB" represents a single unit of signal strength. 

// The size of the signal determines how much charge is drained from the beacon.

// A beacon must be on and charged to emit a signal. 

// A beacon's charge may be drained after it emits a single signal. 

// Returns "0" if the beacon is not on and the client attempts to emit a signal 

// Returns "-1" is the beacon is on but not charged and the client attempts to emit a signal. 


// Class Invariants
//-----------------------------------------------

// Deep Copying is not supported 

// beacon have no charge to be succesfully recharged.

// When recharged, the beacon will be fully charged. 

// Beacon is initially on and fully charged.

// A beacon may be turned on only if it has been turned off. A beacon is turned 
// off if the client attempts to turn on a beacon that is already on. 

// A beacon is turned off if an empty sequence is sent as input, the beacon's charge is 
// depleted, or the client attempts to turn on a beacon that is already on.

// The signal returned is represented by a string. 

// The size of the signal determines how much charge is drained from the beacon.

// A beacon must be on and charged to emit a signal. 

// charge may only be drained from a beacon that is on and charged. 

// "WuB" represents a single unit of signal strength. 

// Returns "0" if the beacon is not on and the client attempts to emit a signal 

// Returns "-1" is the beacon is on but not charged and the client attempts to emit a signal. 

// emitSignal, turnOn, and recharge functions declared virtual so that they may be overrided by 
// child classes. 

using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{

   public class Beacon
    {


        protected const int STARTING_CHARGE = 100;
        protected const int SIGNAL_COMPUTATION_NUM1 = 2;
        protected const string SIGNAL_OUTPUT = "WuB";
        protected int charge;
        protected bool on;
        protected int[] input;
        protected int inputSize;
        protected int signalSize;
        protected string signal;


        // Pre: None
        // Post: Object and data members instantiated.
        public Beacon()
        {

            charge = STARTING_CHARGE;
            on = true;
            signalSize = 0;
            signal = "";
            inputSize = 0;
            
        }

        // Pre: None 
        // Post: Internal Sequence and signal size are initialized. The 
        // beacon may be turned off. 
        public void giveSignalInput(int[] userInput)   
        {

            inputSize = userInput.Length;
            input = new int[inputSize];
            if(inputSize == 0)
            {

                on = false;
            }
            else
            {

                signalSize = inputSize;
                for (int i = 0; i < inputSize; i++)
                {
                    input[i] = userInput[i];
                    signalSize += (input[i] % SIGNAL_COMPUTATION_NUM1);

                }

            }
        }


        // Pre: signalSize must hold relevent signal size computed from client input. 
        // Post: The charge may be depleted and the 
        // beacon may be turned off. Charge may decrease. 
        public virtual string emitSignal()
        {
            signal = "";
            
            
            if(on && charge > 0)
            {
                charge -= signalSize;
                if(charge <= 0)
                {
                    on = false; 
                }

                for(int i = 0; i < signalSize; i++)
                {

                    signal += SIGNAL_OUTPUT;

                }

            }

            else if(on && charge <= 0)
            {
                signal += "-1";

            }

            else
            {
                signal += "0";
            }


            return signal;
        }


        // Pre: None
        // Post: The beacon is either turned on or turned off. 
        public virtual void turnOn()
        {
            if (on)
            {
                on = false;
            }
            else
            {
                on = true;
            }

        }

        // Pre: None
        // Post: The beacon may be fully charged and 
        // may be turned on. 
        public virtual void recharge()
        {
            if (on && charge <= 0)
            {
                charge = STARTING_CHARGE;
                on = true;
            }

        }

    }
}


// Implementation Invariant
//---------------------------------------------------------------

// Deep copying not supported 

// Charge is represented by an integer beginning at 100.

// Decreases each time a signal is emmitted.

// Decrease in charge is directly associated with the size of the signal.

// The object is intially on and fully charged. 

// public setter functions are used for recharge, turnOn, and giveSignalInput

// Method injection is used to set the signal input sequence. 

// An array is used to encapsulated the sequence. 

// The signal size is equal to the length of the sequence added. Then the sum of (i % 2) is 
// added to the signal size. i is each individual element in the sequence. The signal size then 
// determines the strength of the signal emmited to the user. 

// The signal is returned to the user in the form of a string. 

// An integer signalSize is negated from charge to decrease the charge every time a signal is emitted. 

// The charge may only be drained from a beacon that is on and charged. 

// The amount of charge will not impact the strength of the signal that the beacon emits. 

// Signal Strength represented using the contatenation of differing numbers of the string "WuB"

// "WuB" represents a single unit of signal strength. 

// emitSignal, turnOn, and recharge functions declared virtual so that they may be overrided by 
// child classes. 