using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Task.Model.Entity
{
    public class MyTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedTime { get; set; }
       
    }
}
