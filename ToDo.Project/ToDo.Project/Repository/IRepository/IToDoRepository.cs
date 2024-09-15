using ToDo.Project.Models;

namespace ToDo.Project.Repository.IRepository
{
    public interface IToDoRepository
    {
        Task<List<ToDoList>> GetToDoLists();
        Task<List<ToDoList>> CreateToDo(ToDoList toDoList);
        Task<List<ToDoList>> UpdateToDo(ToDoList toDoList);
        Task<List<ToDoList>> DeleteToDo(int id);
    }
}
