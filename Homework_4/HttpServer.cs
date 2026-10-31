using System.Net;
using MyHttpServer.Framework.Handlers;

namespace MyHttpServer
{
    public class HttpServer
    {
        private HttpListener server;
        private string urlPrefix;
        private string serverPath;
        private string rootPath;
        private string staticPath;
        private Handler controllerHandler;
        public HttpServer(string host, string port, string path, Dictionary<string, string> pages)
        {
            server = new HttpListener();
            serverPath = path.Trim('/');
            urlPrefix = $"http://{host}:{port}/{serverPath}/";
            server.Prefixes.Add(urlPrefix);
            rootPath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
            staticPath = Path.Combine(rootPath, "Static");
            controllerHandler = new ControllerHandler();
            var staticFileHandler = new StaticFileHandler(staticPath, rootPath, pages);
            controllerHandler.SetSuccessor(staticFileHandler);
            // Console.WriteLine("Корневая папка: " + rootPath);
        }
   
        public Task Start()
        {
            server.Start();

            Console.WriteLine("IsListening: " + server.IsListening);

            foreach (string prefix in server.Prefixes)
            {
                Console.WriteLine("Prefix: " + prefix);
            }

            return StartAsync();
        }

        public void Stop()
        {
            server.Stop();

            Console.WriteLine("Сервер остановлен");
        }

        private async Task StartAsync()
        {
            try
            {
                while (true)
                {
                    var context = await server.GetContextAsync();

                    Console.WriteLine(
                        $"Получен запрос: {context.Request.HttpMethod} " +
                        $"{context.Request.Url?.AbsolutePath}");
                    //Console.WriteLine("передаем запрос в хендлер");
                    await controllerHandler.HandleRequest(context);

                    //Console.WriteLine("хендлер завершил обработку");
                }
            }
            catch (HttpListenerException)
            {
                Console.WriteLine("Сервер завершил работу");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Ошибка сервера: {ex.Message}"
                );
            }
        }
    }
}