using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Controllers
{
    public class UtilisateurController : Controller
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

        public IActionResult AfficherProfilClient(int id)
        {
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(id);

            }
            if (client != null)
            {
                return View(client);
            }
            return View("Error");
        }


        //----------------------------------------- Controllers CRUD Gestionnaire

        public IActionResult ListeGestionnaire() // Le nom de la méthode doit avoir le même nom que la vue
        {
            List<Gestionnaire> listeGestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                listeGestionnaire = service.GetGestionnaires();
            }
            return View(listeGestionnaire);
        }

        public IActionResult AfficherProfilGestionnaire(int id)
        {
            if (id != 0)
            {
                Gestionnaire gestionnaire;
                using (IDalGestionnaire service = new GestionnaireService())
                {
                    gestionnaire = service.GetGestionnaire(id);

                }
                if (gestionnaire != null)
                {
                    return View(gestionnaire);
                }
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult CreerGestionnaire() // Vue de création de profil GET
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreerGestionnaire(Gestionnaire gestionnaire) // Vue de création de profil Post
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.CreateGestionnaire(gestionnaire);
            }

            return View(gestionnaire);

        }


        [HttpGet]
        public IActionResult ModifierProfilGestionnaire(int id) // Vue de modification de profil GET
        {
            if (id != 0)
            {
            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);

            }
            if (gestionnaire != null)
            {
                return View(gestionnaire);
            }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierProfilGestionnaire(Gestionnaire gestionnaire) // Vue de modification de profil Post
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.UpdateGestionnaire(gestionnaire);
            }

            return View(gestionnaire);

        }

        [HttpGet]
        public IActionResult SupprimerGestionnaire(int id) // Vue de suppression de profil GET
        {
            if (id != 0)
            { 
            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(id);

            }
            if (gestionnaire != null)
            {
                return View(gestionnaire);
            }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult SupprimerGestionnaire(Gestionnaire gestionnaire) // Vue de suppression de profil Post
        {
            using (IDalGestionnaire dal = new GestionnaireService())
            {
                dal.DeleteGestionnaire(gestionnaire.Id);
            }

            return View();

        }
        //----------------------------------------- Fin Controllers CRUD Gestionnaire //-------------------------------------

    }
}
