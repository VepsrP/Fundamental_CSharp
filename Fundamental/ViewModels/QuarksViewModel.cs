using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels;
/// <summary>
/// Класс для структуры Quarks.
/// </summary>
public abstract partial class QuarksViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{
    public override void ResetAmount()
    {
        base.ResetAmount();
    }
}