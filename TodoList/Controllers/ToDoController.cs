using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repositories;
using TodoList.Services;
using TodoList.ViewModels;

namespace TodoList.Controllers
{

    [Route ("/todo")]
    public class TodoController : Controller
        {
        private ITodoService todoService;
        private AssigneeService assigneeService;
        private TodoAssignee todoAssignee;
        private AssigneeTodos assigneeTodos;

        public TodoController(ITodoService todoService, AssigneeService assigneeService, TodoAssignee todoAssignee, AssigneeTodos assigneeTodos)
        {
            this.todoService = todoService;
            this.assigneeService = assigneeService;
            this.todoAssignee = todoAssignee;
            this.assigneeTodos = assigneeTodos;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route ("")]
        [Route ("list")]
        public IActionResult List(string incomingSearch)
        {
            todoAssignee.Todos = todoService.GetTodos(incomingSearch);
            return View(todoAssignee);
           // return View(todoService.GetTodos(incomingSearch));
        }

        [HttpGet]
        [Route("getdone")]
        public IActionResult GetDone(bool isActive)
        {
            return Json(todoService.ReturnFilteredTodos(isActive));
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View(assigneeService.GetAssignees());
        }

        [HttpPost("add")]
        public IActionResult AddTodo(Todo todo)
        {
            todoService.CreateTodo(todo);
            return RedirectToAction("list");
        }

        [HttpPost("/{id}/delete")]
        public IActionResult DeleteTodo(long id)
        {
            todoService.RemoveTodo(id);
            return RedirectToAction("list");
        }

        [HttpGet("/{id}/edit")]
        public IActionResult Edit(long id)
        {
            //todoAssignee.Todos = todoService.GetTodos(incomingSearch);
            todoAssignee.Assignees = assigneeService.GetAssignees();
            todoAssignee.TodoSelected = todoService.GetTodoById(id);
            return View(todoAssignee);
        }

        [HttpPost("/{id}/edit")]
        public IActionResult EditTodo(Todo todo)
        {
            todoService.UpdateTodo(todo);
            return RedirectToAction("list");
        }

        [HttpGet("/{id}/assigneetodos")]
        public IActionResult AssigneeTodos(long id)
        {
            assigneeTodos.Todos = todoService.GetTodosByAssignee(id);
            assigneeTodos.AssigneeSelected = assigneeService.GetAssigneeById(id);
            return View(assigneeTodos);
        }
    }
}