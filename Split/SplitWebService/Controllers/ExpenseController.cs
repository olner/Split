using Microsoft.AspNetCore.Mvc;
using Split.DbContexts.Tables;
using Split.Engine.Models;
using Split.Engine.Services;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseSerivce expenseSerivce;

        public ExpenseController(ExpenseSerivce expenseSerivce)
        {
            this.expenseSerivce = expenseSerivce;
        }

        [HttpGet("/Expense", Name = "GetExpense")]
        public Expense? GetExpense(Guid id) => expenseSerivce.GetExpense(id);

        [HttpGet("/GroupExpenses", Name = "GetGroupExpenses")]
        public List<Expense>? GetGroupExpenses(Guid groupId) => expenseSerivce.GetGroupExpenses(groupId);

        [HttpGet("/UserExpenses", Name = "GetUserExpenses")]
        public List<Expense>? GetUserExpenses(int userId) => expenseSerivce.GetUserExpenses(userId);

        [HttpPost("/AddExpense", Name = "AddExpense")]
        public Expense? AddExpense(string name, int userId, Guid groupId, double sum) => expenseSerivce.AddExpense(name, userId, groupId, sum);

        [HttpDelete("/DeleteExpense", Name = "DeleteExpense")]
        public void DeleteExpense(Guid id) => expenseSerivce.DeleteExpense(id);

        [HttpGet("/Debt", Name = "GetDebt")]
        public DebtModel? GetDebt(Guid id) => expenseSerivce.GetDebt(id);

        [HttpGet("/UserDebts", Name = "GetUserDebts")]
        public List<Debts> GetUserDebts(int userId) => expenseSerivce.GetUserDebts(userId);

        [HttpGet("/ExpenseDebts", Name = "GetExpenseDebts")]
        public List<Debts>? GetExpenseDebts(Guid groupId) => expenseSerivce.GetExpenseDebts(groupId);

        [HttpPost("/AddDebt", Name = "AddDebt")]
        public DebtModel? AddDebt(Guid expenseId, int userId, double sum, double paid) => expenseSerivce.AddDebt(expenseId, userId, sum, paid);

        [HttpDelete("/DeleteDebt", Name = "DeleteDebt")]
        public void DeleteDebt(Guid id) => expenseSerivce.DeleteDebt(id);
    }
}
