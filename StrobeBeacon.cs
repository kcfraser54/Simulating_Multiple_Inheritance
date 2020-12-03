// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/5/2020
// Revised: 11/6/2020
// Revised: 11/7/2020
// Revised: 11/8/2020


// Interface Invariants
//-----------------------------------------------

// Functions the same as beacon, except signal size will 
// oscilate from high to low. If the previous signal was low, then 
// the next signal will be high.

// A strobeBeacon begins in high mode. 

// Size of signal is still contingent on the client input.  

// A strobeBeacon may not be recharged. 


// Class Invariants
//-----------------------------------------------

// Functions the same as beacon, except signal size will 
// oscillate from high to low. If the previous signal was low, then the next signal will 
// be high. 

// A strobeBeacon may not be recharged. 

// Size of signal still contingent on client input 

// A strobeBeacon begins in high mode. 


using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{
   public class StrobeBeacon : Beacon
    {
        bool high;


        // Pre: None
        // Post: A StrobeBeacon object and its data members are instantiated. 
        public StrobeBeacon() : base()
        {


            high = true;

        }


        // Pre: None
        // Post: None
        public override void recharge() { }


        // Pre: signalSize must hold the relevent signalSize computed from client input. 
        // Post: Charge may be depleted. The charge may decrease.
        // The beacon may be turned off. 
        // The StrobeBeacon will oscillate to high or low mode. Signal size will be changed. 
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

                if (high)
                {

                    for (int i = 0; i < signalSize * SIGNAL_COMPUTATION_NUM1; i++)
                    {

                        signal += SIGNAL_OUTPUT;

                    }

                    high = false;

                }

                else
                {

                    for (int i = 0; i < signalSize / SIGNAL_COMPUTATION_NUM1; i++)
                    {

                        signal += SIGNAL_OUTPUT;

                    }

                    high = true;

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



    }
}


// Implementation Invariants
//---------------------------------------------------------------

// A bool variable is used to oscillate back and forth between high and low mode. 

// A signal size is doubled in high mode and halved in low mode. 

// Recharge function from parent is overriden so that is provides no functionality and therefore does
// not recharge the beacon.

// emitSignal function from parent is overriden so that the signal size may be changed depending on high or 
// low mode. 



