using Domain.Entities;
using Domain.Exceptions;
using Domain.Gateways.Repositories.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Adapter.Gateways;

internal class CustomerGateway : ICustomerRepository
{
    private readonly CustomerSqlContext _context;
    private readonly DbSet<CustomerSql> _customers;

    public CustomerGateway(CustomerSqlContext customerSqlContext)
    {
        _context = customerSqlContext;
        _customers = customerSqlContext.Customers;
    }

    public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
    {
        var customerSql = new CustomerSql(customer);

        try
        {
            await _customers.AddAsync(customerSql, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e) when (IsUniqueCpfViolation(e))
        {
            throw new DuplicatedCustomerException();
        }

        return customerSql.ToDomain();
    }

    public async Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var customerSql = await _customers
            .AsNoTracking()
            .SingleOrDefaultAsync(customer => customer.Id == id, cancellationToken);

        if (customerSql is null)
        {
            return default!;
        }

        return customerSql.ToDomain();
    }

    public async Task<Customer?> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        var customerSql = await _customers
           .AsNoTracking()
           .SingleOrDefaultAsync(customer => customer.Cpf == cpf, cancellationToken);

        if (customerSql is null)
        {
            return default!;
        }

        return customerSql.ToDomain();
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        var customerSql = new CustomerSql(customer)
        {
            UpdatedAt = DateTime.UtcNow
        };

        _customers.Update(customerSql);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _customers.Where(customer => customer.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    private static bool IsUniqueCpfViolation(DbUpdateException ex)
    {
        if (ex.InnerException is not PostgresException pgEx)
        {
            return false;
        }

        return pgEx.SqlState == PostgresErrorCodes.UniqueViolation && pgEx.ConstraintName?.Contains("cpf") == true;
    }
}
