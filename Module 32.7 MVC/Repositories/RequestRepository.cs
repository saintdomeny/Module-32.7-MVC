using Microsoft.EntityFrameworkCore;
using Module_32._7_MVC.Models;
using Module_32._7_MVC.Models.Db;
using System;
using System.Threading.Tasks;

namespace Module_32._7_MVC.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task LogRequest(string url)
        {
            var request = new LogRequest
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url
            };

            _context.LogRequests.Add(request);
            await _context.SaveChangesAsync();
        }
        public async Task<LogRequest[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.LogRequests.ToArrayAsync();
        }
    }
}
