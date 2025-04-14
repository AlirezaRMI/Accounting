using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components;

public  class Transaction(ITransactionService service) :ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    var transactions = await service.GetTransactionsAsync();
    return View("TransactionListComponent", transactions);
  }
}