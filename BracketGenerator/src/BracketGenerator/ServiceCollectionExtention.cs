using BracketGenerator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BracketGenerator.Services;

namespace BracketGenerator
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServiceMapppings(this IServiceCollection services) => services
            .AddScoped<IBracketTournamentFactory, BracketTournamentFactory>()
            .AddScoped<IGroupStageService, GroupStageService>()
            .AddScoped<ISingleEliminationService, SingleEliminationService>()
            .AddScoped<ITournamentGenerator, TournamentGenerator>();

    }
}
