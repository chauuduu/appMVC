using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AppCrud.Controllers
{
    [Authorize(Roles = "USER")]
    public class ClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
