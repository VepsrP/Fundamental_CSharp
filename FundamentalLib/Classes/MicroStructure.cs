using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace FundamentalLib.Classes
{
    internal class MicroStructure : Structure
    {
        public MicroStructure(IStructure structure) : base(structure)
        {
        }

        public override void Produce()
        {
            base.Produce();
            Target.Increase(new BigDouble(Producing).Multiply(GlobalBase.Multiplier));

        }

        public BigDouble CalculateBaseProducing()
        {
            return new BigDouble(BaseProducing) * Amount;
        }
        public override void CalculateProducing()
        {
            Producing = new BigDouble(CalculateBaseProducing()) * GlobalBase.Multiplier;
        }

        public override BigDouble Cost(int count)
        {
            throw new NotImplementedException();
        }
    }
}
