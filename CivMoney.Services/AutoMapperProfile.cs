using AutoMapper;
using CivMoney.DataAccess.Models;
using CivMoney.Services.Dtos;

namespace CivMoney.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<Transaction, TransactionRangeDto>().ForMember(d => d.Delete, o => o.MapFrom(src => src.Id));
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
