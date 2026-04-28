namespace WorkoutTracker.DTOs;

public class WorkoutSessionDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; } = string.Empty;


    public List<SetDto> Sets { get; set; } = new();
}