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
        public void TestCreateClient()
        {
            DeleteCreateDB();

            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.CreateClient("BONNER","Henri", DateTime.Now ,"BONNER.Henri@gmail.com", "MonMotDePasse", DateTime.Now );

            }
            Client client;
            using (BddContext ctx = new BddContext())
            {
                client = ctx.Clients.Find(1);
            }
                Assert.Equal("BONNER",client.Nom);
        }

        [Fact]
        public void TestGetClients()
        {
            //Initialisation
            DeleteCreateDB(); // Suppression puis cr�ation de la bdd

            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                    new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now  },
                    new Client() {Nom = "Dupont", Prenom = "Roger", DateCreationCompte = DateTime.Now  }
                });
                ctx.SaveChanges();
            }

            //Execution de la m�thode � tester
            List<Client> clients;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                clients = service.GetClients();
            }

            //Verification du r�sultat
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

        [Fact]
        public void TestUpdateClient()
        {
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Client client;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.UpdateClient(1, "DUPONT", "Jean", DateTime.Now, "Test@gmail.com",
                                  "MDP", DateTime.Now, DateTime.Now);
                client = service.GetClient(1);
            }

            Assert.Equal("Jean", client.Prenom);
            Assert.Equal("MDP", client.MotDePasse);

        }

        [Fact]
        public void TestDeleteClient()
        {
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            List<Client> clients;

            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.DeleteClient(1);
                clients = service.GetClients();
            }

            Assert.Empty(clients);

        }
    }
}

