namespace CrmSystem.Application.Entities;

public class Product : Entity
{
    #region Properties

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public decimal Cost { get; set; } = decimal.Zero;

    #endregion Properties
}