
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services
{
    public class TaskDto
    {
        public string Id { get; set; }
        [Required]
        public DateTime? DueTime { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
