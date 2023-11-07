using EasyTrain_P2Gr1.Controllers.Outils;
using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using EasyTrain_P2Gr1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Channels;

namespace EasyTrain_P2Gr1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Connexion()
        {
            //TODO : revoir le code
            //TODO : Vérifier le champ deletedAt
            //TODO : comprendre le bug de vincent (problème de validation)
            ClientViewModel utilisateurViewModel = new ClientViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated }; //On stocke le bool d'athentification
            if (utilisateurViewModel.Authentifie)// On vérifie si l'utilisateur est déjà authentifié
            {
                if (utilisateurViewModel.Utilisateur is Client) //Si c'est le cas, on vérifie le type d'utilisateur
                {
                    using (IDalClient service = new ClientService()) // Et on le récupère en base de données
                    {
                        utilisateurViewModel.Utilisateur = service.GetClient(HttpContext.User.Identity.Name); //On récupère l'id stocké dans le cookie
                        return View(utilisateurViewModel); // Il est déjà authentifié donc on lui renvoie une page (à définir)
                    }
                }
            }
            return View(utilisateurViewModel); // Il n'est pas authentifié donc on lui renvoie la page de connexion
        }

        [HttpPost]
        public IActionResult Connexion(ClientViewModel viewModel, string returnUrl)
        {
            Console.WriteLine("OK");


            Console.WriteLine("model valid");
            using (IDalUtilisateur service = new UtilisateurService())
            {
                Utilisateur utilisateur = service.Authentifier(viewModel.Utilisateur.AdresseMail, viewModel.Utilisateur.MotDePasse); // On vérifie les identifiants en base de données
                if (utilisateur != null)
                {
                    Console.WriteLine("Authentifié");
                    //On construit le cookie
                    var userClaims = new List<Claim>()
                        {

                            new Claim(ClaimTypes.Name, utilisateur.Id.ToString()),
                            new Claim(ClaimTypes.Role, utilisateur.GetType().Name)
                        };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity"); //???

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity }); //???

                    HttpContext.SignInAsync(userPrincipal); // Crée le cookie => L'utilisateur est connecté


                        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }



                        // Redirection Utilisateur
                    if (utilisateur is Gestionnaire)
                    {
                        // Rediriger vers une page spécifique pour les Gestionnaires
                        return RedirectToAction("dashboardgestionnaire", "Gestionnaire");
                    }
                    
                    else if (utilisateur is Coach)
                    {
                        // Rediriger vers une page spécifique pour les coachs
                        //return RedirectToAction("dashbordcoach", "Coach");
                        return RedirectToAction("Index", "Coach");
                    }
                        // Rediriger vers le site
                    return Redirect("/");
                    }
                ModelState.AddModelError("Utilisateur.AdresseMail", "AdresseMail incorrect");
                ModelState.AddModelError("Utilisateur.MotDePasse", "Mot de passe incorrect");

            }
            return View(viewModel);
        }

        public IActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        
    }
}
