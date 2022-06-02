using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Controllers;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Tests.ControllerTest
{

    [TestClass]
    public class ContactsControllerTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            Entry entry1 = new Entry();
            entry1.LastName = "a";
            entry1.FirstName = "a";
            entry1.Email = "a@a.a";
            ContactsDataAccess.save(entry1);

            Entry entry2 = new Entry();
            entry2.LastName = "b";
            entry2.FirstName = "a";
            entry2.Email = "a@a.a";
            ContactsDataAccess.save(entry2);

            Entry entry3 = new Entry();
            entry3.LastName = "c";
            entry3.FirstName = "a";
            entry3.Email = "a@a.a";
            ContactsDataAccess.save(entry3);

            ContactsService fakeService = new ContactsService();
            ContactsController contactsController = new ContactsController(fakeService);
            ContactRequestModel requestModel = new ContactRequestModel();
            requestModel.SortAscending = false;
            var result = contactsController.GetContacts(requestModel);
            Assert.IsTrue(result is ViewResult);
            if (result is ViewResult)
            {
                var model = (result as ViewResult).Model;
                Assert.IsTrue(model is ContactsViewModel);
                List<EntryViewModel> list = (model as ContactsViewModel).contacts;
                bool isDescending = true;
                for(int i =1; i < list.Count;i++)
                {
                   if(string.Compare(list[i - 1].LastName, list[i].LastName,true)<0)
                    {
                        isDescending = false;
                    }
                }
                Assert.IsTrue(isDescending);
            }
        }
    }
}
