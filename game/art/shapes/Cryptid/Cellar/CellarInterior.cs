
singleton TSShapeConstructor(CellarInteriorDae)
{
   baseShape = "./CellarInterior.dae";
};

function CellarInteriorDae::onLoad(%this)
{
   %this.renameSequence("ambient", "__backup__ambient_1");
   %this.addSequence("ambient", "Fall", "0", "25", "1", "0");
   %this.addSequence("__backup__ambient_1", "ambient", "0", "1", "1", "0");
   %this.setSequenceCyclic("ambient", "0");
   %this.removeSequence("__backup__ambient_1");
}
datablock StaticShapeData (cellarInterior)
{
   shapeFile = "./CellarInterior.dae";
   Unopened = true;
};

datablock TriggerData(cellarStairsTrigger)
{
   tickPeriodMS = 1000;
};

function addCellarInterior()
{
   %doorObj = new StaticShape()
   {
      position = "10.4507 43.9171 8.65399";
      scale = "1 1 1";
      rotation = "0 0 1 -90";
      dataBlock = cellarInterior;
      
   };
   %Obj = new Trigger()
   {
      position = "8.85762 47.0466 7.31838";
      scale = "2.48964 3.17406 2";
      rotation = "1 0 0 0";
      dataBlock = cellarStairsTrigger;
      polyhedron = "0.0000000 0.0000000 0.0000000 2.0000000 0.0000000 0.0000000 0.0000000 -2.0000000 0.0000000 0.0000000 0.0000000 2.0000000";
      doorID = %doorObj;
   };
}
function openDoor(%id)
{
   echo ("Stair Fall activated");
   if (cellarInterior.Unopened == true)
   {
      echo ("animation activated");
      %id.playThread(0, "Fall");
      cellarDoor.Unopened = false;
   }
}
function closeDoor(%id)
{
   //%id.playThread(0, "ambient");
}
function cellarStairsTrigger::onEnterTrigger(%trigger, %this, %obj)
{
   openDoor(%this.doorID);
   echo ("Entered trigger");
}
function cellarStairsTrigger::onLeaveTrigger(%trigger, %this, %obj)
{
   closeDoor(%this.doorID);
   echo ("left trigger");
}