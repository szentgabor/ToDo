using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Services
{
    public class TodoService : ITodoService
    {
        private ICRUD<Todo> todoRepository;

        public TodoService(ICRUD<Todo> todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public List<Todo> ReturnFilteredTodos(bool isActive)
        {
            IEnumerable<Todo> filteredTodos = (isActive == true) ?
                                              (GetTodos(null).Where(x => x.IsDone == false)) :
                                              (GetTodos(null));
            return filteredTodos.ToList();
        }

        public void CreateTodo(Todo todo)
        {
            todoRepository.Create(todo);
 
        }

        public Todo GetTodoById(long id)
        {
            return todoRepository.GetRecordById(id);
        }

        public List<Todo> GetTodos(string incomingSearch)
        {
            if (incomingSearch == null)
            {
                return todoRepository.GetAllElements();
            }
            else
            {
                return todoRepository.GetFilteredElements(incomingSearch);
            }
        }

        public void RemoveTodo(long id)
        {
            todoRepository.Delete(todoRepository.GetRecordById(id));
        }

        public void UpdateTodo(Todo todo)
        {
            todoRepository.Update(todo);
        }

        public List<Todo> GetTodosByAssignee(long id)
        {
            return todoRepository.GetAllElements().Where(x => x.AssigneeID == id).ToList();
        }
    }
}
