using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Notifications;
using DesafioBNP.Business.Services;
using DesafioBNP.Data.Context;
using DesafioBNP.Data.Repository;

namespace DesafioBNP.Api.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IFootballTeamRepository, FootballTeamRepository>();

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IFootballTeamService, FootballTeamService>();
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}