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
                service.CreateClient("BONNER", "Henri", DateTime.Now, "BONNER.Henri@gmail.com", "MonMotDePasse", DateTime.Now);

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
        [Fact]
        public void TestUpdateGestionnaire()
        {
            //Initialisation
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.Add(new Gestionnaire()
                {
                    Nom = "Guibert",
                    Prenom = "Romain",
                    AdresseMail = "adresse@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = DateTime.Now,
                    DateEmbauche = DateTime.Now
                });
                ctx.SaveChanges();
            }
            //Appel de la méthode à tester
            Gestionnaire gestionnaire;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.UpdateGestionnaire(1, "Michel", "Gibert", DateTime.Now);
                gestionnaire = service.GetGestionnaire(1);
            }
            //Vérifier que les changements ont bien été fait
            Assert.Equal("Michel", gestionnaire.Prenom);
            Assert.Equal("Gibert", gestionnaire.Nom);
        }


            [Fact]
        public void TestCreateCoach()
        {
            DeleteCreateDB();
            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.CreerCoach("Vince","François",DateTime.Now,"adresse@mail.com","mot de passe", DateTime.Now );

            }
            Coach coach;
            using (BddContext ctx = new BddContext())
            {
                coach = ctx.Coachs.Find(1);
            }
            Assert.Equal("Vince", coach.Nom);
        }
        [Fact]
        public void TestGetCoachs()
        {
            //Initialisation
            DeleteCreateDB(); // Suppression puis cr�ation de la bdd

            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                    new Coach() {Nom = "Patpat", Prenom = "Patrick", 
                        DateEmbauche = DateTime.Now,AdresseMail ="adresse1@mail.com", DateNaissance = DateTime.Now, MotDePasse="moots"  },
                    new Coach() {Nom = "Dupont", Prenom = "Roger", DateEmbauche = DateTime.Now,
                        AdresseMail="adresse@mail.com", MotDePasse= "passed",
                      DateNaissance= DateTime.Now}
                });
                ctx.SaveChanges();
            }

            //Execution de la m�thode � tester
            List<Coach> coachs;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                coachs = service.GetCoachs();
            }

            //Verification du r�sultat
            Assert.NotEmpty(coachs);
            Assert.Equal(2, coachs.Count);
        }
        [Fact]
        public void testgetcoach()
        {
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                new Coach() {Nom = "patpat", Prenom = "patrick", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Coach coach;
            using (UtilisateurService service = new UtilisateurService())
            {
                coach = service.GetCoach(1);
            }
            Assert.NotNull(coach);
            Assert.Equal("patpat", coach.Nom);
        }
        [Fact]
        public void TestUpdateCoach()
        {
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                new Coach() {Nom = "Dupont", Prenom = "Pierre", DateEmbauche = DateTime.Now, 
                    AdresseMail="Test@gmail.com", MotDePasse= "ghtp", DateNaissance= DateTime.Now}
                });
                ctx.SaveChanges();
            }
            Coach coach;
            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.UpdateCoach(1, "DUPONT", "Jean", DateTime.Now, "Test@gmail.com",
                                  "MDP", DateTime.Now);
                coach = service.GetCoach(1);
            }

            Assert.Equal("Jean", coach.Prenom);
            Assert.Equal("MDP", coach.MotDePasse);

        }

        [Fact]
        public void TestDeleteCoach()
        {
            //initialisation
            DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                new Coach() {Nom = "Dupont", Prenom = "Pierre", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            List<Coach> coachs;

            using (IDalUtilisateur service = new UtilisateurService())
            {
                service.DeleteCoach(1);
                coachs = service.GetCoachs();
            }

            Assert.Empty(coachs);
        }
           
        
    }
}

