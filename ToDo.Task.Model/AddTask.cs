using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Task.Model
{
    public class AddTask
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Task Message is required")]
        [MinLength(3, ErrorMessage = "Task Message must be at least 3 characters")]
        [StringLength(500  ,ErrorMessage = "Task Message must be more than 500 characters")]
        public string Message { get; set; }
    }

    public class MyTask : AddTask
    {
        public bool IsCompleted { get; set; }
    }

    public class MyTaskList
    {
        public List<MyTask> MyToDoTask { get; set; }
        public List<MyTask> CompletedToDoTask { get; set; }
    }
}
