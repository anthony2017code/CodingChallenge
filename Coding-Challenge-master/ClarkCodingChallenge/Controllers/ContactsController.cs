using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _service;

        public ContactsController(IContactsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        //TODO: use route
        public IActionResult GetContacts([Bind("LastName, SortAscending")] ContactRequestModel requestModel)
        {
            ContactsViewModel contactsViewModel = new ContactsViewModel();
            contactsViewModel.contacts = _service.GetContacts(requestModel.LastName, requestModel.SortAscending);
            return View("ContactsList", contactsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
