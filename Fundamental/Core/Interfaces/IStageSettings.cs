using Fundamental.Core;

namespace Fundamental.Interfaces
{
    public interface IStageSettings
    {
        string Name { get; }
        string TextColor { get; }
        string ButtonBorder { get; }
        string ImageBorderColor { get; }
        Func<PlayerState, int> MinBuilding { get; }
        Func<PlayerState, int> MaxBuilding { get; }
        Func<PlayerState, int> MinUpgrade { get; }
        Func<PlayerState, int> MaxUpgrade { get; }
        Func<PlayerState, int> MinResearch { get; }
        Func<PlayerState, int> MaxResearch { get; }
        Func<PlayerState, int> MinResearchExtra { get; }
        Func<PlayerState, int> MaxResearchExtra { get; }
        Func<BigDouble> StageRequirement { get; }
        string UpgradeImagePrefix { get; }
        string ResearchImagePrefix { get; }
        Func<PlayerState, int>? MaxRank { get; }
    }
}