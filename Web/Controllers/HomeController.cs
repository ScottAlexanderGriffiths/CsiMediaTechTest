using Web.Models;
using System.Text;
using System.Web.Mvc;
using Core.Types;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ValuesService _valuesService;

        public HomeController()
        {
            _valuesService = new ValuesService();
        }
        
        public ActionResult Index()
        {
            var viewmodel = new HomeViewModel
            {
                Values = _valuesService.GetValues(),
                SortBy = _valuesService.GetCurrentSortDirection(),
                ChangeLog = _valuesService.GetChangeLog().Versions
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddInput(HomeViewModel request)
        {
            _valuesService.AddValue(request.Input);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SortValues(HomeViewModel request)
        {
            _valuesService.SortValues(request.SortBy);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Reset()
        {
            _valuesService.Reset();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Export()
        {
            var xmlString = _valuesService.ExportChangeLog();

            return File(Encoding.UTF8.GetBytes(xmlString), "application/xml", "ChangeLog.xml");
        }
    }
}