using Fundamental.Interfaces;

namespace Fundamental.Core;

public class MicroworldStageSettings : IStageSettings
{
    public string Name => "Microworld";
    public string TextColor => "CyanTextColor";
    public string ButtonBorder => "Stage1ButtonBorderColor";
    public string ImageBorderColor => "Stage1BorderImage";

    public Func<PlayerState, int> MinBuilding => ps => ps.Vacuum.State ? 1 : 3;
    public Func<PlayerState, int> MaxBuilding => _ => 5;
    public Func<PlayerState, int> MinUpgrade => _ => 1;
    public Func<PlayerState, int> MaxUpgrade => ps => !ps.Upgrades[1][6].Bought ? 6 : ps.Vacuum.State ? 11 : 10;
    public Func<PlayerState, int> MinResearch => _ => 1;
    public Func<PlayerState, int> MaxResearch => _ => 6;
    public Func<PlayerState, int> MinResearchExtra => ps => ps.Vacuum.State ? 1 : 0;
    public Func<PlayerState, int> MaxResearchExtra => ps => ps.Vacuum.State ? 6 : 0;
    public Func<BigDouble> StageRequirement => () => new BigDouble(1.67133125e21);

    public string UpgradeImagePrefix => "UpgradeQ";
    public string ResearchImagePrefix => "ResearchQ";
}