using AutoMapper;
using WorkoutTracker.Models;
using WorkoutTracker.DTOs;

namespace WorkoutTracker.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkoutSession, WorkoutSessionDto>();
        CreateMap<Set, SetDto>();
    }
}