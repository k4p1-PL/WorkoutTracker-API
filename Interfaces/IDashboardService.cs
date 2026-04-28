namespace WorkoutTracker.Interfaces;

public interface IDashboardService
{
    Task<object> GetGeneralStatsAsync();
}