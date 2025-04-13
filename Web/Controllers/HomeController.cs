using Application.Services.Interfaces;
using Domain.ViewModel.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class HomeController(ITransactionService service) : BaseDashboardController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var transactions = await service.GetTransactionsAsync();
        return View(transactions);
    }

    public IActionResult AddTransaction(AddTransactionViewModel viewModel)
    {
        return View("/Index)");
    }
}