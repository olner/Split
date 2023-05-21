using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Models
{
    public record Expense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public Guid GroupId { get; set; }
        public double Sum { get; set; } 
        public DateTime Date { get; set; }
    }
}
