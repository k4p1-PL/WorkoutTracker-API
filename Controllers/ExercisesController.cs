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

    // GET: Pobiera wszystkie ćwiczenia z bazy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return await _context.Exercises.ToListAsync();
    }

    // POST: Dodaje nowe ćwiczenie do bazy
    [HttpPost]
    public async Task<ActionResult<Exercise>> AddExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync(); // Zapisanie zmian w bazie

        return Ok(exercise); // Zwraca kod 200 i obiekt, który dodaliśmy do bazy
    }

    // GET: api/exercises/search?name=klatka
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Exercise>>> SearchExercises(string name)
    {
        // Tworzymy zapytanie (IQueryable)
        var query = _context.Exercises.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            
            query = query.Where(e => e.Name.ToLower().Contains(name.ToLower())
                          || e.TargetMuscle.ToLower().Contains(name.ToLower()));
        }

      
        var results = await query.ToListAsync();

        return Ok(results);
    }
}