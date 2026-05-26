namespace Fundamental.Interfaces;

public interface IResearch
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public Func<int> MaxAmount { get; }
    public string Color { get; }
    public Func<bool> Condition { get; }
    public Func<int> Power { get; }
    public Func<string> Effect { get; }
    public Func<double> BaseCost { get; }
    public Func<double> CostScaling { get; }
    public IResourceTarget Resource { get; }
    public string Image { get; }
}