using Microsoft.EntityFrameworkCore;
using ToDo.Task.Model.Entity;

namespace ToDo.Task.Repository
{
    public class TodoContext : DbContext
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ToDoTask;Trusted_Connection=True;MultipleActiveResultSets=true";

        public TodoContext() : base() { }
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyTask> MyTask { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);



        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            // builder.Entity<MyTask>();
        }
    }
}
