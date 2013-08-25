function LoadDoors()
{
   echo ("Loading doors:");
   exec ("art/shapes/Cryptid/Exterior/DUMMYcellardoorNOANIM.cached.cs"); addCellarDoor();
   //exec ("art/shapes/Cryptis/Cellar/CellarInterior.cs"); addCellarInterior();
   echo ("All doors Loaded");
}
LoadDoors();