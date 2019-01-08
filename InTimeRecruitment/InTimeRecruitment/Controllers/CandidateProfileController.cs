using InTimeRecruitment.Models;
using System.Web.Mvc;

namespace InTimeRecruitment.Controllers
{
    [Authorize]
    [RequireHttps]
    public class CandidateProfileController : Controller
    {
        // GET: CandidateProfile
        [Authorize(Roles = "Client, Admin")]
        public ActionResult CandidateProfileIndex()
        {  
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CandidateProfileIndex(CandidateProfileIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new ApplicationDbContext())
            {
                var profile = new CandidateProfile
                {
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    MobileNumber = model.MobileNumber,
                    City = model.City,
                    Country = model.Country,
                    PostCode = model.PostCode,
                    Summary = model.Summary,
                    Skills = model.Skills,
                    Languages = model.Languages
                };

                context.CandidateProfile.Add(profile);
                context.SaveChanges();
            }
            return View(model);
        }

        // GET: VacancyCreate
        /* [Authorize(Roles = "Client, Admin")]
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
         }*/

    }
}