using Microsoft.EntityFrameworkCore;
using Split.DbContexts;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using System.Diagnostics;

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
                Sum = expense.Sum,
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

        public Expense AddExpense(string name,int userId, Guid groupId, double sum, DateTime date)
        {
            using var context = contextFactory.CreateDbContext();
            var expense = new Expenses
            {
                Id = new Guid(),
                Name = name,
                UserId = userId,
                GroupId = groupId,
                Sum = sum,
                Date = date
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

        public DebtModel GetDebt(Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var debts = context.Debts.Where(x => x.Id == id).FirstOrDefault() ?? throw new DebtNotFoundException();

            var debt = new DebtModel
            {
                Id = debts.Id,
                ExpenseId = debts.ExpenseId,
                UserId = debts.UserId,
                Debt = debts.Debt,
                Paid = debts.Paid,
            };
            return debt;
        }

        public List<Debts> GetUserDebts(int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var debts = context.Debts.Where(x => x.UserId == userId).ToList();
            if (debts.Count == 0) throw new DebtNotFoundException();

            return debts;
        }

        public List<Debts> GetExpenseDebts(Guid expenseId)
        {
            using var context = contextFactory.CreateDbContext();
            var debts = context.Debts.Where(x => x.ExpenseId == expenseId).ToList();
            if (debts.Count == 0) throw new DebtNotFoundException();

            return debts;
        }

        public DebtModel AddDebt(Guid expenseId, int userId, double sum, double paid)
        {
            using var context = contextFactory.CreateDbContext();
            var debt = new Debts
            {
                Id = new Guid(),
                ExpenseId = expenseId,
                UserId = userId,
                Debt = sum,
                Paid = paid
            };
            context.Debts.Add(debt);
            context.SaveChanges();

            return GetDebt(debt.Id);
        }

        public void DeleteDebt(Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var debt = context.Debts.Where(x => x.Id == id).FirstOrDefault() ?? throw new DebtNotFoundException();

            context.Debts.Remove(debt);
            context.SaveChanges();
        }

        public List<Debts> GetUserGroupDebts(Guid groupId, int userId)
        {
            using var context = contextFactory.CreateDbContext();

            var debts = context.Debts.Where(x => x.Expenses.Groups.Id == groupId && x.UserId == userId).ToList();

            if (debts.Count == 0) throw new DebtNotFoundException();

            return debts;

        }

        public List<CustomDebt> GetUserCustomDebts(int userId, int debtUserId)
        {
            using var context = contextFactory.CreateDbContext();

            var debts = context.Debts
                .Where(x => x.UserId == userId && x.Expenses.UserId == debtUserId)
                .Select(x => new CustomDebt
                {
                    Id = x.Id,
                    ExpenseId = x.ExpenseId,
                    UserId = x.UserId,
                    DebtUserId = x.Expenses.UserId,
                    Debt = x.Debt,
                    Paid = x.Paid
                }).ToList();
            if (debts.Count == 0) throw new DebtNotFoundException();

            return debts;
        }

        public List<CustomDebt> GetUserGroupCustomDebts(Guid groupId, int debtUserId, int userId)
        {
            using var context = contextFactory.CreateDbContext();

            var debts = context.Debts
                .Where(x => x.UserId == userId && x.Expenses.UserId == debtUserId && x.Expenses.GroupId == groupId)
                .Select(x => new CustomDebt
                {
                    Id = x.Id,
                    ExpenseId = x.ExpenseId,
                    UserId = x.UserId,
                    DebtUserId = x.Expenses.UserId,
                    Debt = x.Debt,
                    Paid = x.Paid
                }).ToList();
            if (debts.Count == 0) throw new DebtNotFoundException();

            return debts;

        }
    }
}
