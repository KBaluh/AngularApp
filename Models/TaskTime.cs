using System;

namespace Models
{
    public class TaskTime
    {
        public int TaskTimeId { get; set; }
        public int TaskModelId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
