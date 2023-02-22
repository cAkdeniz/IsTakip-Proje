using AutoMapper;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Entities.DTOs.AciliyetDtos;
using IsTakipProject.Entities.DTOs.AppUserDtos;
using IsTakipProject.Entities.DTOs.BildirimDtos;
using IsTakipProject.Entities.DTOs.GorevDtos;
using IsTakipProject.Entities.DTOs.RaporDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Mapping.AutoMapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            #region Aciliyet-AciliyetDto
            CreateMap<AciliyetAddDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetAddDto>();
            CreateMap<AciliyetListDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetListDto>();
            CreateMap<AciliyetUpdateDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Bildirim-BildirimDto
            CreateMap<BildirimListDto, Bildirim>();
            CreateMap<Bildirim, BildirimListDto>();
            #endregion

            #region Gorev-GorevDto
            CreateMap<GorevAddDto, Gorev>();
            CreateMap<Gorev, GorevAddDto>();
            CreateMap<GorevListDto, Gorev>();
            CreateMap<Gorev, GorevListDto>();
            CreateMap<GorevListAllDto, Gorev>();
            CreateMap<Gorev, GorevListAllDto>();
            CreateMap<GorevUpdateDto, Gorev>();
            CreateMap<Gorev, GorevUpdateDto>();
            #endregion

            #region Rapor-RaporDto
            CreateMap<RaporAddDto, Rapor>();
            CreateMap<Rapor, RaporAddDto>();
            CreateMap<RaporUpdateDto, Rapor>();
            CreateMap<Rapor, RaporUpdateDto>();
            CreateMap<RaporPdfDto, Rapor>();
            CreateMap<Rapor, RaporPdfDto>();
            #endregion
        }
    }
}
