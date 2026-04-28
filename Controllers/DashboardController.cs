using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;

namespace WorkoutTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    public async Task<ActionResult> GetGeneralStats()
    {
        // Liczymy całkowitą liczbę treningów
        var totalWorkouts = await _context.WorkoutSessions.CountAsync();

        // Liczymy sumę wszystkich podniesionych kilogramów 
        // Wchodzimy w sesje, potem w ich serie i sumujemy
        var totalVolume = await _context.Sets
            .SumAsync(s => s.Weight * s.Reps);

        // Wyciągamy datę ostatniego treningu
        var lastWorkoutDate = await _context.WorkoutSessions
            .OrderByDescending(w => w.Date)
            .Select(w => w.Date)
            .FirstOrDefaultAsync();

        return Ok(new
        {
            TotalWorkouts = totalWorkouts,
            TotalVolumeKg = totalVolume,
            LastWorkout = lastWorkoutDate == default ? "Brak treningów" : lastWorkoutDate.ToString("yyyy-MM-dd"),
            Message = "Statystyki wygenerowane pomyślnie!"
        });
    }
}