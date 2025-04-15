using System.Security.Claims;
using Application.Extensions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components;

public class Transaction(ITransactionService service, IHttpContextAccessor httpContext,IUserService userService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = httpContext.HttpContext?.User.FindFirst(
            ClaimTypes.NameIdentifier)?.Value;
        var transactions = await service.GetUserTransactionsAsync(userId);
        var balance= await userService.GetUserBalanceAsync(userId);
        if (transactions.Any())
            transactions.First().TotalPrice = balance;
        
        return View("TransactionListComponent", transactions);
    }

  
}