using FundamentalLib.Core;
using FundamentalLib.Interfaces;

namespace FundamentalLib.Classes;

public abstract class Upgrade(IUpgrade upgrade)
{
    public string Name { get; } = upgrade.Name;
    public bool Bought { get; set; } = upgrade.Bought;
    public Func<bool> Condition { get; } = upgrade.Condition;
    public Func<int> Power { get; } = upgrade.Power;
    public Func<string> Effect { get; } = upgrade.Effect;
    public Func<BigDouble> Cost { get; } = upgrade.Cost;
    public IResourceTarget Resource { get; } = upgrade.Resource;
    public string Image { get; } = upgrade.Image;

    public bool IsCanBuy()
    {
        if (Resource.Amount >= Cost() && !Bought) return true;
        return false;
    }
    public void Buy()
    {
        if (IsCanBuy())
        {
            Resource.Decrease(Cost());
            Bought = true;
        }
    }

    public void Reset()
    {
        Bought = false;
    }
}