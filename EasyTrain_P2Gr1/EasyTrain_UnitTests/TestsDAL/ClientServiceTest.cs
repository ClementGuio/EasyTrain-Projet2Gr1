using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp]
    public class ClientServiceTest
    {
        [Fact]
        public void TestGetClients()
        {
            //Initialisation
            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                    new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now  },
                    new Client() {Nom = "Dupont", Prenom = "Roger", DateCreationCompte = DateTime.Now  }
                });
                ctx.SaveChanges();
            }

            //Execution
            List<Client> clients;
            using (IDalClient service = new ClientService())
            {
                clients = service.GetClients();
            }

            //Verification
            Assert.NotEmpty(clients);
            Assert.Equal(2, clients.Count);
        }

        [Fact]
        public void TestGetClient()
        {
            //Initalisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
            }
            //Execution
            Client clientDb;
            using (IDalClient service = new ClientService())
            {
                clientDb = service.GetClient(1);
            }
            //Verification
            Assert.NotNull(clientDb);
            Assert.Equal(client.Nom, clientDb.Nom);
            Assert.Equal(client.Prenom, client.Prenom);
            Assert.Equal(client.DateNaissance, clientDb.DateNaissance);
            Assert.Equal(client.AdresseMail, clientDb.AdresseMail);
            Assert.Equal(client.MotDePasse, clientDb.MotDePasse);
            Assert.Equal(client.DateAbonnement, clientDb.DateAbonnement);
        }

        [Fact]
        public void TestCreateClient()
        {
            //Initialisation
            Client client = new Client {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            //Execution
            using (IDalClient service = new ClientService())
            {
                service.CreateClient(client);

            }
            //Verification
            Client clientDb;
            using (BddContext ctx = new BddContext())
            {
                clientDb = ctx.Clients.Find(1);
            }
            Assert.NotNull(clientDb);
            Assert.Equal(client.Nom, clientDb.Nom);
            Assert.Equal(client.Prenom, clientDb.Prenom);
            Assert.Equal(client.DateNaissance, clientDb.DateNaissance);
            Assert.Equal(client.AdresseMail, clientDb.AdresseMail);
            Assert.Equal(client.MotDePasse, clientDb.MotDePasse);
            Assert.Equal(client.DateAbonnement, clientDb.DateAbonnement);
            Assert.Equal(client.DateCreationCompte, clientDb.DateCreationCompte);
        }

        [Fact]
        public void TestUpdateClient()
        {
            //Initialisation
            Client client = new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
            }
            //Execution
            Client clientModif = new Client
            {
                Id = client.Id,
                Nom = "DEBONNER",
                Prenom = "Jacques-Eude-Henri",
                DateNaissance = new DateTime(1978, 12, 12),
                AdresseMail = "DEBONNER.JacquesEudeHenri@gmail.com",
                MotDePasse = "NEWmdp",
                DateAbonnement = new DateTime(2024, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 25)
            };
            using (IDalClient service = new ClientService())
            {
                service.UpdateClient(clientModif);
            }
            //Verification
            Client clientDb;
            using (BddContext ctx = new BddContext())
            {
                clientDb = ctx.Clients.Find(1);
            }
            Assert.Equal(client.Id, clientDb.Id);
            Assert.Equal(clientModif.Nom, clientDb.Nom);
            Assert.Equal(clientModif.Prenom, clientDb.Prenom);
            Assert.Equal(clientModif.DateNaissance, clientDb.DateNaissance);
            Assert.Equal(clientModif.AdresseMail, clientDb.AdresseMail);
            Assert.Equal(clientModif.MotDePasse, clientDb.MotDePasse);
            Assert.Equal(clientModif.DateAbonnement, clientDb.DateAbonnement);
            Assert.Equal(clientModif.DateCreationCompte, clientDb.DateCreationCompte);
        }

        [Fact]
        public void TestDeleteClient()
        {
            //Initialisation
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now },
                });
                ctx.SaveChanges();
            }
            //Execution
            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(1);
            }
            //Verification
            List<Client> clients;
            using (BddContext ctx = new BddContext())
            {
                clients = ctx.Clients.ToList();
            }
            Assert.Empty(clients);

        }
        [Fact]
        public void TestSoftSupprimerClient()
        {

            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now },
                });
                ctx.SaveChanges();
            }

            // Execution

            using (IDalClient service = new ClientService())
            {
                service.SoftSupprimerClient(1);
            }
           
            //Verification
            List<Client> clients;
            using (BddContext ctx = new BddContext())
            {
                clients = ctx.Clients.ToList();
            }         
        }

    }
}
