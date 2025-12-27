using Domain.Entities.Exceptions;
using Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

public class Customer
{
    private int? _id;
    private string? _name;
    private string? _cpf;
    private string? _email;

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
        get => _cpf!;
        set
        {
            CustomerPropertyException.ThrowIfNullOrWhiteSpace(value, nameof(Cpf));

            _cpf = value;
        }
    }

    public required Email? Email
    {
        get => _email!;
        set
        {
            if (string.IsNullOrWhiteSpace(value) is false)
            {
                _email = value;
            }
        }
    }

    public DateTime? UpdatedAt { get; private set; }

    [SetsRequiredMembers]
    public Customer(string name, Cpf cpf, Email? email)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
    }

    public Customer(int id, DateTime createdAt, DateTime? updatedAt = null)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
