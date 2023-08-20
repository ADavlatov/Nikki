namespace Nikki.Core.Models;

public class Subtask
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public TaskModel Task { get; set; }
}