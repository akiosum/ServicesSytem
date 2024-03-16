namespace CrmSystem.Domain.Entities;

public abstract class Entity
{
    #region Properties

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; private set; }

    #endregion Properties

    #region Methods

    public void Update()
    {
        UpdateAt = DateTime.UtcNow;
    }

    #endregion Methods
}