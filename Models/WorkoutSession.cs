namespace WorkoutTracker.Models;

public class WorkoutSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now; // Kiedy był trening
    public string Name { get; set; } = string.Empty; // np. "Push Day"

    // Lista serii wykonanych na tym treningu
    public List<Set> Sets { get; set; } = new();
}