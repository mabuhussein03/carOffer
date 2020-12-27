using WMI_NetCore_API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WMI_NetCore_API.Core.Models;
using WMI_NetCore_API.Extensions;
namespace WMI_NetCore_API.Persistence
{
    public class WMIRepository : IWMIRepository
    {
        private readonly WMIDbContext context;

        public WMIRepository(WMIDbContext context)
        {
            this.context = context;
        }

        public async Task<List<string>> GetCountries()
        {
            var WMIlist = await context.WMI.GroupBy(x => x.Country).Select(x => x.Key).ToListAsync();
            return WMIlist;

        }
        public async Task<QueryResult<WMIModel>> GetFilterdWMI(string search, string country)
        {
            var result = new QueryResult<WMIModel>();
            var query = context.WMI
              .AsQueryable();
            query = query.ApplyFiltering(search, country);
            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();
            return result;
        }
        public async Task<QueryResult<WMIModel>> GetAllWMI()
        {
            var result = new QueryResult<WMIModel>();

            var query = context.WMI
              .AsQueryable();
            result.TotalItems = await query.CountAsync();

            result.Items = await query.ToListAsync();

            return result;

        }

    }
}