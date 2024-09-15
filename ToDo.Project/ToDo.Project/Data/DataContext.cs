using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using ToDo.Project.Models;

namespace ToDo.Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDoList> toDoLists => Set<ToDoList>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ToDo1 = new ToDoList() { Id=1, ToDo = "Sing a song" };
            var ToDo2 = new ToDoList() { Id = 2,ToDo = "Cleane a house" };

            modelBuilder.Entity<ToDoList>().HasData(ToDo1);
            modelBuilder.Entity<ToDoList>().HasData(ToDo2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
