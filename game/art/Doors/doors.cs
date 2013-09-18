function LoadDoors()
{
   echo ("Loading doors:");
   exec ("art/shapes/Cryptid/Exterior/cellardoor.cached.cs"); addCellarDoor();
   exec ("art/shapes/Cryptid/Cellar/CellarInterior.cs"); addCellarInterior();
   echo ("All doors Loaded");
}
LoadDoors();