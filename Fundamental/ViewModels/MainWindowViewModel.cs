using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fundamental.Core;
using FundamentalLib.Classes;

namespace Fundamental.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly PlayerState _playerState;

        public MainWindowViewModel(PlayerState playerState)
        {
            _playerState = playerState;
            InitializeUpgrades();
        }

        #region Title

        /// <summary>Заголовок окна</summary>
        public string Title => "Fundamental";

        #endregion

        #region Loading / Content Visibility

        [ObservableProperty]
        private Visibility _loadingPanelVisible = Visibility.Collapsed;

        [ObservableProperty]
        private Visibility _mainContent = Visibility.Visible;

        #endregion

        #region PlayerState Access

        public PlayerState PlayerState => _playerState;

        #endregion

        #region Initialize Upgrades

        private void InitializeUpgrades()
        {
            // Пример инициализации улучшений
            // Здесь должна быть логика создания UpgradeViewModel из IUpgrade
            // _playerState.Upgrades[stage][id] = new UpgradeViewModel(upgrade);
        }

        #endregion
    }
}
