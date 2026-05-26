namespace Fundamental.Interfaces
{
    public interface IRank
    {
        int Level { get; set; }
        int EffectiveLevel { get; set; }
        Dictionary<int, int> RankCosts { get; }
        Dictionary<int, string> RankImages { get; }
        Dictionary<int, string> RankNames { get; }

        IResource Resource { get; }
    }
}
