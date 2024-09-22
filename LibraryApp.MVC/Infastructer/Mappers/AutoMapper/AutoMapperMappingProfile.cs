using AutoMapper;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
using LibraryApp.MVC.ViewModels;

namespace LibraryApp.MVC.Infastructer.Mappers.AutoMapper
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            //Author mappings
            CreateMap<AuthorSoftDeleteDto, Author>();
            CreateMap<AuthorDetailsViewModel, Author>().ReverseMap();

            //Book mappings
            CreateMap<BookSoftDeleteDto, Book>();
        }
    }
}
