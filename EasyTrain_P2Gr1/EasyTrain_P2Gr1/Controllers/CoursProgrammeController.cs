using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyTrain_P2Gr1.ViewModels;
using System.Linq;

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
            return View(listeCoursProgramme);
        }

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


        [HttpGet]
        public IActionResult CreerCoursProgramme()
        {
            CoursProgrammeViewModel model = new CoursProgrammeViewModel();

            model.Cours = new List<SelectListItem>();
            List<Cours> listCours;
            using (IDalCours service = new CoursService())
            {
                listCours = service.GetCours();
            }
            foreach (Cours cours in listCours)
            {
                model.Cours.Add(new SelectListItem() { Text = cours.Titre, Value = cours.Id.ToString(), Selected = false });
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult CreerCoursProgramme(CoursProgrammeViewModel model)
        {
            Cours cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours(model.CoursId);
            }
            model.CoursProgramme.Cours = cours;

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.CreateCoursProgramme(model.CoursProgramme);
            }

            return View();


        }


        [HttpGet]
        public IActionResult ModifierCoursProgramme(int id)
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


        [HttpPost]
        public IActionResult ModifierCoursProgramme(CoursProgramme coursProgramme)
        {
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.UpdateCoursProgramme(coursProgramme);
            }
            return View();
        }


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

        [HttpPost]
        public IActionResult SupprimerCoursProgramme(CoursProgramme coursProgramme)
        {
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(coursProgramme.Id);
            }
            return View();
        }


    }
}
