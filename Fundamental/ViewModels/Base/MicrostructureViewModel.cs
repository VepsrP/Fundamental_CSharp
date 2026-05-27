using Fundamental.Core;
using Fundamental.Interfaces;

namespace Fundamental.ViewModels.Base;

/// <summary>
/// Базовый класс для структур этапа Microworld.
/// </summary>
public abstract partial class MicrostructureViewModel(IStructure structure, PlayerState playerState) : StructureViewModel(structure)
{
    protected readonly PlayerState _playerState = playerState;


    public override void CalculateProducing()
    {
        Producing = calculateBaseProducing().Multiply(GlobalBase.Multiplier);
    }

    public override BigDouble Cost(int count)
    {
        double CostScalingReduce = _playerState.Upgrades[1][7].Bought ? _playerState.Upgrades[1][7].Power() : 0;
        double CostDivide = _playerState.Upgrades[1][3].Bought ? _playerState.Upgrades[1][3].Power() : 0;
        BigDouble summ = 0;
        for(int i = 1; i <= count; ++i)
            summ += new BigDouble(BaseCost).Multiply(new BigDouble(CostScaling - CostScalingReduce)).Pow(TrueAmount + i - 1).Divide(CostDivide);
        return summ;
    }

    public BigDouble calculateBaseProducing()
    {
        return new BigDouble(BaseProducing).Multiply(Amount).Multiply(_playerState.Upgrades[1][8].Bought ? Math.Pow(_playerState.Upgrades[1][8].Power(), TrueAmount) : 1);
    }
}