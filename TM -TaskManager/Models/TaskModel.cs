using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TM__TaskManager.Models
{   
    [Table("Tasks")]
    public class TaskModel
    {

        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [MaxLength(50)]
        [DisplayName("Nazwa")]
        public string TaskName { get; set; }

        [MaxLength(2000)]
        [DisplayName("Opis")]
        public string Description { get; set; }

        public string UserID { get; set; }

    }
}
