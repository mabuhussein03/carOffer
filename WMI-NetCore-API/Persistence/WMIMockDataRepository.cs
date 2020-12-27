using WMI_NetCore_API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WMI_NetCore_API.Core.Models;
using WMI_NetCore_API.Extensions;
using Newtonsoft.Json;
using System.IO;

namespace WMI_NetCore_API.Persistence
{
    public class WMIMockDataRepository : IWMIRepository
    {

        private readonly System.IO.StreamReader file = System.IO.File.OpenText(@"Data/honda_wmi.json");


        public async Task<List<string>> GetCountries()
        {
            var WMIlist = JsonConvert.DeserializeObject<List<WMIModel>>(file.ReadToEnd());
            var countries = WMIlist.GroupBy(x => x.Country).Select(x => x.Key).ToList();
            return countries;
        }
        public async Task<QueryResult<WMIModel>> GetFilterdWMI(string search, string country)
        {
            var result = new QueryResult<WMIModel>();
            var query = JsonConvert.DeserializeObject<List<WMIModel>>(file.ReadToEnd()).AsQueryable();
            query = query.ApplyFiltering(search, country);
            result.TotalItems = query.Count();
            result.Items = query.ToList();
            return result;
        }
        public async Task<QueryResult<WMIModel>> GetAllWMI()
        {
            var result = new QueryResult<WMIModel>();

            var query = JsonConvert.DeserializeObject<List<WMIModel>>(file.ReadToEnd()).AsQueryable();
            result.TotalItems = query.Count();

            result.Items = query.ToList();

            return result;

        }

    }
}