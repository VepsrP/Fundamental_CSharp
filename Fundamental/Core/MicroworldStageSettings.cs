using Fundamental.Interfaces;

namespace Fundamental.Core;

public class MicroworldStageSettings() : IStageSettings
{
    public string Name => StaticMicroworldStageSettings.Name;

    public string TextColor => StaticMicroworldStageSettings.TextColor;

    public string ButtonBorder => StaticMicroworldStageSettings.ButtonBorder;

    public string ImageBorderColor => StaticMicroworldStageSettings.ImageBorderColor;

    public Func<PlayerState, int> MinBuilding => StaticMicroworldStageSettings.MinBuilding;

    public Func<int> MaxBuilding => StaticMicroworldStageSettings.MaxBuilding;

    public Func<int> MinUpgrade => StaticMicroworldStageSettings.MinUpgrade;

    public Func<PlayerState, int> MaxUpgrade => StaticMicroworldStageSettings.MaxUpgrade;

    public Func<int> MinResearch => StaticMicroworldStageSettings.MinResearch;

    public Func<int> MaxResearch => StaticMicroworldStageSettings.MaxResearch;

    public Func<PlayerState, int> MinResearchExtra => StaticMicroworldStageSettings.MinResearchExtra;

    public Func<PlayerState, int> MaxResearchExtra => StaticMicroworldStageSettings.MaxResearchExtra;

    public Func<BigDouble> StageRequirement => StaticMicroworldStageSettings.StageRequirement;

    public string UpgradeImagePrefix => StaticMicroworldStageSettings.UpgradeImagePrefix;

    public string ResearchImagePrefix => StaticMicroworldStageSettings.ResearchImagePrefix;
}