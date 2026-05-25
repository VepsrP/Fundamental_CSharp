using FundamentalLib.Interfaces;

namespace FundamentalLib.Classes;

public class Research(IResearch research)
{
    public string Name { get; set; } = research.Name;
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
}