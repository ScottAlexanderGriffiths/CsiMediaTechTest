using CsiMediaTechTest.Models;
using CsiMediaTechTest.Services;
using System.Web.Mvc;

namespace CsiMediaTechTest.Controllers
{
    public class HomeController : Controller
    {
        public static ValuesService ValuesService { get; set; } = new ValuesService();
        
        public ActionResult Index()
        {
            var viewmodel = new HomeViewModel
            {
                Values = ValuesService.GetValues()
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddInput(HomeViewModel request)
        {
            ValuesService.AddValue(request.Input);

            return RedirectToAction("Index");
        }
    }
}