using System.Threading.Tasks;

namespace Domain.Customers
{
    internal interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId id);
    }
}
