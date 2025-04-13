using Microsoft.AspNetCore.Mvc;

namespace Web.Components;

public class SideBar : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // todo : async action 
        await Task.CompletedTask;
        return View("SideBarComponent");
    }
}