using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Controllers
{
    public class CoursController : Controller
    {
        [HttpGet]
        public ActionResult CreerCours()
        {
            FormulaireCoursViewModel model = new FormulaireCoursViewModel();
            model.Coach = new List<SelectListItem>();
            List<Coach> listeCoach;
            using(IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            };
            foreach (Coach c in listeCoach) {
                model.Coach.Add(new SelectListItem() { Text = c.Nom + " " + c.Prenom, Value = c.Id.ToString(), Selected = false }); ;
            }

            model.Salle = new List<SelectListItem>();
            List<Salle> listeSalle;
            using (IDalSalle service = new SalleService())
            {
                listeSalle = service.GetSalles();
            };
            foreach (Salle s in listeSalle)
            {
                model.Salle.Add(new SelectListItem() { Text = s.Nom + " " + s.Type, Value = s.Id.ToString(), Selected = false }); ;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult CreerCours(FormulaireCoursViewModel model)
        {
            Salle salle;
            using (IDalSalle service = new SalleService())
            {
               salle = service.GetSalle(model.SalleId);
            };
            model.Cours.Salle = salle;
            using (IDalCours service = new CoursService())
            {
                service.CreateCours(model.Cours);
            }

            return View(model);
        }


    }
}
