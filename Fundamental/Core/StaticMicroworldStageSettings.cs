using System.Data;

namespace Fundamental.Core;

public static class StaticMicroworldStageSettings
{
    public static string Name { get; } = "Microworld";
    public static string TextColor { get; } = "CyanTextColor";
    public static string ButtonBorder { get; } = "Stage1ButtonBorderColor";
    public static string ImageBorderColor { get; } = "Stage1BorderImage";
    public static Func<PlayerState, int> MinBuilding { get; } = ps => ps.Vacuum.State ? 1 : 3;
    public static Func<int> MaxBuilding { get; } = () => 5;
    public static Func<int> MinUpgrade { get; } = () => 1;
    public static Func<PlayerState, int> MaxUpgrade { get; } = ps => !ps.Upgrades[1][6].Bought ? 6 : ps.Vacuum.State ? 11 : 10;
    public static Func<int> MinResearch { get; } = () => 1;
    public static Func<int> MaxResearch { get; } = () => 6;
    public static Func<PlayerState, int> MinResearchExtra { get; } = ps => ps.Vacuum.State ? 1 : 0;
    public static Func<PlayerState, int> MaxResearchExtra { get; } = ps => ps.Vacuum.State ? 6 : 0;
    public static Func<BigDouble> StageRequirement { get; } = () => new BigDouble(1.67133125e21);
    public static string UpgradeImagePrefix { get; } = "UpgradeQ";
    public static string ResearchImagePrefix { get; } = "ResearchQ";
}