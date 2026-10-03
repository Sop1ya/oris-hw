using System.Collections.Generic;

namespace MyHttpServer
{
    internal static class ContentTypes
    {
        public static readonly Dictionary<string, string> Types =
            new Dictionary<string, string>
            {
                // HTML
                { ".html", "text/html;charset=utf-8" },
                { ".htm", "text/html;charset=utf-8" },

                // CSS
                { ".css", "text/css" },

                // JavaScript
                { ".js", "text/javascript" },

                // JSON
                { ".json", "application/json" },

                // Изображения
                { ".png", "image/png" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".gif", "image/gif" },
                { ".svg", "image/svg+xml" },
                { ".webp", "image/webp" },
                { ".ico", "image/x-icon" },

                // Текст
                { ".txt", "text/plain" },

                // PDF
                { ".pdf", "application/pdf" },

                // Аудио
                { ".mp3", "audio/mpeg" },
                { ".wav", "audio/wav" },
                { ".ogg", "audio/ogg" },

                // Видео
                { ".mp4", "video/mp4" },
                { ".webm", "video/webm" },

                // Шрифты
                { ".woff", "font/woff" },
                { ".woff2", "font/woff2" },
                { ".ttf", "font/ttf" },
                { ".otf", "font/otf" }
            };
    }
}