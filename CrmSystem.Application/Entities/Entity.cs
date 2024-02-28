namespace CrmSystem.Application.Entities;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; }

    public void Update()
    {
        UpdateAt = DateTime.UtcNow;
    }
}