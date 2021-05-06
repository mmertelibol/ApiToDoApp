using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAPI.Entities
{
    [Table(name:("ToDos"))]
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string TodoText { get; set; }
        public string AddedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get; set; } 

    }
}
