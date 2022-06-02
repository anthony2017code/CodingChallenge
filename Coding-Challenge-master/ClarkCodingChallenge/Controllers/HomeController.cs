
using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarkCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactsService _service;

        public HomeController(IContactsService service)
        {
            _service = service;
        }

        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Create
        public IActionResult Confirmation(EntryViewModel model)
        {
            return View("Confirmation", model);
        }


        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LastName,FirstName,Email")] EntryViewModel model)
        {
            //TODO: use inputmodel
            try
            {
                if (_service.SaveContact(model))
                {
                    return RedirectToAction(nameof(Confirmation), model);
                }//TODO: maybe do this async?
                else
                {
                    //TODO: failed message
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
