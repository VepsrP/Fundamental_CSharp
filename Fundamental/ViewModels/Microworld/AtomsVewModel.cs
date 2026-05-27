using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels.Microworld;
/// <summary>
/// Класс для структуры Preons.
/// </summary>
public abstract partial class AtomsViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{
    public override void CalculateProducing()
    {
        base.CalculateProducing();
        Producing *= _playerState.Upgrades[1][4].Bought ? 4 : 1;
    }
}