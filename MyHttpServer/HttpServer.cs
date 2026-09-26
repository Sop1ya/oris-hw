using System.Net;
using System.Text;

namespace MyHttpServer;

public class HttpServer
{
    private HttpListener server = new HttpListener();
    private string urlPrefix;
    public HttpServer(string host, string port, string path)
    {
        urlPrefix = $"http://{host}:{port}/{path}/";
        server.Prefixes.Add(urlPrefix);
    }

    public async Task Start()
    {
        server.Start();

        Console.WriteLine("Сервер работает и слушает " + urlPrefix);

        while (true)
        {
            var context = await server.GetContextAsync();

            var response = context.Response;

            string htmlFileText = File.ReadAllText("search-engine.html");

            byte[] buffer = Encoding.UTF8.GetBytes(htmlFileText);

            response.ContentLength64 = buffer.Length;

            using Stream output = response.OutputStream;

            await output.WriteAsync(buffer);
            await output.FlushAsync();

            Console.WriteLine("Запрос обработан");
        }
    }

    public void Stop()
    {
        server.Stop();

        Console.WriteLine("Сервер завершил работу");
    }
}