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

        public IActionResult ListeClient() 
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
    }
}
