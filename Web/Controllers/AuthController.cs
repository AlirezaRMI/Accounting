using System.Security.Claims;
using Application.Services.Interfaces;
using Domain.Enum.User;
using Domain.ViewModel.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class AuthController(IUserService userService) : BaseController
{
    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserViewModel model)
    {
        if (!User.Identity!.IsAuthenticated)
        {
            if (ModelState.IsValid)
            {
                var (result, user) = await userService.LoginUserAsync(model);

                switch (result)
                {
                    case LoginResult.Success:
                        if (user.Id != null)
                        {
                            List<Claim> claims =
                            [
                                new(ClaimTypes.Name, user!.UserName!),
                                new(ClaimTypes.NameIdentifier, user.Id)
                            ];

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            var authProps = new AuthenticationProperties
                            {
                                IsPersistent = model.RememberMe,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                            };

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                                authProps);
                        }

                        TempData[SuccessMessage] = $"{user.UserName} خوش آمدید";

                        await Task.Delay(1000);

                        return RedirectToAction("Index", "Home");
                    case LoginResult.Error:
                        TempData[ErrorMessage] = "خطای ناشناخته";
                        return RedirectToAction("Login", "Auth");
                    case LoginResult.NotFound:
                        TempData[WarningMessage] = "کاربری وجود نداشت";
                        break;
                    case LoginResult.Blocked:
                        break;
                    case LoginResult.NotActive:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        return View(model);
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            RegisterResult response = await userService.RegisterUserAsync(model);

            switch (response)
            {
                case RegisterResult.Success:
                    return RedirectToAction("Login", "Auth");
                case RegisterResult.UserAlreadyExists:
                    TempData[ErrorMessage] = "کاربری با این مشخصات قبلا ثبت نام کرده است";
                    break;
                case RegisterResult.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return View(model);
    }
}