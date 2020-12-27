using AutoMapper;
using System.Linq;
using WMI_NetCore_API.Controllers.Resources;
using WMI_NetCore_API.Core.Models;
namespace WMI_NetCore_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<WMIModel, WMIResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<WMIResource, WMIModel>();

        }
    }
}