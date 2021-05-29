using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM__TaskManager.Models;
using TM__TaskManager.Data;

namespace TM__TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public TaskModel Get(int taskId)

            => _context.Tasks.SingleOrDefault(x => x.TaskID == taskId);


        public IQueryable<TaskModel> GetAllActive()
        {
            return _context.Tasks;
        }

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int taskId)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskID == taskId);
            if (result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(int taskId, TaskModel task)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskID == taskId);
            if (result != null)
            {
                result.TaskName = task.TaskName;
                result.Description = task.Description;
                _context.SaveChanges();
            }
        }
    }
}
