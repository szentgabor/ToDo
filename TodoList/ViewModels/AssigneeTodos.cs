using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AssigneeTodos
    {
        public Assignee AssigneeSelected { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
