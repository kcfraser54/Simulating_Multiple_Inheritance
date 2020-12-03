// Kyle Fraser
// 11/9/2020
// Revision History: 
// Drafted: 11/6/2020
// Revised: 11/7/2020
// Revised: 11/8/2020
// Revised: 11/9/2020


// Interface Invariants
//-----------------------------------------------

// Deep Copying is not supported.

// This object uses 1 of any type of dataFilter and 
// 1 of any type of beacon. 

// Client is responsible for specifying the type of dataFilter and the type 
// of beacon in use.

// May be used like a beacon object.

// May be used like a dataFilter object. 

// May generate a filtered signal using any combination of dataFilter and beacon 
// objects. 

// May generate a scrambled signal using any combination of datafilter and beacon. 

// Class Invariants
//------------------------------------------------

// Deep Copying is not supported.

// whoAmI functions used to differentiate betweeen which dataFilter and 
// which beacon is in use.

// constructor injection is used to instantiate dataFilter type, beacon type, and 
// mode for the dataFilter. 

// A dataFilter functions like a dataFilter, a beacon functions like a beacon, and 
// and a dataFilter and beacon may be used together. 


using System;
using System.Collections.Generic;
using System.Text;

namespace P5
{
   public class dataFilterBeaconComposition
   {

        dataFilter DFComposite;
        Beacon BComposite;
        bool large;

        // Pre: None
        // Post: Object and data members are instantiated. This includes 
        // any combination of dataFilter and Beacon. 
        public dataFilterBeaconComposition(int chooseDF, int chooseB, bool userModeSet)
        {
            whoAmIDataFilter(chooseDF, userModeSet);
            whoAmIBeacon(chooseB);
        }


        // Pre: None
        // Post: A dataFilter object will be instantiated. 
        public void whoAmIDataFilter(int DFType, bool mode)
        {

            large = mode;

            if (DFType == 1)
            {
                DFComposite = new dataFilter(large);
            }

            else if (DFType == 2)
            {
                DFComposite = new dataMod(large);
            }

            else if(DFType == 3)
            {
                DFComposite = new dataCut(large);
            }

        }

        // Pre: None
        // Post: A beacon object will be instantiated.
        private void whoAmIBeacon(int BType)
        {
            if(BType == 1)
            {
                BComposite = new Beacon();

            }

            else if(BType == 2)
            {
                BComposite = new StrobeBeacon();

            }

            else if(BType == 3)
            {

                BComposite = new QuirkyBeacon();

            }

        }

        // Pre: None
        // Post: None
        public int[] simpleFilter() 
        {
            return DFComposite.filter();
        }

        // Pre: None
        // Post: Internal sequence in dataFilter will be changed. 
        public int[] simpleScramble(int [] userSequence) 
        {
            return DFComposite.scramble(userSequence);
        }


        // Pre: None
        // Post: Internal sequence inside of Beacon will be changed. 
        public void inputSignal(int [] signalInput)  
        {
            BComposite.giveSignalInput(signalInput);
        }


        // Pre: None
        // Post: None
        public string SimpleEmitSignal()  
        {
            return BComposite.emitSignal();
        }

        // Pre: None
        // Post: None
        public string EmitFilteredSignal()
        {
            BComposite.giveSignalInput(DFComposite.filter());
            return BComposite.emitSignal();
        }


        // Pre: None 
        // Post: Internal sequence in dataFilter will be changed. 
        public string EmitScrambledSignal(int [] userSequence)
        {
            BComposite.giveSignalInput(DFComposite.scramble(userSequence));
            return BComposite.emitSignal();
        }


        // Pre: None
        // Post: Beacon may be fully charged and turned on. 
        public void beaconRecharge()
        {
            BComposite.recharge();

        }

        // Pre: None
        // Post: Beacon may be turned on.
        public void beaconTurnOn()
        {
            BComposite.turnOn();

        }

        // Pre: None
        // Post: Datafilter mode is changed. 
        public void dataFilterChangeMode(bool UserModeSet)
        {
            large = UserModeSet;
            DFComposite.changeMode(large);

        }

   }
}


// Implementation Invariant
//---------------------------------------------------------------------

// constructor injection is used to specify the specific dataFilter, beacon, and 
// mode for the dataFilter. 

// Functions in this class echo the interface required for the dataFilter and 
// beacon in use. 

// whoAmI functions allow specification of type.  

// All objects work the same as their corresponding dataFilter and beacon.

// Method injection used to specify the sequence to send to dataFilter or 
// the sequence sent to beacon. 

// The sequence sent to dataFilter may be scrambled and then processed through 
// beacon to emit a scrambled signal. 

// The sequence sent to dataFilter may be filtered and then processed through 
// beacon to emit a filtered signal. 