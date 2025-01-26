using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hmn_API.Models
{
    //Models are classes that define our entities 
    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public decimal Height { get; set; }
        [Column(TypeName = "decimal(5, 2)")]

        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(5, 2)")]

        public string Gender { get; set; } = string.Empty;
    }
}