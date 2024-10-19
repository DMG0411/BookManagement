using AutoMapper;

namespace Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Book, DTOs.BookDto>().ReverseMap();
        }
    }
}
