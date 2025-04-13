using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class BaseController : Controller
{
    protected string SuccessMessage = "SuccessMessage";
    protected string InfoMessage = "InfoMessage";
    protected string WarningMessage = "WarningMessage";
    protected string ErrorMessage = "ErrorMessage";
}