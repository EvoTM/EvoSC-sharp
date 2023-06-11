using EvoSC.Common.Controllers;
using EvoSC.Common.Interfaces.Controllers;
using McMaster.Extensions.CommandLineUtils;
using SimpleInjector;

namespace EvoSC.CliCommands;

public static class CliCommandsServiceExtensions
{
    public static Container AddEvoScCli(this Container services)
    {
        services.RegisterInstance(PhysicalConsole.Singleton);
        
        return services;
    }
}
