using AppointmentSystem.API.DTOs;
using AppointmentSystem.Data.Entities;
using AutoMapper;

namespace AppointmentSystem.API.Mapping;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<CreateAppointmentDto, Appointment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EndTime, opt => opt.Ignore())
            .ForMember(dest => dest.AppUser, opt => opt.Ignore())
            .ForMember(dest => dest.Service, opt => opt.Ignore());


        CreateMap<Appointment, AppointmentResponseDto>();


        CreateMap<CreateServiceDto, Service>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Appointments, opt => opt.Ignore());

        CreateMap<Service, ServiceResponseDto>();


    }

}
