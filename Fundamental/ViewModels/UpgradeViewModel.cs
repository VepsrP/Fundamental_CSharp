using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fundamental.Core;
using Fundamental.Interfaces;

namespace Fundamental.ViewModels
{
    /// <summary>
    /// ViewModel для улучшения (объединённая модель + ViewModel с CommunityToolkit.Mvvm)
    /// </summary>
    public partial class UpgradeViewModel(IUpgrade upgrade) : ObservableObject
    {

        #region Static Properties (не изменяются после инициализации)


        /// <summary>Название улучшения</summary>
        public string Name { get; } = upgrade.Name;

        /// <summary>Изображение улучшения</summary>
        public string Image { get; } = upgrade.Image;

        /// <summary>Цвет</summary>
        public string Color { get; } = upgrade.Color;

        /// <summary>Условие доступности</summary>
        public Func<bool> Condition { get; } = upgrade.Condition;

        /// <summary>Мощность</summary>
        public Func<int> Power { get; } = upgrade.Power;

        /// <summary>Эффект</summary>
        public Func<string> Effect { get; } = upgrade.Effect;

        /// <summary>Стоимость</summary>
        public Func<BigDouble> Cost { get; } = upgrade.Cost;

        /// <summary>Целевой ресурс</summary>
        public IResourceTarget Resource { get; } = upgrade.Resource;

        #endregion

        #region Observable Properties

        [ObservableProperty]
        private bool _bought = upgrade.Bought;

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
            BuyCommand.NotifyCanExecuteChanged();
        }

        /// <summary>Обновляет все свойства для UI (вызывается извне при изменении ресурсов)</summary>
        public void RefreshProperties()
        {
            OnPropertyChanged(nameof(CanBuy));
            OnPropertyChanged(nameof(CostDisplay));
            BuyCommand.NotifyCanExecuteChanged();
        }

        #endregion
    }
}
