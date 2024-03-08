namespace CrmSystem.Application.Dto.Person;

public class PersonPaymentDto
{
    #region Properties

    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PersonIdentificationDto Identification { get; private set; }

    #endregion Properties

    #region Constructors

    public PersonPaymentDto(
        string email,
        string firstName,
        string lastName,
        PersonIdentificationDto identification)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Identification = identification;
    }

    #endregion Constructorsi
}

public class PersonIdentificationDto
{
    #region Properties

    public string Type { get; private set; }
    public string Document { get; set; }

    #endregion Properties

    #region Constructors

    public PersonIdentificationDto(string document)
    {
        Document = document;

        Type = document.Length <= 11 ? "CPF" : "CNPJ";
    }

    #endregion Constructors
}