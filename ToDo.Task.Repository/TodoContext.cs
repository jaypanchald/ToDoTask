using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDo.Task.Model;

namespace ToDo.Task.Repository
{
    public class TodoContext : DbContext
    {
        private readonly IOptions<ConnectionStringOption> _conStrOptions;
        private readonly string connectionString;

        public TodoContext() : base() { }
        public TodoContext(IOptions<ConnectionStringOption> conStrOptions, DbContextOptions options) : base(options)
        {
            _conStrOptions = conStrOptions;
            connectionString = _conStrOptions.Value.ConnectionString;
        }

        public DbSet<Model.Entity.MyTask> MyTask { get; set; }



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
