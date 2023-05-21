using Split.DbContexts.Tables;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Expense GetExpense(Guid expenseId);
        List<Expenses> GetGroupExpenses(Guid groupId);
        List<Expenses> GetUserExpenses(int userId);
        Expense AddExpense(string name, int userId, Guid groupId, double sum);
        void DeleteExpense(Guid id);
    }
}
