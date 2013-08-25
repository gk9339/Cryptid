function LoadDoors()
{
   echo ("Loading doors:");
   exec ("art/shapes/Cryptid/Exterior/DUMMYcellardoorNOANIM.cached.cs"); addCellarDoor();
   echo ("All doors Loaded");
}
LoadDoors();