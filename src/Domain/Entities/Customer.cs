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
        get => _id!.Value;
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

    public required Email Email
    {
        get => _email!;
        set
        {
            CustomerPropertyException.ThrowIfNullOrWhiteSpace(value, nameof(Email));

            _email = value;
        }
    }

    [SetsRequiredMembers]
    public Customer(string name, Cpf cpf, Email email)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
    }

    public Customer(int id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }
}
