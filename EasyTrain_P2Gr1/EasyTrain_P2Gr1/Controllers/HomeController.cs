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
                    service.UpdateGestionnaire(gestionnaire.Id, gestionnaire.Nom,gestionnaire.Prenom, gestionnaire.DateNaissance,
                                               gestionnaire.AdresseMail, gestionnaire.MotDePasse, gestionnaire.DateEmbauche);
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


        /*
                //TODO:-----------------------------------------------------------------Modification de Profil   POST non fonctionnelle
                [HttpGet]
                public IActionResult Profil(int id) // Vue de modification de profil GET
                {
                    Utilisateur utilisateur;
                    using (BddContext ctx = new BddContext())
                    {
                       utilisateur = ctx.Utilisateurs.Find(id);

                    }
                    return View(utilisateur);

                }

                [HttpPost]
                public IActionResult Profil(Utilisateur utilisateur) // Vue de modification de profil Post
                {
                    Client client;
                    Gestionnaire gestionnaire;
                    Coach coach;

                    if (utilisateur is Client)
                    {
                     client = utilisateur as Client;

                        using (IDalClient dal = new ClientService())
                        {
                            dal.UpdateClient(client.Id, client.Nom, client.Prenom, client.DateNaissance, client.AdresseMail,
                                                   client.MotDePasse, client.DateCreationCompte, client.DateAbonnement);
                        }
                    }
                    else if (utilisateur is Gestionnaire)
                    {
                        gestionnaire = utilisateur as Gestionnaire;
                        using (IDalGestionnaire dal = new GestionnaireService())
                        {
                            dal.UpdateGestionnaire(gestionnaire.Id, gestionnaire.Nom, gestionnaire.Prenom, gestionnaire.DateNaissance, gestionnaire.AdresseMail,
                                                   gestionnaire.MotDePasse, gestionnaire.DateEmbauche);
                        }
                    }
                    else if (utilisateur is Coach)
                    {
                        coach = utilisateur as Coach;
                        using (IDalCoach dal = new CoachService())
                        {
                            dal.UpdateCoach(coach.Id, coach.Nom, coach.Prenom, coach.DateNaissance, coach.AdresseMail,
                                                   coach.MotDePasse, coach.DateEmbauche);
                        }
                    }
                    return View(utilisateur);

                }
                */
    }
}
