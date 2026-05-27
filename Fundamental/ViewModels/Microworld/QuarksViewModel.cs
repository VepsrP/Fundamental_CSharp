using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels.Microworld;
/// <summary>
/// Класс для структуры Quarks.
/// </summary>
public abstract partial class QuarksViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{
    public override void ResetAmount()
    {
        base.ResetAmount();
        if (!_playerState.Vacuum.True)
        {
            TrueAmount = 3;
            Amount = 3;
        }
        CalculateProducing();
    }
}