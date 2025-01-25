using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Attemp1.Models
{
    public class Comment
    {
        public int? Id { get; set; }  

        public string Title { get; set; }  = string.Empty;

        public string Content { get; set; }  = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? HumanId { get; set; }
        public Human? Human { get; set; }
    }
}