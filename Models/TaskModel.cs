using System;

namespace Models
{
    public class TaskModel
    {
        public int TaskModelId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TaskStatusModelId { get; set; }
    }
}
