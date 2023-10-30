using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyTrain_P2Gr1.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursProgrammeController : Controller
    {
<<<<<<< HEAD

        public IActionResult Index()
        {
            List<CoursProgramme> listeCoursProgramme;

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
=======
       

    public IActionResult Index()
    {
        List<CoursProgramme> listeCoursProgramme;

        using (IDalCoursProgramme service = new CoursProgrammeService())
        {
>>>>>>> origin/main
                listeCoursProgramme = service.GetCoursProgrammes();
            }
            return View(listeCoursProgramme);
        }
<<<<<<< HEAD
=======
        return View("ListeCoursProgramme",listeCoursProgramme);
    }
>>>>>>> origin/main

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
<<<<<<< HEAD
            CoursProgrammeViewModel model = new CoursProgrammeViewModel();

            model.Cours = new List<SelectListItem>();
            List<Cours> listCours;
=======
            return View(coursProgramme);
        }
        return View("Error");
    }


    [HttpGet]
    public IActionResult CreerCoursProgramme()
    {
            FormulaireCoursProgrammeViewModel model = new FormulaireCoursProgrammeViewModel();
            
>>>>>>> origin/main
            using (IDalCours service = new CoursService())
            {
                model.Cours = service.GetCours();
            }
<<<<<<< HEAD
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
=======
            

            return View(model);
    }


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
                cours = service.GetCours (model.CoursId);
        }
            
>>>>>>> origin/main

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

<<<<<<< HEAD
            return View();
=======
        return RedirectToAction("index");
>>>>>>> origin/main


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
<<<<<<< HEAD
=======
            service.UpdateCoursProgramme(coursProgramme);
        }
        return View();
    }


    [HttpGet]
    public IActionResult SupprimerCoursProgramme()
    {
            string id = HttpContext.User.Identity.Name;
           
        
            CoursProgramme coursProgramme;
>>>>>>> origin/main
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(coursProgramme.Id);
            }
<<<<<<< HEAD
            return View();
=======
        
        return View("Error");
    }

    [HttpPost]
    public IActionResult SupprimerCoursProgramme(CoursProgramme coursProgramme)
    {
        using (IDalCoursProgramme service = new CoursProgrammeService())
        {
            service.DeleteCoursProgramme(coursProgramme.Id);
        }
            HttpContext.SignOutAsync();
            return Redirect("/");
>>>>>>> origin/main
        }


    }
}
