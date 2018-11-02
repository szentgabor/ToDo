using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Services
{
    public class AssigneeService
    {
        private ICRUD<Assignee> assigneeRepository;

        public AssigneeService(ICRUD<Assignee> assigneeRepository)
        {
            this.assigneeRepository = assigneeRepository;
        }

        public List<Assignee> GetAssignees()
        {
                return assigneeRepository.GetAllElements();
        }

        internal void CreateAssignee(Assignee assignee)
        {
            assigneeRepository.Create(assignee);
        }

        internal void RemoveAssignee(long id)
        {
            assigneeRepository.Delete(assigneeRepository.GetRecordById(id));
        }

        internal Assignee GetAssigneeById(long id)
        {
            return assigneeRepository.GetRecordById(id);
        }

        internal void UpdateAssignee(Assignee assignee)
        {
            assigneeRepository.Update(assignee);
        }
    }
}
