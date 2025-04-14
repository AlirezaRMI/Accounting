using System.Runtime.InteropServices.JavaScript;
using Application.Services.Interfaces;
using Domain.Enum.Transeation;
using Domain.ViewModel.Transaction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers;


public class HomeController(ITransactionService transactionService) : BaseController
{
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        // var model = await transactionService.GetTransactionsAsync();
        return View();
    }

  
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
       return RedirectToAction("Login","Auth");     
    }
    
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTransaction(AddTransactionViewModel model)
    {
        if (ModelState.IsValid)
        {
            AddTransactionResult result = await transactionService.AddTransactionAsync(model);
            switch (result)
            {
                case AddTransactionResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                case AddTransactionResult.Fail:
                    TempData[ErrorMessage] = "خطا در انجام عملیات";
                    return RedirectToAction("Index");
                case AddTransactionResult.Error:
                    TempData[ErrorMessage] = "خطای نا شناخته";
                    return RedirectToAction("Index");
            }

            
            var modelResult = await transactionService.AddTransactionAsync(model);
        }

        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteTransaction(string id)
    {
        MineTransaction result = await transactionService.DeleteTransactionAsync(id);
        switch (result)
        {
            case MineTransaction.Success:
                return RedirectToAction("Index");
            case MineTransaction.Fail:
                TempData[ErrorMessage] = "عملیات با خطا مواجه شد";
                return RedirectToAction("Index");
            case MineTransaction.Unknown:
                TempData[WarningMessage] = "کاربری یافت نشد";
                return RedirectToAction("Index");
            
        }
     
        return RedirectToAction("Index");
    }
}