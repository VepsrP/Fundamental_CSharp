using System.ComponentModel;
using System.Windows.Input;
using FundamentalLib.Classes;
using FundamentalLib.Core;
using Prism.Commands;
using Prism.Mvvm;

namespace Fundamental.ViewModels
{
    /// <summary>
    /// ViewModel для отображения и взаимодействия с Upgrade (Model)
    /// </summary>
    public class UpgradeViewModel : BindableBase
    {
        private readonly PlayerState _playerState;
        private readonly int _stage;
        private readonly int _id;

        /// <summary>
        /// Модель извлекается из PlayerState по индексу
        /// </summary>
        private Upgrade Model => _playerState.Upgrades[_stage][_id];

        public UpgradeViewModel(int stage, int id, PlayerState playerState)
        {
            _stage = stage;
            _id = id;
            _playerState = playerState;
            BuyCommand = new DelegateCommand(ExecuteBuy, CanExecuteBuy);
            ResetCommand = new DelegateCommand(ExecuteReset, CanExecuteReset);
        }

        #region Properties

        /// <summary>Название улучшения</summary>
        public string Name => Model.Name;

        /// <summary>Изображение улучшения</summary>
        public string Image => Model.Image;

        /// <summary>Куплено ли улучшение</summary>
        public bool Bought => Model.Bought;

        /// <summary>Можно ли купить</summary>
        public bool CanBuy => Model.IsCanBuy();

        /// <summary>Отображение стоимости</summary>
        public string CostDisplay => $"{Model.Cost()} {Model.Resource.Name}";

        /// <summary>Отображение эффекта</summary>
        public string EffectDisplay => Model.Effect();

        /// <summary>Отображение мощности</summary>
        public string PowerDisplay => $"{Model.Power()}";

        /// <summary>Название ресурса</summary>
        public string ResourceName => Model.Resource.Name;

        /// <summary>Текущее количество ресурса</summary>
        public BigDouble ResourceAmount => Model.Resource.Amount;

        #endregion

        #region Commands

        public ICommand BuyCommand { get; }
        public ICommand ResetCommand { get; }

        private void ExecuteBuy()
        {
            Model.Buy();
            RefreshProperties();
        }

        private bool CanExecuteBuy() => Model.IsCanBuy();

        private void ExecuteReset()
        {
            Model.Reset();
            RefreshProperties();
        }

        private bool CanExecuteReset()
        {
            return true;
        }

        #endregion

        #region Methods

        /// <summary>Обновляет все свойства для UI</summary>
        public void RefreshProperties()
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bought)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CanBuy)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CostDisplay)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(EffectDisplay)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(ResourceAmount)));

            // Обновляем состояние команды
            (BuyCommand as DelegateCommand)?.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
