﻿using AutoMapper;

namespace Volo.Abp.Identity
{
    public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public AbpIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentityUser, IdentityUserDto>();
        }
    }
}