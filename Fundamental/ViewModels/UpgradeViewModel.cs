using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace Fundamental.ViewModels
{
    /// <summary>
    /// ViewModel для улучшения (объединённая модель + ViewModel с CommunityToolkit.Mvvm)
    /// </summary>
    public partial class UpgradeViewModel : ObservableObject
    {
        public UpgradeViewModel(IUpgrade upgrade)
        {
            Name = upgrade.Name;
            _bought = upgrade.Bought;
            Color = upgrade.Color;
            Condition = upgrade.Condition;
            Power = upgrade.Power;
            Effect = upgrade.Effect;
            Cost = upgrade.Cost;
            Resource = upgrade.Resource;
            Image = upgrade.Image;
        }

        #region Static Properties (не изменяются после инициализации)

        /// <summary>Название улучшения</summary>
        public string Name { get; }

        /// <summary>Изображение улучшения</summary>
        public string Image { get; }

        /// <summary>Цвет</summary>
        public string Color { get; }

        /// <summary>Условие доступности</summary>
        public Func<bool> Condition { get; }

        /// <summary>Мощность</summary>
        public Func<int> Power { get; }

        /// <summary>Эффект</summary>
        public Func<string> Effect { get; }

        /// <summary>Стоимость</summary>
        public Func<BigDouble> Cost { get; }

        /// <summary>Целевой ресурс</summary>
        public IResourceTarget Resource { get; }

        #endregion

        #region Observable Properties

        [ObservableProperty]
        private bool _bought;

        #endregion

        #region Computed Properties

        /// <summary>Можно ли купить</summary>
        public bool CanBuy => IsCanBuy();

        /// <summary>Отображение стоимости</summary>
        public string CostDisplay => $"{Cost()} {Resource.Name}";

        /// <summary>Отображение эффекта</summary>
        public string EffectDisplay => Effect();

        /// <summary>Отображение мощности</summary>
        public string PowerDisplay => $"{Power()}";

        /// <summary>Название ресурса</summary>
        public string ResourceName => Resource.Name;

        /// <summary>Текущее количество ресурса</summary>
        public BigDouble ResourceAmount => Resource.Amount;

        #endregion

        #region Commands

        [RelayCommand(CanExecute = nameof(IsCanBuy))]
        private void Buy()
        {
            Resource.Decrease(Cost());
            Bought = true;
            OnBoughtChanged();
        }

        [RelayCommand]
        private void Reset()
        {
            Bought = false;
            OnBoughtChanged();
        }

        #endregion

        #region Helper Methods

        private bool IsCanBuy()
        {
            return Resource.Amount >= Cost() && !Bought;
        }

        /// <summary>Вызывает PropertyChanged для всех зависимых свойств при изменении Bought</summary>
        private void OnBoughtChanged()
        {
            OnPropertyChanged(nameof(Bought));
            OnPropertyChanged(nameof(CanBuy));
            OnPropertyChanged(nameof(CostDisplay));
            OnPropertyChanged(nameof(EffectDisplay));
            OnPropertyChanged(nameof(ResourceAmount));
            BuyCommand.NotifyCanExecuteChanged();
        }

        /// <summary>Обновляет все свойства для UI (вызывается извне при изменении ресурсов)</summary>
        public void RefreshProperties()
        {
            OnPropertyChanged(nameof(CanBuy));
            OnPropertyChanged(nameof(CostDisplay));
            OnPropertyChanged(nameof(ResourceAmount));
            BuyCommand.NotifyCanExecuteChanged();
        }

        #endregion
    }
}
