using System.IO;
using MyHttpServer.Framework.Attributes;

namespace MyHttpServer.Controllers
{
    [HttpController("login")]
    public class AuthController
    {
        
        [Get("")]
        public string Login()
        {
            string filePath = Path.GetFullPath(Path.Combine( AppContext.BaseDirectory,"..", "..", "..", "Static", "Steam", "Steam.html"));

            if (!File.Exists(filePath))
            {
                return "<h1>Файл login.html не найден</h1>";
            }

            return File.ReadAllText(filePath);
        }

        [Post("")]
        public string SubmitLogin(string login, string password)
        {
            Console.WriteLine("Получены данные формы входа:");
            Console.WriteLine($"Логин: {login}");
            Console.WriteLine($"Пароль: {password}");

            return Login();
        }


    }
}