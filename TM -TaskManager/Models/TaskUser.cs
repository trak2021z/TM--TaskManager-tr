using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TM__TaskManager.Models
{
    public class TaskUser
    {

        public int TaskUserID { get; set; }

        public int UserID { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}
