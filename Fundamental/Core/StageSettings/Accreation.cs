using Fundamental.Interfaces;

namespace Fundamental.Core.StageSettings;

public class Accreation : IStageSettings
{
    public string Name => "Accreation";
    public string TextColor => "GrayTextColor";
    public string ButtonBorder => "Stage3ButtonBorderColor";
    public string ImageBorderColor => "Stage3BorderImage";

    public Func<PlayerState, int> MinBuilding => _ => 1;
    public Func<PlayerState, int> MaxBuilding => ps => ps.Vacuum.True ? 6 : 5;
    public Func<PlayerState, int> MinUpgrade => _ => 1;
    public Func<PlayerState, int> MaxUpgrade => _ => 14;
    public Func<PlayerState, int> MinResearch => _ => 1;
    public Func<PlayerState, int> MaxResearch => _ => 9;
    public Func<PlayerState, int> MinResearchExtra => _ => 1;
    public Func<PlayerState, int> MaxResearchExtra => _ => 6;
    public Func<BigDouble> StageRequirement => () => new BigDouble(2.45576045e31);
    public string UpgradeImagePrefix => "UpgradeA";
    public string ResearchImagePrefix => "ResearchA";
    public Func<PlayerState, int>? MaxRank => ps => ps.Vacuum.True ? 6: ps.Events[3].Played ? 5 : 4;
}