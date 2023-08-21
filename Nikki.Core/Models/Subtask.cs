namespace Nikki.Core.Models;

public class Subtask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public int TaskId { get; set; }
    public TaskModel Task { get; set; }
}