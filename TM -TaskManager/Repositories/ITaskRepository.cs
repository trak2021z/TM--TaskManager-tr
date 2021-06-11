using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM__TaskManager.Models;
using TM__TaskManager.Data;

namespace TM__TaskManager.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int taskId);
        IEnumerable<TaskModel> GetAllActive();

        void Add(TaskModel task);
        void Update(int taskId, TaskModel task);
        void Delete(int taskId);
    }
}
