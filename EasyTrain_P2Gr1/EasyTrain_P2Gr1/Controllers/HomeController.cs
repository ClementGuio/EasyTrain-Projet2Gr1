using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult ListeCoach() // Le nom de la méthode doit avoir le même nom que la vue
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
                    service.UpdateGestionnaire(gestionnaire.Id, gestionnaire.Prenom, gestionnaire.Nom, gestionnaire.DateEmbauche);
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


    }
}
