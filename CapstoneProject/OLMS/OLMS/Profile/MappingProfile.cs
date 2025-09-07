using AutoMapper;
using OLMS.Models;
using OLMS.DTO;



public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Assignment mappings
        CreateMap<AssignmentDto, Assignments>();
       

        // If you later add UpdateDto
        // CreateMap<AssignmentUpdateDto, Assignment>();
    }
}
