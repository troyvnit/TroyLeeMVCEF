using AutoMapper;
namespace TroyLeeMVCEF.Mappers
{
    using TroyLeeMVCEF.Domain.Entities;
    using TroyLeeMVCEF.Models;

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserViewModel>();
        }
    }
}