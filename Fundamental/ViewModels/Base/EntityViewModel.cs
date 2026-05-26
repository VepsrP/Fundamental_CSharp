using CommunityToolkit.Mvvm.ComponentModel;
using FundamentalLib.Core;

namespace Fundamental.ViewModels.Base
{
    public abstract class EntityViewModel(BigDouble amount, string name, string image) : ObservableObject
    {
        public BigDouble Amount { get; set; } = amount;

        public string Name { get; } = name;

        public string Image { get; } = image;

        public virtual void Increase(BigDouble value) => Amount = Amount.Add(value);

        public virtual void Decrease(BigDouble value) => Amount = Amount.Subtract(value);

        /// <summary>Текущее количество имеющихся в наличии производств</summary>
        public string AmountDisplay => $"{Amount}";
    }
}
