using AutoMapper;
namespace TroyLeeMVCEF.Mappers
{
    using TroyLeeMVCEF.Domain.Entities;
    using TroyLeeMVCEF.Models;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}