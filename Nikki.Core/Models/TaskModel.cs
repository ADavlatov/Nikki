namespace Nikki.Core.Models;

public class TaskModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly DueDate { get; set; }
    public string Priority { get; set; }
    public List<Subtask> Subtasks { get; set; }
    public Status Status { get; set; }
}