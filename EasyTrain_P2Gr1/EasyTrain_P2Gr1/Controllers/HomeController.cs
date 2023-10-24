using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
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
            using (IDalUtilisateur service = new UtilisateurService())
            {
                listeClient = service.GetClients();
            }
            return View(listeClient);
        }

        public IActionResult ListeGestionnaire() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Gestionnaire> listeGestionnaire;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                listeGestionnaire = service.GetGestionnaires();
            }
            return View(listeGestionnaire);
        }

        public IActionResult ModifierGestionnaire(int id)
        {
            if (id != 0)
            {
                using (IDalUtilisateur dal = new UtilisateurService())
                {
                    Gestionnaire gestionnaire = dal.ObtientTousLesGestionnaires().Where(r => r.Id == id).FirstOrDefault();
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
                using (IDalUtilisateur dal = new UtilisateurService())
                {
                    dal.DeleteGestionnaire(gestionnaire.Id, gestionnaire.Prenom, gestionnaire.Nom, gestionnaire.DateEmbauche);
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
                using (IDalUtilisateur dal = new UtilisateurService())
                {
                    Gestionnaire gestionnaire = dal.ObtientTousLesGestionnaires().FirstOrDefault(r => r.Id == id);
                    if (gestionnaire != null)
                    {
                        dal.DeleteGestionnaire(gestionnaire.Id);
                        return RedirectToAction("ListeGestionnaire");
                    }
                }
            }
            return View("Error"); // Gestionnaire non trouvé ou erreur de suppression
        }


    }
}
