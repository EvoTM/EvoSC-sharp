using EvoSC;
using EvoSC.CLI;
using McMaster.Extensions.CommandLineUtils;


var app = new CommandLineApplication<Program>
{
    Name = "evosc",
    Description = "A Trackmania Server Controller"
};

app.HelpOption(inherited: true);

var application = new Application();
app.Command("setup", configCmd =>
{
    configCmd.OnExecute(() =>
    {
        Console.WriteLine("Specify a subcommand");
        configCmd.ShowHelp();
        return 1;
    });
});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
    return 1;
});

return app.Execute(args);
/*var app = new CommandLineApplication<Program>();

app.HelpOption();

var subject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
subject.DefaultValue = "world";

var repeat = app.Option<int>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);
repeat.DefaultValue = 1;

app.

app.OnExecuteAsync(async cancellationToken =>
{
    
});

return app.Execute(args);*/
