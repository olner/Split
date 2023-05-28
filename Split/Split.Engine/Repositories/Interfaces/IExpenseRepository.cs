using Split.DbContexts.Tables;
using Split.Engine.Models;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Expense GetExpense(Guid expenseId);
        List<Expenses> GetGroupExpenses(Guid groupId);
        List<Expenses> GetUserExpenses(int userId);
        Expense AddExpense(string name, int userId, Guid groupId, double sum, DateTime date);
        void DeleteExpense(Guid id);
        DebtModel GetDebt(Guid id);
        List<Debts> GetUserDebts(int userId);
        List<Debts> GetExpenseDebts(Guid expenseId);
        DebtModel AddDebt(Guid expenseId, int userId, double sum, double paid);
        void DeleteDebt(Guid id);
        List<Debts> GetUserGroupDebts(Guid groupId, int userId);
        List<CustomDebt> GetUserCustomDebts(int userId, int debtUserId);
        List<CustomDebt> GetUserGroupCustomDebts(Guid groupId, int debtUserId, int userId);

    }
}
