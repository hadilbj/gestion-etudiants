using atelier3.Models;
using atelier3.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace atelier3.Controllers
{
    public class SchoolController : Controller
    {
        private ISchoolRepository schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }
        //GET: SchoolController
        public ViewResult Index()
        {
            var model = schoolRepository.GetAll();
            return View(model);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int Id)
        {
            var model = schoolRepository.GetById(Id);
            return View(model);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (School school)
        {
            try
            {
                schoolRepository.Add(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            School school = schoolRepository.GetById(id);
            if (school == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School s)
        {
            try
            {
                schoolRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }catch
            {
                return View();

            }
        }

        //GET:delete
        public ActionResult Delete(int Id)
        {
            var model = schoolRepository.GetById(Id);
            return View(model);
        }
        // POST: SchoolController/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School s)
        {
            try
            {
                schoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

    }


}
