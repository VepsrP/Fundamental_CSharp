using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels.Microworld;
/// <summary>
/// Класс для структуры Preons.
/// </summary>
public abstract partial class ParticlesViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{    
    public override BigDouble Cost(int count)
    {
        double CostScalingReduce = _playerState.Upgrades[1][7].Bought ? _playerState.Upgrades[1][7].Power() : 0;
        double CostDivide = _playerState.Upgrades[1][3].Bought ? _playerState.Upgrades[1][3].Power() : 0;
        BigDouble summ = 0;
        for(int i = 1; i <= count; ++i)
            summ += new BigDouble(BaseCost).Multiply(new BigDouble(CostScaling - CostScalingReduce)).Pow(TrueAmount + i - 1).Divide(CostDivide);
        return summ;
    }
}