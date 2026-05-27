using Fundamental.Interfaces;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels.Microworld;
/// <summary>
/// Класс для структуры Preons.
/// </summary>
public abstract partial class PreonsViewModel(IStructure structure, PlayerState playerState) : MicrostructureViewModel(structure, playerState)
{
    
}