using AutoMapper;
using SalesPro.Plugin.EmailSync.DTOs;
using SalesPro.Plugin.EmailSync.Entities;

namespace SalesPro.Plugin.EmailSync.Configuration;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ImapAccount, ImapAccountCreateDto>().ReverseMap();
        CreateMap<ImapAccount, ImapAccountUpdateDto>()
            .ForAllMembers(m => m.Condition(PropertyNeedsMapping));
        CreateMap<ImapAccountUpdateDto, ImapAccount>()
            .ForAllMembers(m => m.Condition(PropertyNeedsMapping));
        CreateMap<ImapAccount, ImapAccountDetailsDto>();
    }

    private static bool PropertyNeedsMapping(object source, object target, object sourceValue, object targetValue)
    {
        return sourceValue != null;
    }
}