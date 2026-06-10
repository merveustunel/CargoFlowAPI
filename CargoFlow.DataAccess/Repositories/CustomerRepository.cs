#nullable enable
using CargoFlow.DataAccess.Interfaces;
using CargoFlow.Entities;

namespace CargoFlow.DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CargoFlowDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
