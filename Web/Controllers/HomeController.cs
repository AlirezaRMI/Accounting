using System.Runtime.InteropServices.JavaScript;
using Application.Extensions;
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
            AddTransactionResult result = await transactionService.AddTransactionAsync(model,User.GetUserId());
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
        }
        

        return View("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmTransaction(string id)
    {
        var result = await transactionService.ConfirmTransactionAsync(id);
        switch (result)
        {
            case MineTransaction.Success:
                TempData["SuccessMessage"] = "تراکنش با موفقیت تایید شد";
                break;
            case MineTransaction.Fail:
                TempData["ErrorMessage"] = "خطا در تایید تراکنش";
                break;
            case MineTransaction.Unknown:
                TempData["WarningMessage"] = "تراکنش پیدا نشد";
                break;
        }
        return RedirectToAction("Index");
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

    [HttpGet]
    public async Task<IActionResult> EditTransaction(string id)
    {
        var transaction = await transactionService.GetTransactionByIdAsync(id);
        if (transaction == null)
        {
            TempData["ErrorMessage"] = "تراکنش پیدا نشد";
            return RedirectToAction("Index");
        }

        return View(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> EditTransaction(EditeTransactionViewModel transaction)
    {
        if (ModelState.IsValid)
        {
            var result = await transactionService.UpdateTransactionAsync(transaction);
            switch (result)
            {
                case MineTransaction.Success:
                    return RedirectToAction("Index");
                case MineTransaction.Fail:
                    TempData[ErrorMessage] = "خطا در انجام عملیات";
                    return RedirectToAction("Index");
                case MineTransaction.Unknown:
                    TempData[WarningMessage] = "تراکنش یافت نشد";
                    return RedirectToAction("Index");
            }
        }
        return View();
    }
}