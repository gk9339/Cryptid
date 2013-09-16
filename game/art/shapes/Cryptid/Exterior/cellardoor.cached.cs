//-----------------------------------------------------------------------------
// Copyright (c) 2013 TGL
//----------------------------------------------------------------------------
echo ("Cellar Entrance Door");

singleton TSShapeConstructor(DUMMYcellardoorNOANIM_cachedDts)
{
   baseShape = "./DUMMYcellardoorNOANIM.cached.dts";
};

function DUMMYcellardoorNOANIM_cachedDts::onLoad(%this)
{
   %this.addSequence("./DUMMYcellardoor.dae", "Open", "0", "-1", "1", "0");
}

datablock StaticShapeData (cellarDoor)
{
   shapeFile = "./DUMMYcellardoorNOANIM.cached.dts";
   Unopened = true;
   
};

datablock TriggerData(cellarDoorTrigger)
{
   tickPeriodMS = 1000;
};

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
function openDoor(%id)
{
   if (cellarDoor.Unopened == true)
   {
      %id.playThread(0, "open");
      cellarDoor.Unopened = false;
   }
}
function closeDoor(%id)
{
   //%id.playThread(0, "ambient");
}
function cellarDoorTrigger::onEnterTrigger(%trigger, %this, %obj)
{
   openDoor(%this.doorID);
}
function cellarDoorTrigger::onLeaveTrigger(%trigger, %this, %obj)
{
   closeDoor(%this.doorID);
}
