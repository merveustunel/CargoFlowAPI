#nullable enable
using CargoFlow.Business.Abstract;
using CargoFlow.Business.DTOs.Customers;
using CargoFlow.DataAccess.Interfaces;
using CargoFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoFlow.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(MapToDto);
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer is null ? null : MapToDto(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto)
        {
            ValidateCreateCustomer(createCustomerDto);

            var customer = new Customer
            {
                FirstName = createCustomerDto.FirstName.Trim(),
                LastName = createCustomerDto.LastName.Trim(),
                Email = createCustomerDto.Email.Trim(),
                PhoneNumber = createCustomerDto.PhoneNumber.Trim(),
                CreatedDate = DateTime.UtcNow
            };

            var addedCustomer = await _customerRepository.AddAsync(customer);
            return MapToDto(addedCustomer);
        }

        public async Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto updateCustomerDto)
        {
            ValidateUpdateCustomer(updateCustomerDto);

            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer is null)
            {
                throw new KeyNotFoundException($"Customer with id {id} was not found.");
            }

            existingCustomer.FirstName = updateCustomerDto.FirstName.Trim();
            existingCustomer.LastName = updateCustomerDto.LastName.Trim();
            existingCustomer.Email = updateCustomerDto.Email.Trim();
            existingCustomer.PhoneNumber = updateCustomerDto.PhoneNumber.Trim();

            await _customerRepository.UpdateAsync(existingCustomer);
            return MapToDto(existingCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer is null)
            {
                throw new KeyNotFoundException($"Customer with id {id} was not found.");
            }

            await _customerRepository.DeleteAsync(existingCustomer);
        }

        private static void ValidateCreateCustomer(CreateCustomerDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
            {
                throw new ArgumentException("Customer first name is required.", nameof(dto.FirstName));
            }

            if (string.IsNullOrWhiteSpace(dto.LastName))
            {
                throw new ArgumentException("Customer last name is required.", nameof(dto.LastName));
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new ArgumentException("Customer email is required.", nameof(dto.Email));
            }
        }

        private static void ValidateUpdateCustomer(UpdateCustomerDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
            {
                throw new ArgumentException("Customer first name is required.", nameof(dto.FirstName));
            }

            if (string.IsNullOrWhiteSpace(dto.LastName))
            {
                throw new ArgumentException("Customer last name is required.", nameof(dto.LastName));
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new ArgumentException("Customer email is required.", nameof(dto.Email));
            }
        }

        private static CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                CreatedDate = customer.CreatedDate
            };
        }
    }
}
