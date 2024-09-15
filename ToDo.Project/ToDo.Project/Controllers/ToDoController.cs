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

        [HttpPost]
        public async Task<ActionResult<List<ToDoList>>> AddToDoList([FromBody] string toDoList)
        {
            try
            {
                var newToDoList = new ToDoList() { ToDo = toDoList };

                var toDoLists = await toDoRepository.CreateToDo(newToDoList);

                return toDoLists.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<ToDoList>>> UpdateToDoList([FromBody] ToDoList toDoList)
        {
            try
            {
                var updatedToDoList = await toDoRepository.UpdateToDo(toDoList);

                if (updatedToDoList == null)
                {
                    return NotFound();
                }
                return await toDoRepository.GetToDoLists();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<List<ToDoList>>> DeleteToDoList([FromRoute] int id)
        {
            try
            {
                var toDoLists = await toDoRepository.DeleteToDo(id);
                if (toDoLists == null)
                {
                    return NotFound();
                }
                return toDoLists.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
