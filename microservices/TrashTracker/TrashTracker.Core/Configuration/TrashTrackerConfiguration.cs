namespace TrashTracker.Core.Configuration;

public sealed class TrashTrackerConfiguration
{
    public string KomaApiPath { get; set; }
    public string MpoSchedulePdfPath { get; set; }
    public MpoSchedulesConfiguration MpoSchedules { get; set; }
    
}