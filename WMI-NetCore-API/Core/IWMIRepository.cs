using System.Collections.Generic;
using System.Threading.Tasks;
using WMI_NetCore_API.Core.Models;
namespace WMI_NetCore_API.Core
{
    public interface IWMIRepository
    {
        Task<List<string>> GetCountries();
        Task<QueryResult<WMIModel>> GetAllWMI();
        Task<QueryResult<WMIModel>> GetFilterdWMI(string filter, string country);
    }
}