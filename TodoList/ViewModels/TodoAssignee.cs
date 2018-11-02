using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoAssignee
    {
        public List<Assignee> Assignees { get; set; }
        public List<Todo> Todos { get; set; }
        public Todo TodoSelected { get; set; }
    }
}
