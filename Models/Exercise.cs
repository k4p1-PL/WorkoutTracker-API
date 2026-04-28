using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Models;

public class Exercise
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa ćwiczenia jest wymagana")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nazwa musi mieć od 3 do 100 znaków")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string TargetMuscle { get; set; } = string.Empty;
}