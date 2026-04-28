using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Models;

public class Set
{
    public int Id { get; set; }
    public int WorkoutSessionId { get; set; }

    public int ExerciseId { get; set; }

    [Range(1, 100, ErrorMessage = "Liczba powtórzeń musi być między 1 a 100")]
    public int Reps { get; set; }

    [Range(0, 1000, ErrorMessage = "Ciężar nie może być ujemny ani przekraczać 1000 kg")]
    public double Weight { get; set; }
}