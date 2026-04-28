using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Interfaces;

namespace WorkoutTracker.Services;

public class DashboardService : IDashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<object> GetGeneralStatsAsync()
    {
        var totalWorkouts = await _context.WorkoutSessions.CountAsync();
        var totalVolume = await _context.Sets.SumAsync(s => s.Weight * s.Reps);
        var lastWorkoutDate = await _context.WorkoutSessions
            .OrderByDescending(w => w.Date)
            .Select(w => w.Date)
            .FirstOrDefaultAsync();

        return new
        {
            TotalWorkouts = totalWorkouts,
            TotalVolumeKg = totalVolume,
            LastWorkout = lastWorkoutDate == default ? "Brak treningów" : lastWorkoutDate.ToString("yyyy-MM-dd"),
            Message = "Statystyki wygenerowane przez Service Layer"
        };
    }
}