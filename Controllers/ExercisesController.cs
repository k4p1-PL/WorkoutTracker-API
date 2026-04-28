using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly AppDbContext _context;

    // Pobieramy połączenie z bazą
    public ExercisesController(AppDbContext context)
    {
        _context = context;
    }

    // Pobiera wszystkie ćwiczenia z bazy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return await _context.Exercises.ToListAsync();
    }

    // Dodaje nowe ćwiczenie do bazy
    [HttpPost]
    public async Task<ActionResult<Exercise>> AddExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync(); // Zapisanie zmian w bazie

        return Ok(exercise); // Zwraca kod 200 i obiekt, który dodaliśmy do bazy
    }
}