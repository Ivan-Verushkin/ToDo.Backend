using ToDo.Project.Models;

namespace ToDo.Project.Repository.IRepository
{
    public interface IToDoRepository
    {
        Task<List<ToDoList>> GetToDoLists();
    }
}
