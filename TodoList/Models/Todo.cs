using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }

        public Assignee Assignee { get; set; }
        public int? AssigneeID { get; set; }

        public Todo()
        {
            this.CreationDate = DateTime.UtcNow;
        }
    }
}
