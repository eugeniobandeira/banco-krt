using AutoMapper;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;

namespace BancoKrt.Application.UseCases.Customer.GetById;

public class GetByIdCustomerUseCase : IGetByIdCustomerUseCase
{
    private readonly IGetByIdCustomerRepository _getByIdCustomerRepository;
    private readonly IMapper _mapper;

    public GetByIdCustomerUseCase(
        IGetByIdCustomerRepository getByIdCustomerRepository,
        IMapper mapper)
    {
        _getByIdCustomerRepository = getByIdCustomerRepository;
        _mapper = mapper;
    }
    public async Task<CreatedCustomerResponse> ExecuteAsync(string id)
    {
        var result = await _getByIdCustomerRepository.GetByIdAsync(id);

        return result is null
            ? throw new NotFoundException(ErrorMessageResource.NOT_FOUND)
            : _mapper.Map<CreatedCustomerResponse>(result);
    }
}
