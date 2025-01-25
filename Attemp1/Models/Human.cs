using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Attemp1.Models
{
    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public decimal Height { get; set; }
        [Column(TypeName = "decimal(3, 2)")]

        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(3, 2)")]

        public string Gender { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}