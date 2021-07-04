using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.Logic.PersonProcessor;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
  
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonDetail(string id)
        {
            //PersonModel person = new PersonModel();
            var person = LoadPersons().Find(x => x.ExternalCode == id);
            return PartialView("PersonDetail", person);
        }

        public ActionResult ListPersons()
        {
            var data = LoadPersons();
            List<PersonModel> persons = new List<PersonModel>();

            foreach(var row in data)
            {
                persons.Add(new PersonModel
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Address = row.Address,
                    PartnerNumber = row.PartnerNumber,
                    CroatianPIN = row.CroatianPIN,
                    PartnerTypeId = (PartnerType)row.PartnerTypeId,
                    CreatedAtUtc = row.CreatedAtUtc,
                    CreateByUser = row.CreateByUser,
                    IsForeign = row.IsForeign,
                    ExternalCode = row.ExternalCode,
                    PersonGender = row.Gender,
                    FullName = row.FirstName + " " + row.LastName,
                });
            }

            persons.Sort((a, b) => b.CreatedAtUtc.CompareTo(a.CreatedAtUtc));

            return View(persons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            int created = CreatePerson(person.FirstName, person.LastName, person.Address, person.PartnerNumber, person.CroatianPIN, 
                (int)person.PartnerTypeId, DateTime.Now, person.CreateByUser, person.IsForeign, 
                person.ExternalCode, person.PersonGender.ToString()[0]);

            return Redirect("ListPersons");
        }
    }
}