using Fundamental.Interfaces;

namespace Fundamental.Core.StageSettings;

public class Interstellar : IStageSettings
{
    public string Name => "Interstellar";
    public string TextColor => "OrangeTextColor";
    public string ButtonBorder => "Stage4ButtonBorderColor";
    public string ImageBorderColor => "Stage4BorderImage";

    public Func<PlayerState, int> MinBuilding => _ => 1;
    public Func<PlayerState, int> MaxBuilding => ps => ps.Vacuum.True ? 5 : 4;
    public Func<PlayerState, int> MinUpgrade => _ => 1;
    public Func<PlayerState, int> MaxUpgrade => _ => 6;
    public Func<PlayerState, int> MinResearch => _ => 1;
    public Func<PlayerState, int> MaxResearch => _ => 6;
    public Func<PlayerState, int> MinResearchExtra => _ => 1;
    public Func<PlayerState, int> MaxResearchExtra => _ => 5;
    public Func<BigDouble> StageRequirement => () => new BigDouble(1e80);
    public string UpgradeImagePrefix => "UpgradeS";
    public string ResearchImagePrefix => "ResearchS";
    public Func<PlayerState, int>? MaxRank => null;
}