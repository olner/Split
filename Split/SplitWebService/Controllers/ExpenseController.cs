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

        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }

        [HttpGet("/Expense", Name = "GetExpense")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Expense>))]
        public IActionResult GetExpense(Guid id)
        {
            var result = expenseSerivce.GetExpense(id);
            return Ok(new ServiceResponse<Expense> { Response = result });
        }

        [HttpGet("/GroupExpenses", Name = "GetGroupExpenses")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Expense>>))]
        public IActionResult GetGroupExpenses(Guid groupId)
        {
            var result = expenseSerivce.GetGroupExpenses(groupId);
            return Ok(new ServiceResponse<List<Expense>> { Response = result });
        }

        [HttpGet("/UserExpenses", Name = "GetUserExpenses")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Expense>>))]
        public IActionResult GetUserExpenses(int userId)
        {
            var result = expenseSerivce.GetUserExpenses(userId);
            return Ok(new ServiceResponse<List<Expense>> { Response = result });
        }

        [HttpPost("/AddExpense", Name = "AddExpense")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Expense>))]
        public IActionResult AddExpense(string name, int userId, Guid groupId, double sum, DateTime date)
        {
            var result = expenseSerivce.AddExpense(name, userId, groupId, sum, date);
            return Ok(new ServiceResponse<Expense> { Response = result });
        }

        [HttpDelete("/DeleteExpense", Name = "DeleteExpense")]
        public void DeleteExpense(Guid id) => expenseSerivce.DeleteExpense(id);

        [HttpGet("/Debt", Name = "GetDebt")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<DebtModel>))]
        public IActionResult GetDebt(Guid id)
        {
            var result = expenseSerivce.GetDebt(id);
            return Ok(new ServiceResponse<DebtModel> { Response = result });
        }

        [HttpGet("/UserDebts", Name = "GetUserDebts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<DebtModel>>))]
        public IActionResult GetUserDebts(int userId)
        {
            var result = expenseSerivce.GetUserDebts(userId);
            return Ok(new ServiceResponse<List<DebtModel>> { Response = result });
        }

        [HttpGet("/ExpenseDebts", Name = "GetExpenseDebts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<DebtModel>>))]
        public IActionResult GetExpenseDebts(Guid expenseId)
        {
            var result = expenseSerivce.GetExpenseDebts(expenseId);
            return Ok(new ServiceResponse<List<DebtModel>> { Response = result });
        }

        [HttpPost("/AddDebt", Name = "AddDebt")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<DebtModel>))]
        public IActionResult AddDebt(Guid expenseId, int userId, double sum, double paid)
        {
            var result = expenseSerivce.AddDebt(expenseId, userId, sum, paid);
            return Ok(new ServiceResponse<DebtModel> { Response = result });
        }

        [HttpDelete("/DeleteDebt", Name = "DeleteDebt")]
        public void DeleteDebt(Guid id) => expenseSerivce.DeleteDebt(id);

        [HttpGet("/UserGroupDebts", Name = "GetUserGroupDebts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<DebtModel>>))]
        public IActionResult GetUserGroupDebts(Guid groupId, int userId)
        {
            var result = expenseSerivce.GetUserGroupDebts(groupId, userId);
            return Ok(new ServiceResponse<List<DebtModel>> { Response = result });
        }

        [HttpGet("/UserCustomDebts", Name = "GetUserCustomDebts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<CustomDebt>>))]
        public IActionResult GetUserCustomDebts(int userId, int debtUserId)
        {
            var result = expenseSerivce.GetUserCustomDebts(userId, debtUserId);
            return Ok(new ServiceResponse<List<CustomDebt>> { Response = result });
        }

        [HttpGet("/UserGroupCustomDebts", Name = "GetUserGroupCustomDebts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<CustomDebt>>))]
        public IActionResult GetUserGroupCustomDebts(Guid groupId, int debtUserId, int userId)
        {
            var result = expenseSerivce.GetUserGroupCustomDebts(groupId, debtUserId, userId);
            return Ok(new ServiceResponse<List<CustomDebt>> { Response = result });
        }
    }
}
