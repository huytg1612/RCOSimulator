using AutoMapper;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Globals
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AccessGroup, AccessGroupModel>();
            CreateMap<AccessGroupModel, AccessGroup>();

            CreateMap<CardModel, Card>().ForMember(des => des.UserId, act => act.MapFrom(src => src.FkUserNumber));
            CreateMap<Card, CardModel>().ForMember(des => des.FkUserNumber, act => act.MapFrom(src => src.UserId));

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<CardAssignmentModel, AccessGroupCard>()
                .ForMember(des => des.CardId, act => act.MapFrom(src => src.CardId))
                .ForMember(des => des.AccessGroupId, act => act.MapFrom(src => src.AccessGroupId));
            CreateMap<AccessGroupCard, CardAssignmentModel>()
                .ForMember(des => des.CardId, act => act.MapFrom(src => src.CardId))
                .ForMember(des => des.AccessGroupId, act => act.MapFrom(src => src.AccessGroupId));
        }
    }
}
