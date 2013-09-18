//-----------------------------------------------------------------------------
// Copyright (c) 2013 TGL
//----------------------------------------------------------------------------
import"../../../datablocks/cryptid/CellarInterior.cs";
echo ("Stairs Falling");

//This is a method called by t3d which makes baseShape for the cellarInterior
singleton TSShapeConstructor(CellarInterior_cachedDts)
{
   baseShape = "./CellarInterior.cached.dts";
};

//This is a method called by t3d which sets animation sequences(from internal
//or external files)
function CellarInterior_cachedDts::onLoad(%this)
{
   %this.addSequence("./CellarInterior.dae", "Fall", "0", "-1", "1", "0");
}


//This function adds the staticShape object into the world and adds the trigger
//into the world and gives them pos scale and rot
function addCellarInterior()
{
   %InteriorObj = new StaticShape()
   {
      position = "10.4507 43.9171 8.65399";
      scale = "1 1 1";
      rotation = "0 0 1 -90";
      dataBlock = ;
   };
   %Obj = new Trigger()
   {
      position = "8.85762 47.0466 7.31838";
      scale = "2.48964 3.17406 2";
      rotation = "1 0 0 0";
      dataBlock = cellarInteriorTrigger;
      polyhedron = "0.0000000 0.0000000 0.0000000 2.0000000 0.0000000 0.0000000 0.0000000 -2.0000000 0.0000000 0.0000000 0.0000000 2.0000000";
      InteriorID = %InteriorObj;
   };
}

//This function makes the cellarInterior object play the "open" animation
function openInterior(%id)
{
   if (cellarInterior.Unopened == true)
   {
      %id.playThread(0, "Fall");
      cellarInterior.Unopened = false;
   }
}

//This would make the Interior play a close animation but there is none
function closeInterior(%id)
{
   //%id.playThread(0, "ambient");
}

//This is the function called on entry to the cellarInteriortrigger and calls
//openInterior
function cellarInteriorTrigger::onEnterTrigger(%trigger, %this, %obj)
{
   openInterior(%this.InteriorID);
}

//This is the function called on leaving the cellarInteriortrigger and calls
//closeInterior
function cellarInteriorTrigger::onLeaveTrigger(%trigger, %this, %obj)
{
   closeInterior(%this.InteriorID);
}
