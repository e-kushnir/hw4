using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TODO_List.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}