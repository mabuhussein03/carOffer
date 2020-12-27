using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WMI_NetCore_API.Core.Models;
using System.Globalization;
namespace WMI_NetCore_API.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<WMIModel> ApplyFiltering(this IQueryable<WMIModel> query, string filter, string country)
        {
            if (String.IsNullOrEmpty(filter) && String.IsNullOrEmpty(country))
                return query;
            filter = filter?.ToLower();
            return query.Where(x => string.IsNullOrEmpty(country) || x.Country == country)
                .Where(x => string.IsNullOrEmpty(filter)
                || (x.Country != null && x.Country.ToLower().Contains(filter))
                || (x.WMI != null && x.WMI.ToLower().Contains(filter))
                || (x.VehicleType != null && x.VehicleType.ToLower().Contains(filter))
                || (x.Name != null && x.Name.ToLower().Contains(filter))
                || (x.CreatedOn != null && x.CreatedOn.ToString().ToLower().Contains(filter))
                || (x.Id > 0 && x.Id.ToString().ToLower().Contains(filter))
                );
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }


        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}