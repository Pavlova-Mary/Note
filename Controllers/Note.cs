using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class Note
    {
        public int Id;
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCurrent { get; set; }

        public Note()
        {
            Id = new Random().Next(Int32.MaxValue);
            Created = DateTime.Now;
        }
    }
}
