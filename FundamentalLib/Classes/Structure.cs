using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace FundamentalLib.Classes;

public abstract class Structure : Entity, IResourceTarget
{
    public int TrueAmount { get; set; }
    public BigDouble TotalAmount { get; set; }
    public BigDouble TrueTotalAmount { get; set; }
    public bool True { get; set; }
    public double BaseCost { get; set; }
    public IResourceTarget Target { get; set; }
    public double CostScaling { get; set; }
    public IResourceTarget ResourceTarget { get; set; }
    public BigDouble ResourceProducing { get; set; }
    public IResourceTarget BuyingResource { get; set; }
    public double BaseProducing { get; set; }
    public double BaseImproving { get; set; }
    public BigDouble Producing { get; set; } = BigDouble.Zero;

    protected Structure(IStructure structure) : base(amount: structure.Amount, name: structure.Name, image: structure.Image)
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

    public virtual void Produce()
    {
        CalculateProducing();
    }

    public override void Increase(BigDouble value)
    {
        base.Increase(value);
        TotalAmount.Add(value);
        TrueTotalAmount.Add(value);
        True = true;
        CalculateProducing();
    }

    public virtual void Decrease(BigDouble value, bool isTrue = false)
    {
        base.Decrease(value);
        if (!isTrue) TrueAmount -= (int)value.ToDouble();
        True = isTrue;
    }


    public void ResetAmount()
    {
        Amount = BigDouble.Zero;
        TrueAmount = 0;
        TotalAmount = BigDouble.Zero;
        CalculateProducing();
        True = false;
    }

    public virtual void Buy(int count)
    {
        (bool canBuy, _) = IsCanBuy(count);
        if(canBuy)
        {
            BuyingResource.Decrease(new BigDouble(1).Multiply(Cost(count)), true);
            Amount.Add(count);
            TotalAmount.Add(count);
            TrueTotalAmount.Add(count);
            TrueAmount += count;
            ResourceTarget.Increase(new BigDouble(count).Multiply(ResourceProducing));
        }
    }

    public virtual Tuple<bool, int> IsCanBuy(int count)
    {
        if (count > 0)
            return Tuple.Create(BuyingResource.Amount >= count, count);
        else if (count < 0)
            return Tuple.Create(false, 0);
        else
        {
            int i = 1;
            while (BuyingResource.Amount >= Cost(i))
                i++;
            return Tuple.Create(BuyingResource.Amount >= Cost(1), Math.Max(i - 1, 1));
        }
    }
}