namespace Nikki.Core.Models;

public class Table
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Status> Statuses { get; set; }
    public int SpaceId { get; set; }
    public Space Space { get; set; }
}