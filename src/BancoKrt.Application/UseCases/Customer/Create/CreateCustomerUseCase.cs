using AutoMapper;
using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Exception.ExceptionBase;

namespace BancoKrt.Application.UseCases.Customer.Register;

public class CreateCustomerUseCase : ICreateCustomerUseCase
{
    private readonly ICreateCustomerRepository _createCustomerRepository;
    private readonly IGetByAccountCustomerRepository _getByAccountCustomerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerUseCase(
        ICreateCustomerRepository createCustomerRepository,
        IGetByAccountCustomerRepository getByAccountCustomerRepository,
        IMapper mapper
        )
    {
        _createCustomerRepository = createCustomerRepository;
        _getByAccountCustomerRepository = getByAccountCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCustomerResponse> ExecuteAsync(CreateCustomerRequest req)
    {
        await ValidateRequest(req);

        var entity = _mapper.Map<CustomerEntity>(req);

        await _createCustomerRepository.AddAsync(entity);

        return _mapper.Map<CreatedCustomerResponse>(entity);
    }

    private async Task ValidateRequest(CreateCustomerRequest req)
    {
        var isAccountAlreadyRegistered =  await _getByAccountCustomerRepository.GetByAccountAsync(req.AccountNumber);

        if (isAccountAlreadyRegistered is not null)
            throw new ArgumentException("Account number already in use");

        var validator = new CustomerValidator();

        var result = validator.Validate(req);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
