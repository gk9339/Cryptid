datablock StaticShapeData (cellarDoor)
{
   shapeFile = "./DUMMYcellardoorNOANIM.cached.dts";
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
      scale = "0.05 0.0575 0.0505";
      rotation = "0 0 1 -90";
      dataBlock = cellarDoor;
   };
   %Obj = new Trigger()
   {
      position = "10.4507 43.9171 8.65399";
      scale = "1 1 1";
      rotation = "0 0 0 0";
      dataBlock = cellarDoorTrigger;
      polyhedron = "0.0000000 0.0000000 0.0000000 2.0000000 0.0000000 0.0000000 0.0000000 -2.0000000 0.0000000 0.0000000 0.0000000 2.0000000";
      doorID = %doorObj;
   };
}

function openDoor(%id)
{
   %id.playThread(0, "open");
}
function closeDoor(%id)
{
   %id.playThread(0, "ambient");
}
function doorTrigger::onEnterTrigger(%trigger, %this, %obj)
{
   echo ("triggered");
   openDoor(%this.doorID);
}
function doorTrigger::onLeaveTrigger(%trigger, %this, %obj)
{
   closeDoor(%this.doorID);
}