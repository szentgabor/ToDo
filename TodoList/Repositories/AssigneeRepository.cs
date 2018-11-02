using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Repositories
{
    public class AssigneeRepository : ICRUD<Assignee>
    {
        private TodoDbContext assigneeContext;

        public AssigneeRepository(TodoDbContext assigneeContext)
        {
            this.assigneeContext = assigneeContext;
        }

        public void Create(Assignee element)
        {
            assigneeContext.Add(element);
            assigneeContext.SaveChanges();
        }

        public void Delete(Assignee element)
        {
            assigneeContext.Remove(element);
            assigneeContext.SaveChanges();
        }

        public List<Assignee> GetAllElements()
        {
            return assigneeContext.Assignees.ToList();
        }

        public List<Todo> GetFilteredElements(string incomingSearch)
        {
            throw new NotImplementedException();
        }

        public Assignee GetRecordById(long id)
        {
            return assigneeContext.Assignees.ToList().FirstOrDefault(x => x.ID == id);
        }

        public void Update(Assignee element)
        {
            assigneeContext.Update(element);
            assigneeContext.SaveChanges();
        }
    }
}
