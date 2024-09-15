using Microsoft.EntityFrameworkCore;
using ToDo.Project.Data;
using ToDo.Project.Models;
using ToDo.Project.Repository.IRepository;

namespace ToDo.Project.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext dbContext;
        public ToDoRepository(DataContext dataContext)
        {
            dbContext = dataContext;
        }
        public async Task<List<ToDoList>> GetToDoLists()
        {
            return await dbContext.toDoLists.ToListAsync();
        }
    }
}
