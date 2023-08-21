namespace Nikki.Core.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public List<TaskModel> Tasks { get; set; }
    public int TableId { get; set; }
    public Table Table { get; set; }
}