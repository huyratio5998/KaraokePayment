using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Implement;
using KaraokePayment.DAO.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace KaraokePayment.DAO
{
    public static class RegisterDIDAO
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPhongDAO, PhongDAO>();
            services.AddTransient<IHangHoaDAO, HangHoaDAO>();
            services.AddTransient<IBookPhongOrderDAO, BookPhongOrderDAO>();
            services.AddTransient<IBookPhongOrderPhongDAO, BookPhongOrderPhongDAO>();
            services.AddTransient(typeof(IDAO<>), typeof(DAO<>));
            return services;
        }
    }
}
