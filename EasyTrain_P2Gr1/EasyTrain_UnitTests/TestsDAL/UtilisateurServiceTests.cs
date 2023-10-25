using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace EasyTrain_UnitTests.TestsDAL
{
    [DbCleanUp]
    [Collection("sequential")]
    public class UtilisateurServiceTests
    {
        
        [Fact]
        public void TestCreateClient()
        {
            using (IDalClient service = new ClientService())
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
            using (IDalClient service = new ClientService())
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
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Patpat", Prenom = "Patrick", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Client client;
            using (IDalClient service = new ClientService())
            {
                client = service.GetClient(1);
            }
            Assert.NotNull(client);
            Assert.Equal("Patpat", client.Nom);
        }
        [Fact]
        public void TestUpdateClient()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Client client;
            using (IDalClient service = new ClientService())
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
            using (BddContext ctx = new BddContext())
            {
                ctx.Clients.AddRange(new List<Client>()
                {
                new Client() {Nom = "Dupont", Prenom = "Pierre", DateCreationCompte = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            List<Client> clients;

            using (IDalClient service = new ClientService())
            {
                service.DeleteClient(1);
                clients = service.GetClients();
            }

            Assert.Empty(clients);

        }

            [Fact]
        public void TestCreateCoach()
        {
            using (IDalCoach service = new CoachService())
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
            using (IDalCoach service = new CoachService())
            {
                coachs = service.GetCoachs();
            }

            //Verification du r�sultat
            Assert.NotEmpty(coachs);
            Assert.Equal(2, coachs.Count);
        }
        [Fact]
        public void TestGetCoach()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                new Coach() {Nom = "patpat", Prenom = "patrick", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Coach coach;
            using (CoachService service = new CoachService())
            {
                coach = service.GetCoach(1);
            }
            Assert.NotNull(coach);
            Assert.Equal("patpat", coach.Nom);
        }
        [Fact]
        public void TestUpdateCoach()
        {
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
            using (IDalCoach service = new CoachService())
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
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                new Coach() {Nom = "Dupont", Prenom = "Pierre", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            List<Coach> coachs;

            using (IDalCoach service = new CoachService())
            {
                service.DeleteCoach(1);
                coachs = service.GetCoachs();
            }

            Assert.Empty(coachs);
        }

        [Fact]
        public void TestUpdateGestionnaire()
        {
            //Initialisation
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
            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.UpdateGestionnaire(1, "Gibert", "Michel", DateTime.Now, "Adresse@mail.com", "mdp", DateTime.Now);
                gestionnaire = service.GetGestionnaire(1);
            }
            //Vérifier que les changements ont bien été fait

            Assert.Equal("Michel", gestionnaire.Prenom);
            Assert.Equal("Gibert", gestionnaire.Nom);
        }

        [Fact]
        public void TestCreateGestionnaire()
        {
            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.CreerGestionnaire("Ali", "Jaber", DateTime.Now, "Adresse@mail.com", "mdp", DateTime.Now);

            }
            Gestionnaire gestionnaire;
            using (BddContext ctx = new BddContext())
            {
                gestionnaire = ctx.Gestionnaires.Find(1);
            }
            Assert.Equal("Ali", gestionnaire.Nom);
        }

        [Fact]
        public void TestGetGestionnaire()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.AddRange(new List<Gestionnaire>()
                {
                new Gestionnaire() {Nom = "Mdghri", Prenom = "Amira", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            Gestionnaire gestionnaire;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaire = service.GetGestionnaire(1);
            }
            Assert.NotNull(gestionnaire);
            Assert.Equal("Mdghri", gestionnaire.Nom);
        }
        [Fact]
        public void TestDeleteGestionnaire()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.AddRange(new List<Gestionnaire>()
                {
                new Gestionnaire() {Nom = "ddddd", Prenom = "hhhhhh", DateEmbauche = DateTime.Now }
                });
                ctx.SaveChanges();
            }
            List<Gestionnaire> gestionnaires;

            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.DeleteGestionnaire(1);
                gestionnaires = service.GetGestionnaires();
            }

            Assert.Empty(gestionnaires);

        }

        [Fact]
        public void TestGetGestionnaires()
        {
            //Initialisation

            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Gestionnaires.AddRange(new List<Gestionnaire>()
                {
                    new Gestionnaire() {Nom = "Patpat", Prenom = "Patrick", DateEmbauche = DateTime.Now  },
                    new Gestionnaire() {Nom = "Dupont", Prenom = "Roger", DateEmbauche = DateTime.Now  }
                });
                ctx.SaveChanges();
            }

            //Execution de la m�thode � tester
            List<Gestionnaire> gestionnaires;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaires = service.GetGestionnaires();
            }

            //Verification du r�sultat
            Assert.NotEmpty(gestionnaires);
            Assert.Equal(2, gestionnaires.Count);
        }
    }
}

