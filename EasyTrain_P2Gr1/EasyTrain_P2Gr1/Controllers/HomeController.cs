using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.Name != null)
            {
                if (HttpContext.User.IsInRole("Client"))
                {
                    ViewData["role"] = "Client";
                }
                else if (HttpContext.User.IsInRole("Coach"))
                {
                    ViewData["role"] = "Coach";
                }
                else if (HttpContext.User.IsInRole("Gestionnaire"))
                {
                    ViewData["role"] = "Gestionnaire";
                }
            }
            List<Coach> listeCoach;
            using (IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            }

            return View(listeCoach);
        }

        public IActionResult Accueil()
        {
            return View();
        }

        public IActionResult Dev()
        {
            return View("DevIndex");
        }
        public IActionResult CalendrierUtilisateur()
        {
            List<CoursProgramme> listeCoursProgrammes;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                listeCoursProgrammes = service.GetCoursProgrammesAVenir();
            }
            CalendrierViewModel cvm = new CalendrierViewModel(listeCoursProgrammes, 30);
            return View(cvm);
        }

        [HttpGet]
        public IActionResult TestPartialView(List<String> id)
        {
            //List<String> message = new List<String> { "Youpi", "Controller de vues partielles" };
            return View(id);
        }

        public IActionResult ListeClient() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Client> listeClient;
            using (IDalClient service = new ClientService())
            {
                listeClient = service.GetClients();
            }
            return View(listeClient);


        }

        public IActionResult CartesCoachs() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Coach> listeCoach;
            using (IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            }
            return View(listeCoach);
        }

        public IActionResult ListeGestionnaire() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Gestionnaire> listeGestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                listeGestionnaire = service.GetGestionnaires();
            }
            return View(listeGestionnaire);
        }

        public IActionResult ModifierGestionnaire(int id)
        {
            if (id != 0)
            {
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    Gestionnaire gestionnaire = service.GetGestionnaires().Where(r => r.Id == id).FirstOrDefault();
                    if (gestionnaire == null)
                    {
                        return View("Error");
                    }
                    return View(gestionnaire);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierGestionnaire(Gestionnaire gestionnaire)
        {
            if (!ModelState.IsValid)
                return View(gestionnaire);

            if (gestionnaire.Id != 0)
            {
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    service.UpdateGestionnaire(gestionnaire);
                    return RedirectToAction("Gestionnaires");
                }
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult SupprimerGestionnaire(int id)
        {
            if (id != 0)
            {
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    Gestionnaire gestionnaire = service.GetGestionnaires().FirstOrDefault(r => r.Id == id);
                    if (gestionnaire != null)
                    {
                        service.DeleteGestionnaire(gestionnaire.Id);
                        return RedirectToAction("ListeGestionnaire");
                    }
                }
            }
            return View("Error"); // Gestionnaire non trouvé ou erreur de suppression
        }

        //---------------------------------------------------------------------------- Inscription
        [HttpGet]
        public IActionResult Inscription()
        {

            return View();
        }

        public IActionResult Tarifs()
        {

            List<Coach> listeCoach;
            using (IDalCoach service = new CoachService())
            {
                listeCoach = service.GetCoachs();
            }
         
            return View(listeCoach);
        }

        public IActionResult Presentation()
        {
            return View();
        }
    }
}
