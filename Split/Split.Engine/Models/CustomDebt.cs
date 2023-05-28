using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Models
{
    public record CustomDebt
    {
        public Guid Id { get; set; }
        public Guid ExpenseId { get; set; }
        public int UserId { get; set; }
        public int DebtUserId { get; set; }
        public double Debt { get; set; }
        public double Paid { get; set; }
    }
}
