using Application.Common.Persistence;
using Domain.Catalog;
using Infrastrcture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Persistance
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> ListAsync()
        {
            return await _context.Todo.ToListAsync();
        }
    }
}
