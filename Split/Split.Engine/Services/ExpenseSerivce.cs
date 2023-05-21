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

        public Expense? AddExpense(string name, int userId, Guid groupId, double sum)
        {
            try
            {
                return expenseRepository.AddExpense(name, userId, groupId, sum);
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
    }
}
