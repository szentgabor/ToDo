using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class AssigneeController : Controller
    {
        private AssigneeService assigneeService;

        public AssigneeController(AssigneeService assigneeService)
        {
            this.assigneeService = assigneeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("assignee")]
        public IActionResult Assignee()
        {
            return View(assigneeService.GetAssignees());
        }

        [HttpGet("addassignee")]
        public IActionResult AddAssignee()
        {
            return View();
        }

        [HttpPost("addassignee")]
        public IActionResult AddAssignee(Assignee assignee)
        {
            assigneeService.CreateAssignee(assignee);
            return RedirectToAction("assignee");
        }

        [HttpPost("/{id}/deleteassignee")]
        public IActionResult DeleteAssignee(long id)
        {
            assigneeService.RemoveAssignee(id);
            return RedirectToAction("assignee");
        }

        [HttpGet("/{id}/editassignee")]
        public IActionResult EditAssignee(long id)
        {
            return View(assigneeService.GetAssigneeById(id));
        }

        [HttpPost("/{id}/editassignee")]
        public IActionResult EditAssignee(Assignee assignee)
        {
            assigneeService.UpdateAssignee(assignee);
            return RedirectToAction("assignee");
        }
    }
}