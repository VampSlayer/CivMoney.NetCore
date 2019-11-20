using AutoMapper;
using CivMoney.DataAccess.Models;

namespace CivMoney.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
