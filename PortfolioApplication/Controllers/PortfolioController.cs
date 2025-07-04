using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

public class PortfolioController : Controller
{
    private readonly IService _service;
    public PortfolioController(IService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Indexs()
    {
        var infos = await _service.GetAllAsync();
        return View(infos);
    }

    //public async Task<IActionResult> Indexs()
    //{
    //    return View();
    //}
}
