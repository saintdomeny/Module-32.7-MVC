﻿using Microsoft.AspNetCore.Http;
using Module_32._7_MVC.Repositories;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Module_32._7_MVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _requestRepository;
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository requestRepository)
        {
            _next = next;
            _requestRepository = requestRepository;
        }
        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            if (!File.Exists(logFilePath))
            {
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

                // Create the file if it doesn't exist
                using (var fileStream = File.Create(logFilePath)) { }
            }
            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogFile(context);
            await _requestRepository.LogRequest($"http://{context.Request.Host.Value + context.Request.Path}");
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
