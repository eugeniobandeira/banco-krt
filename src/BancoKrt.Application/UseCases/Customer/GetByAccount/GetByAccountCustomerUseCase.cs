using AutoMapper;
using BancoKrt.Application.UseCases.Customer.GetById;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;

namespace BancoKrt.Application.UseCases.Customer.GetByAccount;

public class GetByAccountCustomerUseCase : IGetByAccountCustomerUseCase
{
    private readonly IGetByAccountCustomerRepository _getByAccountCustomerRepository;
    private readonly IMapper _mapper;

    public GetByAccountCustomerUseCase(
        IGetByAccountCustomerRepository getByAccountCustomerRepository,
        IMapper mapper)
    {
        _getByAccountCustomerRepository = getByAccountCustomerRepository;
        _mapper = mapper;
    }
    public async Task<CreatedCustomerResponse> ExecuteAsync(string accountNumber)
    {
        var result = await _getByAccountCustomerRepository.GetByAccountAsync(accountNumber);

        return result is null
            ? throw new NotFoundException(ErrorMessageResource.ACCOUNT_NOT_FOUND)
            : _mapper.Map<CreatedCustomerResponse>(result);
    }
}
