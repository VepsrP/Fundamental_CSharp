using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels.Microworld;
/// <summary>
/// Класс для структуры Preons.
/// </summary>
public abstract partial class MoleculesViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{
    private BigDouble _selfProducing = 0;
    public override void CalculateProducing()
    {
        base.CalculateProducing();
        Producing *= _playerState.Upgrades[1][5].Bought ? 4 : 1;
        CalculateSelfProducing();
    }

    public void CalculateSelfProducing()
    {
        _selfProducing = _playerState.Upgrades[1][9].Bought ? _playerState.Upgrades[1][9].Power() : 0;
        if (_selfProducing >= 0) True = true;
    }

    public override void Produce()
    {
        base.Produce();
        Increase(_selfProducing);
    }
}