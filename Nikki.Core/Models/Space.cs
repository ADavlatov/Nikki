namespace Nikki.Core.Models;

public class Space
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public List<Table> Tables { get; set; }
}