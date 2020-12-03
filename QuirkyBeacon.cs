// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/5/2020
// Revised: 11/6/2020
// Revised: 11/7/2020
// Revised: 11/8/2020


// Interface Invariants
//-----------------------------------------------

// Functions the same as a beacon, except signals emitted are not 
// highly correlated to the clients input. Therefore, a there is
// no obvious patter to signal size. 

// A beacon may only be turned on 3 times. 

// After 3 turn on attempts, the beacon may not be turned on again. 


// Class Invariants
//-----------------------------------------------

// Functions the same as a beacon, except signals emitted are not 
// highly correlated to the clients input. Therefore, a there is
// no obvious patter to signal size. 

// A beacon may only be turned on 3 times. 

// After 3 turn on attempts, the beacon may not be turned on again. 


using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{


   public class QuirkyBeacon : Beacon
    {

        private const int TURN_ON_LIMIT = 3;
        private const int SIGNAL_COMPUTATION_NUM2 = 50;
        private const int SIGNAL_COMPUTATION_NUM3 = 7;
        private const int SIGNAL_COMPUTATION_NUM4 = 8;
        private const int SIGNAL_COMPUTATION_NUM5 = 13;
        private const int SIGNAL_COMPUTATION_NUM6 = 4;
        

        int turnOnAttempt;

        // Pre: None
        // Post: Object and data members are initialized. 
        public QuirkyBeacon() : base()
        {
            turnOnAttempt = 0;

        }

        // Pre: Signal Size must be initialized. 
        // Post: Charge may decrease or be depleted. 
        // The quirkybeacon may be turned off. Signal size will be changed. 
        public override string emitSignal()
        {
            signal = "";


            if (on && charge > 0)
            {
                charge -= signalSize;
                if (charge <= 0)
                {
                    on = false;
                }

                signalSize = varySignal(signalSize);

                for (int i = 0; i < signalSize; i++)
                {

                    signal += SIGNAL_OUTPUT;

                }

            }

            else if (on && charge <= 0)
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
        // Post: quirkyBeacon may be turned off.
        // quirkyBeacon may be turned on. 
        public override void turnOn()
        {

            if (on || turnOnAttempt >= TURN_ON_LIMIT)
            {
                on = false;
            }
            else
            {
                on = true;
                turnOnAttempt++;
            }
        }


        // Pre: None
        // Post: None 
        private int varySignal(int signalSize)
        {
            if(signalSize % SIGNAL_COMPUTATION_NUM1 == 0)
            {

                return ((signalSize * SIGNAL_COMPUTATION_NUM2) + signalSize) % SIGNAL_COMPUTATION_NUM3 * SIGNAL_COMPUTATION_NUM4;

            }

            else
            {

                return ((signalSize * SIGNAL_COMPUTATION_NUM2) - signalSize) % SIGNAL_COMPUTATION_NUM5 * SIGNAL_COMPUTATION_NUM6;
            }



        }


    }
}


// Implementation Invariant
//-------------------------------------------------------------------------------

// The private varySignal method is used to differently compute odd and even signalSizes.

// varySignal provides a method to compute a signal size where the signal size is not evident 
// based on the client input. 

// Signal size is contingent on the client input and the varySignal function used for computation. 

// The beacon may not be turned on after the client succesfully turns the beacon on 3 times. 

