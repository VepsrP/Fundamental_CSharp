using CommunityToolkit.Mvvm.Input;
using Fundamental.Core;
using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace Fundamental.ViewModels.Base;

/// <summary>
/// Базовый класс для всех структур (зданий/сооружений), производящих ресурсы.
/// </summary>
public abstract partial class StructureViewModel : EntityViewModel, IResourceTarget
{
    private int _buyX = 1;

    /// <summary>Количество покупаемых структур за раз (0 = авто)</summary>
    public int BuyX
    {
        get => _buyX;
        set
        {
            _buyX = value;
            OnPropertyChanged(nameof(BuyXDisplay));
            OnPropertyChanged(nameof(CostDisplay));
            BuyCommand.NotifyCanExecuteChanged();
        }
    }

    /// <summary>Количество купленных структур (учитывает только "настоящие" покупки)</summary>
    public int TrueAmount { get; set; }

    /// <summary>Общее количество структур (включая бонусы и модификаторы)</summary>
    public BigDouble TotalAmount { get; set; }

    /// <summary>Истинное общее количество структур (сумма всех покупок)</summary>
    public BigDouble TrueTotalAmount { get; set; }

    /// <summary>Флаг, указывающий, есть ли структуры, купленные за "настоящие" ресурсы</summary>
    public bool True { get; set; }

    /// <summary>Базовая стоимость одной структуры</summary>
    public double BaseCost { get; set; }

    /// <summary>Цель (ресурс), на который влияет структура</summary>
    public IResourceTarget Target { get; set; }

    /// <summary>Множитель роста стоимости при каждой покупке</summary>
    public double CostScaling { get; set; }

    /// <summary>Ресурс, который структура производит или улучшает</summary>
    public IResourceTarget ResourceTarget { get; set; }

    /// <summary>Количество производимого ресурса за единицу структуры</summary>
    public BigDouble ResourceProducing { get; set; }

    /// <summary>Ресурс, за который покупаются структуры</summary>
    public IResourceTarget BuyingResource { get; set; }

    /// <summary>Базовое производство ресурса одной структурой</summary>
    public double BaseProducing { get; set; }

    /// <summary>Базовое улучшение (модификатор производства)</summary>
    public double BaseImproving { get; set; }

    /// <summary>Итоговое производство ресурса всеми структурами</summary>
    public BigDouble Producing { get; set; } = BigDouble.Zero;

    protected StructureViewModel(IStructure structure) : base(amount: structure.Amount, name: structure.Name, image: structure.Image)
    {
        TrueAmount = structure.TrueAmount;
        TotalAmount = structure.TotalAmount;
        TrueTotalAmount = structure.TrueTotal;
        True = new BigDouble(Amount) != TrueAmount;
        BaseCost = structure.Cost;
        Target = structure.Target;
        CostScaling = structure.CostScaling;
        ResourceTarget = structure.ResourceTarget;
        ResourceProducing = structure.ResourceProducing;
        BuyingResource = structure.BuyingResource;
        BaseProducing = structure.Producing;
        BaseImproving = structure.Improving;
    }

    public abstract BigDouble Cost(int count);

    public abstract void CalculateProducing();

    public virtual BigDouble Improving()
    {
        return new BigDouble(BaseImproving).Multiply(Amount).Max(1);
    }

    [RelayCommand]
    public virtual void Produce()
    {
        Target.Increase(Producing.Multiply(GlobalBase.Multiplier));
    }

    public override void Increase(BigDouble value)
    {
        Amount = Amount.Add(value);
        TotalAmount = TotalAmount.Add(value);
        TrueTotalAmount = TrueTotalAmount.Add(value);
        True = true;
        RefreshProperties();
        CalculateProducing();
    }

    public virtual void Decrease(BigDouble value, bool isTrue = false)
    {
        Amount = Amount.Subtract(value);
        if (!isTrue) TrueAmount -= (int)value.ToDouble();
        True = isTrue;
        RefreshProperties();
    }

    #region Computed Properties

        /// <summary>Отображение стоимости</summary>
        public string CostDisplay => $"{Cost(EffectiveBuyX)} {ResourceTarget.Name}";

        /// <summary>Название ресурса</summary>
        public string ResourceName => ResourceTarget.Name;

        /// <summary>Текущее количество купленых производств</summary>
        public string TrueAmountDisplay => $"{TrueAmount}";

        /// <summary>Количество всех произведенных производств до локального сброса(Разряд, испарение, повышение ранка, коллапс, создание галактики)</summary>
        public string TotalAmountDisplay => $"{TotalAmount}";

        /// <summary>Количество всех произведенных производств до сброса этапа</summary>
        public string TrueTotalAmountDisplay => $"{TrueTotalAmount}";

        /// <summary>
        /// Фактическое количество для покупки: если игрок указал BuyX &gt; 0 — берёт его,
        /// иначе вычисляет максимальное доступное количество.
        /// </summary>
        public int EffectiveBuyX
        {
            get
            {
                if (BuyX > 0) return BuyX;

                // Ищем максимальное доступное количество
                int i = 1;
                while (BuyingResource.Amount >= Cost(i))
                    i++;
                return Math.Max(i - 1, 1);
            }
        }

        /// <summary>Отображение количества для покупки</summary>
        public string BuyXDisplay => $"{EffectiveBuyX}";

        #endregion

    [RelayCommand]
    public void ResetAmount()
    {
        Amount = BigDouble.Zero;
        TrueAmount = 0;
        TotalAmount = BigDouble.Zero;
        CalculateProducing();
        True = false;
    }

    [RelayCommand(CanExecute = nameof(IsCanBuy))]
    public virtual void Buy(int count)
    {
        int buyCount = EffectiveBuyX;

        BuyingResource.Decrease(new BigDouble(Cost(buyCount)), true);
        Amount = Amount.Add(buyCount);
        TotalAmount = TotalAmount.Add(buyCount);
        TrueTotalAmount = TrueTotalAmount.Add(buyCount);
        TrueAmount += buyCount;
        ResourceTarget.Increase(new BigDouble(buyCount).Multiply(ResourceProducing));
        CalculateProducing();
        RefreshProperties();
    }

    public virtual bool IsCanBuy()
    {
        return BuyingResource.Amount >= Cost(1);
    }

    public void RefreshProperties()
    {
        OnPropertyChanged(nameof(CostDisplay));
        OnPropertyChanged(nameof(AmountDisplay));
        OnPropertyChanged(nameof(TrueAmountDisplay));
        OnPropertyChanged(nameof(TotalAmountDisplay));
        OnPropertyChanged(nameof(TrueTotalAmountDisplay));
        OnPropertyChanged(nameof(BuyXDisplay));
        BuyCommand.NotifyCanExecuteChanged();
    }
}