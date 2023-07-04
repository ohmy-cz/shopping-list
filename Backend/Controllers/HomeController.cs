using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private readonly ILogger<HomeController> _logger;
  private readonly Backend.Data.ShoppingListContext _context;

  public HomeController(ILogger<HomeController> logger, Backend.Data.ShoppingListContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpGet]
  public IActionResult Get(string code)
  {
    // var sl = _context.ShoppingLists
    //   .Include(sl => sl.Items)
    //     .ThenInclude(item => item.ItemCategory)
    //   .FirstOrDefault();
    // var items = sl.Items.Select(it => $"{it.Name} ({it.ItemCategory.Name})") ?? new List<string>();
    // var response = new { Message = $"Hello, your shopping list has been last changed on {sl.LastChanged.ToString("f")}, and contains {string.Join(", ", items)}" };


    var shoppingList = _context.ShoppingLists
      .Include(sl => sl.Shop)
      .ThenInclude(s => s.ItemCategories)
      .ThenInclude(sic => sic.ItemCategory)
      .ThenInclude(ic => ic.Items)
      .Where(sl => sl.Code == code)
      .FirstOrDefault();
    // var shop = shoppingList?.Shop;
    // var response = new { Message = $"Hello, your shopping list has categories: {string.Join(", ", shop.ItemCategories.Where(oic => oic.ItemCategory != null).OrderBy(oic => oic.Order).Select(oic => oic.ItemCategory.Name))}" };
    // return new JsonResult(response);

    return new JsonResult(shoppingList, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
  }
}
