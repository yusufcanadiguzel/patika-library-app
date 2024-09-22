using AutoMapper;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;

namespace LibraryApp.MVC.Infastructer.Mappers.AutoMapper
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            //Author mappings
            CreateMap<AuthorSoftDeleteDto, Author>();
        }
    }
}
