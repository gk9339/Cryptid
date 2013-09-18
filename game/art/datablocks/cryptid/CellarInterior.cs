//-----------------------------------------------------------------------------
// Copyright (c) 2013 TGL
//----------------------------------------------------------------------------
datablock StaticShapeData (cellarDoor)
{
   shapeFile = "../../shapes/Cryptid/CellarInterior.cached.dts";
   Unopened = true;
   
};

//tickPeriodMS is the amount of time it takes to update the enter and exit 
//methods in milliseconds
datablock TriggerData(cellarDoorTrigger)
{
   tickPeriodMS = 1000;
};
