using ToDo.Task.Model.Entity;

namespace ToDo.Task.Repository.Repository
{
    public interface IMyTaskRepository : IRepository<MyTask>
    { }

    public class MyTaskRepository : Repository<MyTask>, IMyTaskRepository
    {
        private readonly TodoContext _contex;

        public MyTaskRepository(TodoContext contex) : base(contex)
        {
            _contex = contex;
        }

    }
}
