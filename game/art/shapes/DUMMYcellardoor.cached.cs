
singleton TSShapeConstructor(DUMMYcellardoor_cachedDts)
{
   baseShape = "./DUMMYcellardoor.cached.dts";
};

function DUMMYcellardoor_cachedDts::onLoad(%this)
{
   %this.addSequence("./DUMMYcellardoor.dae", "open", "0", "-1", "1", "0");
   %this.setSequenceCyclic("ambient", "0");
}
