using AutoMapper;
using Braveior.BuddyRewards.DTO;
using Braveior.BuddyRewards.Services.Models;
using System.Linq;

namespace Braveior.BuddyRewards.API.Mapping
{
    /// <summary>
    /// Auto Mapper Mapping Configuration
    /// </summary>
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            //Mapping the Member MongoDB entity to the MemberDTO. 
            CreateMap<Member, MemberDTO>();

            //Mapping the Rating MongoDB Entity to the RatingDTO. Mapping the Member ID for RatedByRef and RatedForRef in DTO from One to One Mapping in Entity
            CreateMap<Rating, RatingDTO>()
            .ForMember(dest => dest.RatedByRef, opt => opt.MapFrom(src => src.RatedByRef.ID))
            .ForMember(dest => dest.RatedForRef, opt => opt.MapFrom(src => src.RatedForRef.ID));
        }
    }
}
