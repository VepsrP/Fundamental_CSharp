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
        Func<int> MaxBuilding { get; }
        Func<int> MinUpgrade { get; }
        Func<PlayerState, int> MaxUpgrade { get; }
        Func<int> MinResearch { get; }
        Func<int> MaxResearch { get; }
        Func<PlayerState, int> MinResearchExtra { get; }
        Func<PlayerState, int> MaxResearchExtra { get; }
        Func<BigDouble> StageRequirement { get; }
        string UpgradeImagePrefix { get; }
        string ResearchImagePrefix { get; }
    }
}