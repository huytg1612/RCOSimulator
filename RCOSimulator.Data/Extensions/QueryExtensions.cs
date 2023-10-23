using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T>Pagination<T>(this IQueryable<T> cards, int? offset, int? limit)
        {
            if (offset.HasValue)
                cards = cards.Skip(offset.Value);
            if (limit.HasValue)
                cards = cards.Take(limit.Value);

            return cards;
        }
    }
}
