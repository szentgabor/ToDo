using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TodoRepository : ICRUD<Todo>
    {
        private TodoDbContext toDoContext;

        public TodoRepository(TodoDbContext toDoContext)
        {
            this.toDoContext = toDoContext;
        }
        
        public void Create(Todo element)
        {
            toDoContext.Add(element);
            toDoContext.SaveChanges();
        }

        public void Delete(Todo element)
        {
            toDoContext.Remove(element);
            toDoContext.SaveChanges();
        }

        public List<Todo> GetAllElements()
        {
            return toDoContext.Todos.Include(b => b.Assignee).ToList();
        }

        public Todo GetRecordById(long id)
        {
            return toDoContext.Todos.ToList().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Todo element)
        {
            toDoContext.Update(element);
            toDoContext.SaveChanges();
        }

        public List<Todo> GetFilteredElements(string incomingSearch)
        {
            var dateTime = DateTime.TryParse(incomingSearch, out DateTime result);
            if (dateTime)
            {
                var dateTimeProper = DateTime.Parse(incomingSearch);
                return toDoContext.Todos.Where(x => x.CreationDate == dateTimeProper || x.DueDate == dateTimeProper).Include(b => b.Assignee).ToList();
            }
            return toDoContext.Todos.Where(x => x.Title == incomingSearch || x.Content == incomingSearch || x.Assignee.Name == incomingSearch).Include(b => b.Assignee).ToList();
        }
    }
}
