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
                Values = ValuesService.GetValues(),
                SortBy = ValuesService.SortBy,
                ChangeLog = ValuesService.GetChangeLog()
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddInput(HomeViewModel request)
        {
            ValuesService.AddValue(request.Input);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SortValues(HomeViewModel request)
        {
            ValuesService.SortValues(request.SortBy);

            return RedirectToAction("Index");
        }
    }
}