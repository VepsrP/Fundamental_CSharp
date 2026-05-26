using Fundamental.Core;
using Fundamental.Interfaces;

namespace Fundamental.ViewModels.Base;

/// <summary>
/// Базовый класс для структур этапа Microworld.
/// </summary>
public abstract partial class MicrostructureViewModel(IStructure structure, PlayerState playerState) : StructureViewModel(structure)
{
    public override void CalculateProducing()
    {
        Producing = calculateBaseProducing().Multiply(GlobalBase.Multiplier);
    }

    public override BigDouble Cost(int count)
    {
        BigDouble summ = 0;
        for(int i = 1; i <= count; ++i)
            summ += new BigDouble(BaseCost).Multiply(new BigDouble(CostScaling) - (playerState.Upgrades[1][7].Bought ? playerState.Upgrades[1][7].Power() : 0)).Pow(TrueAmount + i - 1);
        return summ;
    }

    public BigDouble calculateBaseProducing()
    {
        return new BigDouble(BaseProducing).Multiply(Amount).Multiply(playerState.Upgrades[1][8].Bought ? Math.Pow(playerState.Upgrades[1][8].Power(), TrueAmount) : 1);
    }
}