using CommunityToolkit.Mvvm.ComponentModel;
using Fundamental.Core;
using Fundamental.ViewModels.Base;

namespace Fundamental.ViewModels
{
    public partial class BuildingsViewModel(PlayerState playerState) : ObservableObject
    {
        public Dictionary<int, StructureViewModel> StructureViewModels => playerState.Buildings[playerState.ActiveStage];

        private int _buyX = 1;

        /// <summary>Количество покупаемых структур за раз (рассылается всем структурам)</summary>
        public int BuyX
        {
            get => _buyX;
            set
            {
                if (SetProperty(ref _buyX, value))
                {
                    foreach (var structure in StructureViewModels.Values)
                        structure.BuyX = value;
                }
            }
        }
    }
}