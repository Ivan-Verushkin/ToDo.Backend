using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Project.Models;
using ToDo.Project.Repository.IRepository;

namespace ToDo.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository toDoRepository;
        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDoList>>> GetToDoList()
        {
            var toDos = await toDoRepository.GetToDoLists();

            return toDos.ToList();
        }
    }
}
