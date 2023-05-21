using Microsoft.EntityFrameworkCore;
using Split.DbContexts;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;

namespace Split.Engine.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IDbContextFactory<SplitDbContext> contextFactory;

        public ExpenseRepository(IDbContextFactory<SplitDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public Expense GetExpense(Guid expenseId)
        {
            using var context = contextFactory.CreateDbContext();
            var expense = context.Expenses.Where(x => x.Id == expenseId).FirstOrDefault() ?? throw new ExpenseNotFoundException();
            var exp = new Expense
            {
                Id = expense.Id,
                UserId = expense.UserId,
                GroupId = expense.GroupId,
                Name = expense.Name,
                Date = expense.Date,
                Sum = expense.Sum
            };
            return exp;
        }

        public List<Expenses> GetGroupExpenses(Guid groupId)
        {
            using var context = contextFactory.CreateDbContext();
            var expenses = context.Expenses.Where(x => x.GroupId == groupId).ToList();
            if (expenses.Count == 0) throw new ExpenseNotFoundException();
            return expenses;
        }

        public List<Expenses> GetUserExpenses(int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var expenses = context.Expenses.Where(x => x.UserId == userId).ToList();
            if (expenses.Count == 0) throw new ExpenseNotFoundException();
            return expenses;
        }

        public Expense AddExpense(string name,int userId, Guid groupId, double sum)
        {
            using var context = contextFactory.CreateDbContext();
            var expense = new Expenses
            {
                Id = new Guid(),
                Name = name,
                UserId = userId,
                GroupId = groupId,
                Sum = sum
            };
            context.Expenses.Add(expense);
            context.SaveChanges();
            return GetExpense(expense.Id);
        }

        public void DeleteExpense(Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var expense = context.Expenses.Where(x => x.Id == id).FirstOrDefault() ?? throw new ExpenseNotFoundException();
            context.Expenses.Remove(expense);
            context.SaveChanges();
        }

    }
}
