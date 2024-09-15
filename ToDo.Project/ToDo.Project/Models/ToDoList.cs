using Microsoft.EntityFrameworkCore;

namespace ToDo.Project.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string ToDo { get; set; } = string.Empty;
    }
}
