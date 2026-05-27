using Fundamental.Interfaces;

namespace Fundamental.Core.StageSettings;

public class Submerged : IStageSettings
{
    public string Name => "Submerged";
    public string TextColor => "BlueTextColor";
    public string ButtonBorder => "Stage2ButtonBorderColor";
    public string ImageBorderColor => "Stage2BorderImage";

    public Func<PlayerState, int> MinBuilding => _ => 1;
    public Func<PlayerState, int> MaxBuilding => ps => ps.Vacuum.True ? 6 : 5;
    public Func<PlayerState, int> MinUpgrade => _ => 1;
    public Func<PlayerState, int> MaxUpgrade => ps => ps.Vacuum.True ? 8 : 7;
    public Func<PlayerState, int> MinResearch => _ => 1;
    public Func<PlayerState, int> MaxResearch => ps => ps.Vacuum.True ? 7 : 6;
    public Func<PlayerState, int> MinResearchExtra => _ => 1;
    public Func<PlayerState, int> MaxResearchExtra => ps => ps.Vacuum.True ? 5 : 3;
    public Func<BigDouble> StageRequirement => () => new BigDouble(1.19444e29);

    public string UpgradeImagePrefix => "UpgradeW";
    public string ResearchImagePrefix => "ResearchW";
    public Func<PlayerState, int>? MaxRank => null;
}