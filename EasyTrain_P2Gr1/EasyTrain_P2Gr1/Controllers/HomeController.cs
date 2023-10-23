using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}
