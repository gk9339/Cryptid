
singleton TSShapeConstructor(DUMMYcellardoorDae)
{
   baseShape = "./DUMMYcellardoor.dae";
};

function DUMMYcellardoorDae::onLoad(%this)
{
   %this.setSequenceCyclic("ambient", "0");
   %this.renameSequence("ambient", "__backup__ambient_1");
   %this.addSequence("__backup__ambient_1", "open", "3", "19", "1", "0");
   %this.removeSequence("__backup__ambient_1");
}
