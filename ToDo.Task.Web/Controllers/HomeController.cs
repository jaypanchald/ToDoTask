using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Task.Model;
using ToDo.Task.Repository.Repository;
using ToDo.Task.Web.Models;

namespace ToDo.Task.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyTaskRepository _myTaskRepository;

        public HomeController(IMyTaskRepository myTaskRepository)
        {
            _myTaskRepository = myTaskRepository;
        }

        public IActionResult Index()
        {

            return View(new AddTask());
        }

        [HttpPost]
        public async Task<JsonResult> AddTask(AddTask model)
        {
            if (model.Id > 0)
            {
                var updateEntity = await _myTaskRepository.FindOne(model.Id);
                updateEntity.Description = model.Message;
                updateEntity.CreatedTime = DateTime.UtcNow;
                await _myTaskRepository.Update(updateEntity);
            }
            else
            {
                await _myTaskRepository.Insert(new Model.Entity.MyTask()
                {
                    CreatedTime = DateTime.UtcNow,
                    IsCompleted = false,
                    Description = model.Message
                });
            }
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteTask(int id)
        {
            if (id > 0)
            {
                var deleteEntity = await _myTaskRepository.FindOne(id);
                if (deleteEntity != null)
                {
                    await _myTaskRepository.Delete(deleteEntity);
                }
            }
            return Json(id);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTask()
        {
            var alltask = await _myTaskRepository.GetAll();

            var result = new MyTaskList();
            var completedTask = new List<MyTask>();

            if (alltask != null
                && alltask.Any(a => a.IsCompleted))
            {
                result.CompletedToDoTask = alltask
                    .Where(w => w.IsCompleted)
                    .Select(s => new MyTask()
                    {
                        Id = s.Id,
                        Message = s.Description,
                        IsCompleted = s.IsCompleted
                    }).ToList();
            }
            if (alltask != null
                && alltask.Any(a => !a.IsCompleted))
            {
                result.MyToDoTask = alltask
                    .Where(w => !w.IsCompleted)
                    .Select(s => new MyTask()
                    {
                        Id = s.Id,
                        Message = s.Description,
                        IsCompleted = s.IsCompleted
                    }).ToList();
            }
            return View("_ListTask", result);
        }

        [HttpPost]
        public async Task<JsonResult> MarkComplete(int id)
        {
            if (id > 0)
            {
                var updateEntity = await _myTaskRepository.FindOne(id);
                updateEntity.IsCompleted = true;
                updateEntity.CreatedTime = DateTime.UtcNow;
                await _myTaskRepository.Update(updateEntity);
            }
            return Json(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
