namespace CrmSystem.Domain.Entities;

public class Product : Entity
{
    #region Properties

    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Cost { get; private set; }

    #endregion Properties

    #region Constructors

    public Product(string name, decimal price, decimal cost)
    {
        Name = name;
        Price = price;
        Cost = cost;
    }

    #endregion Constructors
}