namespace Domain.Customers;
public interface ICustomerRepository
{
    Task<Customers?> GetByIdAsync(CustomersId id);
    Task Add(Customers customers);
}