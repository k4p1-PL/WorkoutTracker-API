using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.DTOs;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutSessionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkoutSessionsController(AppDbContext context)
    {
        _context = context;
    }

    
    // Pobiera historię treningów przepakowaną do DTO
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutSessionDto>>> GetWorkouts()
    {
        var workouts = await _context.WorkoutSessions
            .Include(w => w.Sets)
            .Select(w => new WorkoutSessionDto // Encja -> DTO
            {
                Id = w.Id,
                Date = w.Date,
                Name = w.Name,
                Sets = w.Sets.Select(s => new SetDto
                {
                    Reps = s.Reps,
                    Weight = s.Weight
                }).ToList()
            })
            .ToListAsync();

        return Ok(workouts);
    }

    // Zapisuje nowy trening w bazie
    [HttpPost]
    public async Task<ActionResult<WorkoutSession>> AddWorkout(WorkoutSession workoutSession)
    {
        _context.WorkoutSessions.Add(workoutSession);
        await _context.SaveChangesAsync();

        return Ok(workoutSession);
    }

    // Zwraca podsumowanie konkretnego treningu
    [HttpGet("{id}/summary")]
    public async Task<ActionResult> GetWorkoutSummary(int id)
    {
        // Szukamy treningu o podanym ID wraz z jego seriami
        var workout = await _context.WorkoutSessions
            .Include(w => w.Sets)
            .FirstOrDefaultAsync(w => w.Id == id);

        // Jeśli nie ma takiego treningu w bazie, zwracamy błąd 404 Not Found
        if (workout == null)
        {
            return NotFound("Nie znaleziono takiego treningu.");
        }

        // liczymy całkowitą objętość
        double totalVolume = workout.Sets.Sum(set => set.Weight * set.Reps);

        // Zwracamy podsumowanie
        return Ok(new
        {
            WorkoutId = workout.Id,
            Name = workout.Name,
            TotalSetsCompleted = workout.Sets.Count,
            TotalVolumeKg = totalVolume
        });
    }
}