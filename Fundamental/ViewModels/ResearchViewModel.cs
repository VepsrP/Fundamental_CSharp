using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace Fundamental.ViewModels
{
    public partial class ResearchViewModel(IResearch research) : ObservableObject
    {
        #region Static Properties (не изменяются после инициализации)
        public string Name { get; } = research.Name;
        public int Amount { get; set; } = research.Amount;
        public Func<int> MaxAmount { get; } = research.MaxAmount;
        public string Color { get; } = research.Color;
        public Func<bool> Condition { get; } = research.Condition;
        public Func<int> Power { get; } = research.Power;
        public Func<string> Effect { get; } = research.Effect;
        public Func<double> BaseCost { get; } = research.BaseCost;
        public Func<double> CostScaling { get; } = research.CostScaling;
        public IResourceTarget Resource { get; } = research.Resource;
        public string Image { get; } = research.Image;
        #endregion

        #region Computed Properties

        public bool CanBuy => IsCanBuy();

        /// <summary>Отображение стоимости</summary>
        public string CostDisplay => $"{BaseCost() * Math.Pow(CostScaling(), Amount)} {Resource.Name}";

        /// <summary>Отображение эффекта</summary>
        public string EffectDisplay => Effect();

        /// <summary>Отображение мощности</summary>
        public string PowerDisplay => $"{Power()}";

        /// <summary>Название ресурса</summary>
        public string ResourceName => Resource.Name;

        /// <summary>Текущее количество ресурса</summary>
        public BigDouble ResourceAmount => Resource.Amount;

        /// <summary>Текущее количество купленых уровней разработки</summary>
        public string AmountDisplay => $"{Amount}";

        /// <summary>Максимальное оличество доступных уровней разработки</summary>
        public string MaxAmountDisplay => $"{MaxAmount}";

        #endregion

        #region Commands

        [RelayCommand(CanExecute = nameof(IsCanBuy))]
        private void Buy()
        {
            Resource.Decrease(BaseCost() * Math.Pow(CostScaling(), Amount));
            OnBoughtChanged();
        }

        [RelayCommand]
        private void Reset()
        {
            Amount = 0;
            OnBoughtChanged();
        }

        #endregion

        #region Helper Methods

        private bool IsCanBuy()
        {
            return Amount < MaxAmount() && Resource.Amount >= BaseCost() * Math.Pow(CostScaling(), Amount);
        }

        /// <summary>Вызывает PropertyChanged для всех зависимых свойств при изменении Bought</summary>
        private void OnBoughtChanged()
        {
            OnPropertyChanged(nameof(Amount));
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
