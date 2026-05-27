using Fundamental.Interfaces;

namespace Fundamental.Core.StageSettings;

public class Intergalactic : IStageSettings
{
    public string Name => "Intergalactic";
    public string TextColor => "DarkOrchidTextColor";
    public string ButtonBorder => "Stage5ButtonBorderColor";
    public string ImageBorderColor => "Stage5BorderImage";

    public Func<PlayerState, int> MinBuilding => _ => 1;
    public Func<PlayerState, int> MaxBuilding => _ => 2;
    public Func<PlayerState, int> MinUpgrade => _ => 1;
    public Func<PlayerState, int> MaxUpgrade => _ => 7;
    public Func<PlayerState, int> MinResearch => _ => 1;
    public Func<PlayerState, int> MaxResearch => _ => 5;
    public Func<PlayerState, int> MinResearchExtra => _ => 1;
    public Func<PlayerState, int> MaxResearchExtra => _ => 6;
    public Func<BigDouble> StageRequirement => () => new BigDouble(1e80);
    public string UpgradeImagePrefix => "UpgradeG";
    public string ResearchImagePrefix => "ResearchG";
    public Func<PlayerState, int>? MaxRank => null;
}