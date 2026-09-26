using System.Text.Json;
using MyHttpServer;

string settingsJson = File.ReadAllText("settings.json");

Settings settings = JsonSerializer.Deserialize<Settings>(settingsJson);

HttpServer server = new HttpServer(
    settings.Server.Host,
    settings.Server.Port,
    settings.Server.Path
);

Task serverTask = server.Start();

while (true)
{
    string command = Console.ReadLine();

    if (command == "stop")
    {
        server.Stop();
        break;
    }
}