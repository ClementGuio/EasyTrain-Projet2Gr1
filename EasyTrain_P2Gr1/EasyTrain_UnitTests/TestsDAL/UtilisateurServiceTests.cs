using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace EasyTrain_UnitTests.TestsDAL
{

    public class UtilisateurServiceTests
    {
        public void DeleteCreateDB()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }

        [Fact]
        public void TestGetClients()
        {
            //Initialisation
            DeleteCreateDB(); // Suppression puis création de la bdd

            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                    new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now  },
                    new Client() {Nom = "Dupont", Prenom = "Roger", DateCreationCompte = DateTime.Now  }
                });
                ctx.SaveChanges();
            }

            //Execution de la méthode à tester
            List<Client> clients;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                clients = service.GetClients();
            }

            //Verification du résultat
            Assert.NotEmpty(clients);
            Assert.Equal(2, clients.Count);
        }
        [Fact]
        public void TestGetClient()
        {
            DeleteCreateDB();

            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }

            Client client;
            using (UtilisateurService service = new UtilisateurService())
            {
                client = service.GetClient(1);
            }

            Assert.NotNull(client);
            Assert.Equal("Patpat", client.Nom);


        }
    }
}

