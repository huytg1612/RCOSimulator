using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.Repositories;
using RCOSimulator.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Globals
{
    public static class Global
    {
        public static void ConfigureIoC(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IBaseService, BaseService>();
            service.AddScoped<DbContext, RCODbContext>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICardRepository, CardRepository>();
            service.AddScoped<IAccessGroupRepository, AccessGroupRepository>();
            service.AddScoped<IAccessGroupCardRepository, AccessGroupCardRepository>();
            service.AddScoped<LoginService>();
            service.AddScoped<CardService>();
            service.AddScoped<UserService>();
            service.AddScoped<MappingProfile>();
            service.AddScoped<AccessGroupService>();
        }
    }
}
