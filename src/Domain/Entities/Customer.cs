using Domain.Entities.Exceptions;
using Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

public class Customer
{
    private int? _id;
    private string? _name;
    private Cpf _cpf;
    private Email? _email;

    public int Id
    {
        get => _id ?? default;
        set
        {
            CustomerPropertyException.ThrowIfNull<int>(value, nameof(Id));

            _id = value;
        }
    }

    public DateTime CreatedAt { get; private set; }

    public required string Name
    {
        get => _name!;
        set
        {
            CustomerPropertyException.ThrowIfNullOrWhiteSpace(value, nameof(Name));

            _name = value;
        }
    }

    public required Cpf Cpf
    {
        get => _cpf;
        set => _cpf = value;
    }

    public Email? Email
    {
        get => _email!;
        private set => _email = value;
    }

    public DateTime? UpdatedAt { get; private set; }

    [SetsRequiredMembers]
    public Customer(string name, string cpf, string? email)
    {
        CreatedAt = DateTime.UtcNow;
        Name = name;
        Cpf = cpf;
        SetEmail(email);
    }

    [SetsRequiredMembers]
    public Customer(int id, DateTime createdAt, string name, string cpf, string? email = null, DateTime? updatedAt = null)
        : this(name, cpf, email)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public void Update(string? name = null, string? email = null)
    {
        UpdatedAt = DateTime.UtcNow;

        if (string.IsNullOrWhiteSpace(name) is false)
        {
            Name = name;
        }

        SetEmail(email);
    }

    private void SetEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email) is false)
        {
            _email = new Email(email);
        }
    }
}
