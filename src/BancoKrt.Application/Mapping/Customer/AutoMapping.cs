using AutoMapper;
using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.Mapping.Customer;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<CreateCustomerRequest, CustomerEntity>()
            .ForMember(
                entity => entity.Id,
                opt => 
                    opt.MapFrom(src => Guid.NewGuid().ToString()));
    }

    private void EntityToResponse()
    {
        CreateMap<CustomerEntity, CreatedCustomerResponse>();
    }
}
