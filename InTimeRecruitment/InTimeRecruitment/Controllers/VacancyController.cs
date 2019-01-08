using InTimeRecruitment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InTimeRecruitment.Controllers
{
    [Authorize]
    [RequireHttps]
    public class VacancyController : Controller
    {
        // GET: Vacancy
        [Authorize(Roles = "Client, Admin")]
        public ActionResult VacancyIndex()
        {
            return View();
        }

        // GET: VacancyCreate
        [Authorize(Roles = "Client, Admin")]
        public ActionResult VacancyCreate()
        {
            return View();
        }

        // POST: VacancyCreate
        [Authorize(Roles = "Client, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VacancyCreate(CreateVacancyViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = new Vacancy();

                    //string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    //vacancy.UserID = userId;
                    vacancy.Name = model.Name;
                    vacancy.Description = model.Description;

                    context.Vacancies.Add(vacancy);
                    context.SaveChanges();
                }
            }

            ViewBag.ResultMessage = "Vacancy created successfully !";
            return RedirectToAction("VacancyIndex", "Vacancy");
        }

        [Authorize(Roles = "Client, Admin")]
        public ActionResult VacancyList()
        {
            var context = new ApplicationDbContext();

            if (User.IsInRole("Admin"))
            {
                return View(context.Vacancies.ToList());
            }

            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            IQueryable<Vacancy> vacancies = context.Vacancies.Where(v => v.UserId.ToString() == userId);

            if (User.IsInRole("Client"))
            {
                return View(vacancies.ToList());
            }

            return View();
        }

        public ActionResult VacancyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var context = new ApplicationDbContext();
            Vacancy vacancy = context.Vacancies.Find(id);

            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        [Authorize(Roles = "Client, Admin")]
        public ActionResult VacancyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var context = new ApplicationDbContext();
            Vacancy vacancy = context.Vacancies.Find(id);

            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VacancyEdit([Bind(Include = "ID,UserID,Name,Description")] Vacancy vacancy)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    context.Entry(vacancy).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("VacancyList", "Vacancy");
                }
            }
            return View(vacancy);
        }

        [Authorize(Roles = "Client, Admin")]
        public ActionResult VacancyDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var context = new ApplicationDbContext();
            Vacancy vacancy = context.Vacancies.Find(id);

            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPost, ActionName("VacancyDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Vacancy vacancy = context.Vacancies.Find(id);
                context.Vacancies.Remove(vacancy);
                context.SaveChanges();
            }
            return RedirectToAction("VacancyIndex", "Vacancy");
        }

    }
}