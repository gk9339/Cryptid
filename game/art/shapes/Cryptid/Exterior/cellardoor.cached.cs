//-----------------------------------------------------------------------------
// Copyright (c) 2013 TGL
//----------------------------------------------------------------------------
import"../../../datablocks/cellardoor.cs";
echo ("Cellar Entrance Door");

//This is a method called by t3d which makes baseShape for the cellardoor
singleton TSShapeConstructor(DUMMYcellardoorNOANIM_cachedDts)
{
   baseShape = "./DUMMYcellardoorNOANIM.cached.dts";
};

//This is a method called by t3d which sets animation sequences(from internal
//or external files)
function DUMMYcellardoorNOANIM_cachedDts::onLoad(%this)
{
   %this.addSequence("./DUMMYcellardoor.dae", "Open", "0", "-1", "1", "0");
}

//This is the datablock for the cellardoor, and is obselete as the datablock 
//is now in art/datablocks/cellardoor.cs
//datablock StaticShapeData (cellarDoor)
//{
//   shapeFile = "./DUMMYcellardoorNOANIM.cached.dts";
//   Unopened = true;
//   
//};

//This is the datablock for the trigger, obselete for the same reason
//datablock TriggerData(cellarDoorTrigger)
//{
//   tickPeriodMS = 1000;
//};

//This function adds the staticShape object into the world and adds the trigger
//into the world and gives them pos scale and rot
function addCellarDoor()
{
   %doorObj = new StaticShape()
   {
      position = "10.4507 43.9171 8.65399";
      scale = "1 1 1";
      rotation = "0 0 1 -90";
      dataBlock = cellarDoor;
   };
   %Obj = new Trigger()
   {
      position = "8.85762 47.0466 7.31838";
      scale = "2.48964 3.17406 2";
      rotation = "1 0 0 0";
      dataBlock = cellarDoorTrigger;
      polyhedron = "0.0000000 0.0000000 0.0000000 2.0000000 0.0000000 0.0000000 0.0000000 -2.0000000 0.0000000 0.0000000 0.0000000 2.0000000";
      doorID = %doorObj;
   };
}

//This function makes the cellarDoor object play the "open" animation
function openDoor(%id)
{
   if (cellarDoor.Unopened == true)
   {
      %id.playThread(0, "open");
      cellarDoor.Unopened = false;
   }
}

//This would make the door play a close animation but there is none
function closeDoor(%id)
{
   //%id.playThread(0, "ambient");
}

//This is the function called on entry to the cellardoortrigger and calls
//opendoor
function cellarDoorTrigger::onEnterTrigger(%trigger, %this, %obj)
{
   openDoor(%this.doorID);
}

//This is the function called on leaving the cellardoortrigger and calls
//closedoor
function cellarDoorTrigger::onLeaveTrigger(%trigger, %this, %obj)
{
   closeDoor(%this.doorID);
}
