using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _contex;

    public CustomerRepository(ApplicationDbContext context)
    {
        _contex = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Customers customers) => await _contex.Customers.AddAsync(customers);

    public async Task<Customers?> GetByIdAsync(CustomersId id) => await _contex.Customers.SingleOrDefaultAsync(c => c.Id == id);
}