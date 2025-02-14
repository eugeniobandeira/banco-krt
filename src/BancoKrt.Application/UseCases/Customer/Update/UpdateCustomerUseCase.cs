using AutoMapper;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;

namespace BancoKrt.Application.UseCases.Customer.Update;

public class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    private readonly IGetByIdCustomerRepository _getByIdCustomerRepository;
    private readonly IUpdateCustomerRepository _updateCustomerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerUseCase(
        IGetByIdCustomerRepository getByIdCustomerRepository,
        IUpdateCustomerRepository updateCustomerRepository,
        IMapper mapper)
    {
        _getByIdCustomerRepository = getByIdCustomerRepository;
        _updateCustomerRepository = updateCustomerRepository;
        _mapper = mapper;
    }
    public async Task<CreatedCustomerResponse> ExecuteAsync(string id, UpdateCustomerRequest req)
    {
        var result = await _getByIdCustomerRepository.GetByIdAsync(id);

        if (result is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND);

        result.TransactionLimit = req.TransactionLimit;

        _mapper.Map(req, result);
        await _updateCustomerRepository.UpdateAsync(result);

        return _mapper.Map<CreatedCustomerResponse>(result);
    }
}
