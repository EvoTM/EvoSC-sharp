using McMaster.Extensions.CommandLineUtils;

namespace EvoSC.CliCommands;

[Command(Name = "run", Description = "Runs the EvoSC application")]
[HelpOption]
public class RunCommand
{
    private readonly IConsole _console;

    public RunCommand(IConsole console)
    {
        _console = console;
    }

    private async Task OnExecute()
    {
        _console.WriteLine("Starting app");
        
        await application.RunAsync();
        application.Dispose();
    }
}
