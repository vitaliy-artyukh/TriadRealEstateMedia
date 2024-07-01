using AutoMapper;
using Domain.AggregatesModel.ContactAddressAggregate.Models;
using Domain.AggregatesModel.ContactAddressAggregate.Models.Db;

namespace Domain.AggregatesModel.ContactAddressAggregate;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<DbContactAddress, ContactAddress>();
    }
}