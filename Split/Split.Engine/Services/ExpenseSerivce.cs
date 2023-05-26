using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;

namespace Split.Engine.Services
{
    public class ExpenseSerivce
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseSerivce(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        public Expense? GetExpense(Guid id)
        {
            try
            {
                return expenseRepository.GetExpense(id);
            }
            catch (ExpenseNotFoundException)
            {
                return null;
            }
        }

        public List<Expense>? GetGroupExpenses(Guid groupId)
        {
            try
            {
                return expenseRepository.GetGroupExpenses(groupId)
                    .Select(expense => new Expense
                    {
                        Id = expense.Id,
                        UserId = expense.UserId,
                        GroupId = expense.GroupId,
                        Name = expense.Name,
                        Date = expense.Date,
                        Sum = expense.Sum
                    }).ToList();
            }
            catch(ExpenseNotFoundException)
            {
                return null;
            }
        }

        public List<Expense>? GetUserExpenses(int userId)
        {
            try
            {
                return expenseRepository.GetUserExpenses(userId)
                    .Select(expense => new Expense
                    {
                        Id = expense.Id,
                        UserId = expense.UserId,
                        GroupId = expense.GroupId,
                        Name = expense.Name,
                        Date = expense.Date,
                        Sum = expense.Sum
                    }).ToList();
            }
            catch (ExpenseNotFoundException)
            {
                return null;
            }
        }

        public Expense? AddExpense(string name, int userId, Guid groupId, double sum, DateTime date)
        {
            try
            {
                return expenseRepository.AddExpense(name, userId, groupId, sum, date);
            }
            catch (ExpenseNotFoundException)
            {
                return null;
            }
        }

        public void DeleteExpense(Guid id)
        {
            expenseRepository.DeleteExpense(id);
        }

        public DebtModel? GetDebt(Guid id)
        {
            try
            {
                return expenseRepository.GetDebt(id);
            }
            catch (DebtNotFoundException)
            {
                return null;
            }
        }

        public List<DebtModel>? GetUserDebts(int userId)
        {
            try
            {
                var result = expenseRepository.GetUserDebts(userId)
                    .Select(x => new DebtModel
                    {
                        Id = x.Id,
                        Debt = x.Debt,
                        ExpenseId = x.ExpenseId,
                        Paid = x.Paid,
                        UserId = x.UserId
                    }).ToList();
                return result;
            }
            catch (DebtNotFoundException)
            {
                return null;
            }
        }

        public List<DebtModel>? GetExpenseDebts(Guid expenseId)
        {
            try
            {
                return expenseRepository.GetExpenseDebts(expenseId)
                    .Select(x => new DebtModel
                    {
                        Id = x.Id,
                        Debt = x.Debt,
                        ExpenseId = x.ExpenseId,
                        Paid = x.Paid,
                        UserId = x.UserId
                    }).ToList();
            }
            catch (DebtNotFoundException)
            {
                return null;
            }
        }

        public List<DebtModel>? GetUserGroupDebts(Guid groupId, int userId)
        {
            try
            {
                return expenseRepository.GetUserGroupDebts(groupId, userId)
                    .Select(x => new DebtModel
                    {
                        Id = x.Id,
                        Debt = x.Debt,
                        ExpenseId = x.ExpenseId,
                        Paid = x.Paid,
                        UserId = x.UserId
                    }).ToList();
            }
            catch (DebtNotFoundException)
            {
                return null;
            }
        }

        public DebtModel? AddDebt(Guid expenseId, int userId, double sum, double paid)
        {
            try
            {
                return expenseRepository.AddDebt(expenseId, userId, sum, paid);
            }
            catch (DebtNotFoundException)
            {
                return null;
            }
        }

        public void DeleteDebt(Guid id)
        {
            expenseRepository.DeleteDebt(id);
        }
    }
}
