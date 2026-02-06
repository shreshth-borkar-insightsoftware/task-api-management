using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

public enum Priority
{
    Low = 0,
    Medium = 1,
    High = 2,
    Critical = 3
}

public enum Status
{
    Todo = 0,
    InProgress = 1,
    Completed = 2
}
