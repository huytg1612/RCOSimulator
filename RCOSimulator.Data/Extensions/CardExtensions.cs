using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Extensions
{
    public static class CardExtensions
    {
        public static IQueryable<Card> Get(this IQueryable<Card> query, QueryParameters parameters)
        {
            query = query.Pagination(parameters.Offset, parameters.Limit);
            query = query.Includes(parameters.Include);
            return query;
        }
        public static IQueryable<Card> Includes(this IQueryable<Card> query, string? includes)
        {
            if (string.IsNullOrEmpty(includes)) return query;
            foreach(var include in includes.Split(','))
            {
                switch(include)
                {
                    case "users":
                        query = query.Include(c => c.User);
                        break;
                    case "accessgroups":
                        query = query.Include(c => c.AccessGroups);
                        break;
                    default:
                        break;
                }
            }

            return query;
        }
    }
}
