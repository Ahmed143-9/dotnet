using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WintelUser.Areas.Identity.Data;
using WintelUser.Models;

namespace WintelUser.Controllers;
[Authorize]
public class HomeController : Controller

{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly UserManager<ApplicationUser> userManager;


    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        this._userManager = userManager;
    }

    public IActionResult Index()
    {
        ViewData["UserId"]=_userManager.GetUserId(this.User);
        return View();
    }

    public IActionResult Privacy()
    {  
        ViewData["UserId"]=_userManager.GetUserId(this.User);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
