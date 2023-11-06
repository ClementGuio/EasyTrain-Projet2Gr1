using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp]
    public class CoachServiceTests
    {

        [Fact]
        public void TestGetCoachs()
        {
            //Initialisation
            using (BddContext ctx = new BddContext()) //Remplissage de la bdd pour le test
            {
                ctx.Coachs.AddRange(new List<Coach>()
                {
                    new Coach() {Nom = "Patpat", Prenom = "Patrick", DateNaissance = DateTime.Now,
                        AdresseMail ="adresse1@mail.com", MotDePasse="moots", DateCreationCompte = DateTime.Now},
                    new Coach() {Nom = "Dupont", Prenom = "Roger", DateNaissance= DateTime.Now,
                        AdresseMail="adresse@mail.com", MotDePasse= "passed", DateCreationCompte = DateTime.Now}
                });
                ctx.SaveChanges();
            }

            //Execution
            List<Coach> coachs;
            using (IDalCoach service = new CoachService())
            {
                coachs = service.GetCoachs();
            }

            //Verification
            Assert.NotEmpty(coachs);
            Assert.Equal(2, coachs.Count);
        }

        [Fact]
        public void TestGetCoach()
        {
            //Initialisation
            Coach coach = new Coach()
            {
                Nom = "Benani",
                Prenom = "Alba",
                AdresseMail = "albabenani@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1995, 2, 13),
                DateCreationCompte = new DateTime(2023, 5, 9)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.Add(coach);
                ctx.SaveChanges();
            }
            //Execution
            Coach coachDb;
            using (CoachService service = new CoachService())
            {
                coachDb = service.GetCoach(1);
            }
            //Verification
            Assert.NotNull(coachDb);
            Assert.Equal(coach.Id, coachDb.Id);
            Assert.Equal(coach.Nom, coachDb.Nom);
            Assert.Equal(coach.Prenom, coachDb.Prenom);
            Assert.Equal(coach.AdresseMail, coachDb.AdresseMail);
            Assert.Equal(coach.MotDePasse, coachDb.MotDePasse);
            Assert.Equal(coach.DateNaissance, coachDb.DateNaissance);
            Assert.Equal(coach.DateCreationCompte, coachDb.DateCreationCompte);
        }

        [Fact]
        public void TestCreateCoach()
        {
            //Initialisation
            Coach coach = new Coach()
            {
                Nom = "Benani",
                Prenom = "Alba",
                AdresseMail = "albabenani@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1995, 2, 13),
                DateCreationCompte = new DateTime(2023, 5, 9)
            };
            //Execution
            using (IDalCoach service = new CoachService())
            {
                service.CreateCoach(coach);
            }
            //Verification
            Coach coachDb;
            using (BddContext ctx = new BddContext())
            {
                coachDb = ctx.Coachs.Find(1);
            }
            Assert.NotNull(coachDb);
            Assert.Equal(coach.Id, coachDb.Id);
            Assert.Equal(coach.Nom, coachDb.Nom);
            Assert.Equal(coach.Prenom, coachDb.Prenom);
            Assert.Equal(coach.AdresseMail, coachDb.AdresseMail);
            Assert.Equal(coach.MotDePasse, coachDb.MotDePasse);
            Assert.Equal(coach.DateNaissance, coachDb.DateNaissance);
            Assert.Equal(coach.DateCreationCompte, coachDb.DateCreationCompte);
        }

        [Fact]
        public void TestUpdateCoach()
        {
            //Initialisation
            Coach coach = new Coach()
            {
                Nom = "Benani",
                Prenom = "Alba",
                AdresseMail = "albabenani@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1995, 2, 13),
                DateCreationCompte = new DateTime(2023, 5, 9)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.Add(coach);
                ctx.SaveChanges();
            }
            //Execution
            Coach coachModif = new Coach()
            {
                Id = coach.Id,
                Nom = "Benani-Liebz",
                Prenom = "Marie-Alba",
                AdresseMail = "mariealbabenani@mail.com",
                MotDePasse = "NEWmdp",
                DateNaissance = new DateTime(1992, 2, 13),
                DateCreationCompte = new DateTime(2023, 7, 9)
            };
            using (IDalCoach service = new CoachService())
            {
                service.UpdateCoach(coachModif);
            }
            //Verification
            Coach coachDb;
            using (BddContext ctx = new BddContext())
            {
                coachDb = ctx.Coachs.Find(1);
            }
            Assert.Equal(coach.Id, coachDb.Id);
            Assert.Equal(coachModif.Nom, coachDb.Nom);
            Assert.Equal(coachModif.Prenom, coachDb.Prenom);
            Assert.Equal(coachModif.AdresseMail, coachDb.AdresseMail);
            Assert.Equal(coachModif.MotDePasse, coachDb.MotDePasse);
            Assert.Equal(coachModif.DateNaissance, coachDb.DateNaissance);
            Assert.Equal(coachModif.DateCreationCompte, coachDb.DateCreationCompte);
        }

        [Fact]
        public void TestDeleteCoach()
        {
            //initialisation
            Coach coach = new Coach()
            {
                Nom = "Benani",
                Prenom = "Alba",
                AdresseMail = "albabenani@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1995, 2, 13),
                DateCreationCompte = new DateTime(2023, 5, 9)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.Add(coach);
                ctx.SaveChanges();
            }
            //Execution
            using (IDalCoach service = new CoachService())
            {
                service.DeleteCoach(1);
            }
            //Verification
            List<Coach> coachs;
            using (BddContext ctx = new BddContext())
            {
                coachs = ctx.Coachs.ToList();
            }
            Assert.Empty(coachs);
        }
    }
}
