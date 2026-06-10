#nullable enable
using CargoFlow.Business.DTOs.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoFlow.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        Task<CustomerDto?> GetByIdAsync(int id);

        Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto);

        Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto updateCustomerDto);

        Task DeleteAsync(int id);
    }
}
