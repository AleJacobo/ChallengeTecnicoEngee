using ChallengeTecnicoEngee.Services;
using ChallengeTecnicoEngee.Services.Interfaces;

namespace ChallengeTecnicoEngee.API.Configurations
{
    public static class ServiceStartup
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection @this)
        {
            @this.AddTransient<ILogsVisitaService, LogsVisitasService>();
            @this.AddTransient<IEmpleadosService, EmpleadosService>();

            return @this;
        }
    }
}
