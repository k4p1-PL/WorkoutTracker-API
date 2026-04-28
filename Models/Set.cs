namespace WorkoutTracker.Models;

public class Set
{
    public int Id { get; set; }

    // Do jakiego treningu należy ta seria
    public int WorkoutSessionId { get; set; }
    public WorkoutSession? WorkoutSession { get; set; }

    // Jakie to było ćwiczenie
    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    // Wyniki z siłowni
    public int Reps { get; set; } // Liczba powtórzeń
    public double Weight { get; set; } // Ciężar w kg
}