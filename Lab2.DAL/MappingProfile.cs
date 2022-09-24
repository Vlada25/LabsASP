using AutoMapper;
using Lab2.DAL.Extensions;
using Lab2.DAL.Models;
using Lab2.DTO.Fault;
using Lab2.DTO.RepairingModel;
using Lab2.DTO.SparePart;
using Lab2.DTO.UsedSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RepairingModel, RepairingModelDto>()
                .ForMember(rm => rm.Type, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Type)));
            CreateMap<RepairingModelForCreationDto, RepairingModel>()
                .ForMember(rm => rm.Type, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.Type)));
            CreateMap<RepairingModelForUpdateDto, RepairingModel>()
                .ForMember(rm => rm.Type, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.Type)));

            CreateMap<Fault, FaultDto>()
                .ForMember(f => f.RepairingModelName, opt => opt.MapFrom(x => x.RepairingModel.Name))
                .ForMember(f => f.RepairingModelSpecifications, opt => opt.MapFrom(x => x.RepairingModel.Specifications));
            CreateMap<FaultForCreationDto, Fault>();
            CreateMap<FaultForUpdateDto, Fault>();

            CreateMap<SparePart, SparePartDto>()
                .ForMember(sp => sp.EquipmentType, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.EquipmentType)));
            CreateMap<SparePartForCreationDto, SparePart>()
                .ForMember(sp => sp.EquipmentType, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.EquipmentType)));
            CreateMap<SparePartForUpdateDto, SparePart>()
                .ForMember(sp => sp.EquipmentType, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.EquipmentType)));

            CreateMap<UsedSparePart, UsedSparePartDto>()
                .ForMember(usp => usp.FaultName, opt => opt.MapFrom(x => x.Fault.Name))
                .ForMember(usp => usp.FaultPrice, opt => opt.MapFrom(x => x.Fault.Price))
                .ForMember(usp => usp.SparePartName, opt => opt.MapFrom(x => x.SparePart.Name))
                .ForMember(usp => usp.SparePartPrice, opt => opt.MapFrom(x => x.SparePart.Price));
            CreateMap<UsedSparePartForCreationDto, UsedSparePart>();
            CreateMap<UsedSparePartForUpdateDto, UsedSparePart>();
        }
    }
}
