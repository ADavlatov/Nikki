namespace Nikki.Core.Models;

public class Status
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public List<Task> Tasks { get; set; }
    public Table Table { get; set; }
}