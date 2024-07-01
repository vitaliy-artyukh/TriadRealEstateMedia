using AutoMapper;
using Domain.AggregatesModel.ContactAggregate.Models;
using Domain.AggregatesModel.ContactAggregate.Models.Db;

namespace Domain.AggregatesModel.ContactAggregate;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<DbContact, Contact>();
    }
}