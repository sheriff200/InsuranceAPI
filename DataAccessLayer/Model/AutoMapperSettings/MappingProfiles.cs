using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Model.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.AutoMapperSettings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PolicyHolderClaimRequest, PolicyHolders>().ReverseMap();
            CreateMap<PolicyHolderClaimRequest, Claims>().ReverseMap();
        }
    }
}
