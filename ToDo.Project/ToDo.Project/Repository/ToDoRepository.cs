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

        public async Task<List<ToDoList>> CreateToDo(ToDoList toDoList)
        {
            await dbContext.toDoLists.AddAsync(toDoList);
            await dbContext.SaveChangesAsync();

            return await dbContext.toDoLists.ToListAsync();
        }

        public async Task<List<ToDoList>> UpdateToDo(ToDoList toDoList)
        {
            var updatedToDoList = await dbContext.toDoLists.FirstOrDefaultAsync(x => x.Id == toDoList.Id);

            if (updatedToDoList == null)
            {
                return null;
            }

            updatedToDoList.ToDo = toDoList.ToDo;

            await dbContext.SaveChangesAsync();
            return await dbContext.toDoLists.ToListAsync();
        }
        public async Task<List<ToDoList>> DeleteToDo(int id)
        {
            var deletedToDoList = await dbContext.toDoLists.FirstOrDefaultAsync(x => x.Id == id);

            if(deletedToDoList == null)
            {
                return null;
            }
            dbContext.toDoLists.Remove(deletedToDoList);
            await dbContext.SaveChangesAsync();
            return await dbContext.toDoLists.ToListAsync();
        }
    }
}
