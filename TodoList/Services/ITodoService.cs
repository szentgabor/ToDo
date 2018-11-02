using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public interface ITodoService
    {
        List<Todo> ReturnFilteredTodos(bool isActive);
        List<Todo> GetTodos(string incomingSearch);
        Todo GetTodoById(long id);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void RemoveTodo(long id);
        List<Todo> GetTodosByAssignee(long id);
    }
}
