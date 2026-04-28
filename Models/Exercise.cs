namespace WorkoutTracker.Models
{
    public class Exercise
    {
        public int Id { get; set; } // PK
        public string Name { get; set; } = string.Empty; 
        public string TargetMuscle { get; set; } = string.Empty; 
    }
}
