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
using System;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursProgrammeController : Controller
    {
        [Authorize(Roles = "Gestionnaire, Coach")]
        [HttpGet]
        public IActionResult Index()
        {
            List<CoursProgramme> listeCoursProgramme;

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                listeCoursProgramme = service.GetCoursProgrammes();
            }
            return View("ListeCoursProgramme", listeCoursProgramme);
        }

        [Authorize(Roles = "Gestionnaire,Coach")]
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

       

        [Authorize(Roles = "Gestionnaire, Coach")]
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
            
        [Authorize(Roles = "Coach,Gestionnaire")] 
        [HttpPost]
        public IActionResult SupprimerCoursProgramme(CoursProgramme coursProgramme)
        {
            using (IDalReservation service = new ReservationService())
            {
                foreach (Client inscrit in service.GetClientsInscrits(coursProgramme))
                {
                    Console.WriteLine($"On rembourse le client {inscrit.Prenom} {inscrit.Nom} (Id = {inscrit.Id}) : {coursProgramme.Cours.Prix}");
                }
            }
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(coursProgramme.Id);
            }
            
            return RedirectToAction("Index");
        }
    }
}
