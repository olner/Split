using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Models
{
    public record DebtModel
    {
        public Guid Id { get; set; }
        public Guid ExpenseId { get; set; }
        public int UserId { get; set; }
        public double Debt { get; set; }
        public double Paid { get; set;}
    }
}
