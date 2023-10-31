using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyTrain_P2Gr1.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursProgrammeController : Controller
    {

        public IActionResult Index()
        {
            List<CoursProgramme> listeCoursProgramme;

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {

                listeCoursProgramme = service.GetCoursProgrammes();
            }
            return View("ListeCoursProgramme", listeCoursProgramme);
        }

        [HttpGet]
        public IActionResult AfficherCoursProgramme(int id)
        {
            CoursProgramme coursProgramme;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgramme = service.GetCoursProgramme(id);

            }
            if (coursProgramme != null)
            {

                return View(coursProgramme);
            }
            return View("Error");
        }

        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult CreerCoursProgramme()
        {
            FormulaireCoursProgrammeViewModel model = new FormulaireCoursProgrammeViewModel();

            using (IDalCours service = new CoursService())
            {
                model.Cours = service.GetCours();
            }
            return View(model);
        }

        [Authorize(Roles = "Coach")]
        [HttpPost]
        public IActionResult CreerCoursProgramme(FormulaireCoursProgrammeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Cours cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours(model.CoursId);
            }

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.CreateCoursProgramme(new CoursProgramme
                {
                    DateDebut = model.DateDebut,
                    DateFin = model.DateFin,
                    Cours = cours,
                    PlacesLibres = cours.NbParticipants
                });
            }
            return RedirectToAction("index");
        }

        //TODO : on peut pas modifier de CoursProgramme
        //[HttpGet]
        //public IActionResult ModifierCoursProgramme(int id)
        //{

        //    if (id != 0)
        //    {
        //        CoursProgramme coursProgramme;
        //        using (IDalCoursProgramme service = new CoursProgrammeService())
        //        {
        //            coursProgramme = service.GetCoursProgramme(id);

        //        }
        //        if (coursProgramme != null)
        //        {
        //            return View(coursProgramme);
        //        }

        //    }
        //    return View("Error");
        //}


        //[HttpPost]
        //public IActionResult ModifierCoursProgramme(CoursProgramme coursProgramme)
        //{
        //    using (IDalCoursProgramme service = new CoursProgrammeService())
        //    {
        //        service.UpdateCoursProgramme(coursProgramme);
        //    }
        //    return View();
        //}

        [Authorize(Roles = "Coach")]
        [HttpGet]
        public IActionResult SupprimerCoursProgramme(int id)
        {
            if (id != 0)
            {
                CoursProgramme coursProgramme;
                using (IDalCoursProgramme service = new CoursProgrammeService())
                {
                    coursProgramme = service.GetCoursProgramme(id);
                }
                if (coursProgramme != null)
                {
                    return View(coursProgramme);
                }
            }
            return View("Error");
        }

        //TODO : Si un coach ou un gestionnaire supprime un CoursProgramme, on rembourse les clients        
        [Authorize(Roles = "Coach,Gestionnaire")] 
        [HttpPost]
        public IActionResult SupprimerCoursProgramme(CoursProgramme coursProgramme)
        {
            if (HttpContext.User.IsInRole("Coach"))//AIDE : On teste les roles des utilisateurs
            {

            }
            if (HttpContext.User.IsInRole("Gestionnaire"))
            {

            }
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(coursProgramme.Id);
            }
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
