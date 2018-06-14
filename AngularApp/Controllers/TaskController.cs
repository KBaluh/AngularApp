using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        [HttpGet("[action]")]
        public List<TaskModel> GetAll()
        {
            List<TaskModel> list = new List<TaskModel>();
            for (int i = 1; i < 21; i++)
            {
                TaskModel model = new TaskModel
                {
                    TaskModelId = i,
                    Title = string.Format("Task Title {0}", i),
                    Body = string.Format("Task body {0}", i),
                    CreatedDate = DateTime.Now.AddDays(-(21 - i)),
                    StartDate = DateTime.Now.AddDays(-(21 - i)),
                    EndDate = DateTime.Now.AddDays(-(20 - i)),
                    UserId = i
                };
                list.Add(model);
            }
            return list;
        }
    }

    public class TaskModel
    {
        public int TaskModelId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}