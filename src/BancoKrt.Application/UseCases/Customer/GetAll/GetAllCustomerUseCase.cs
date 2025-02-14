using AutoMapper;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.GetAll;

public class GetAllCustomerUseCase : IGetAllCustomerUseCase
{
    private readonly IGetAllCustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomerUseCase(
        IGetAllCustomerRepository getAllCustomerRepository,
        IMapper mapper)
    {
        _repository = getAllCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseList> ExecuteAsync()
    {
        var result = await _repository.GetAllAsync();
        return new CustomerResponseList
        {
            Customers = _mapper.Map<List<CreatedCustomerResponse>>(result)
        };
    }
}
