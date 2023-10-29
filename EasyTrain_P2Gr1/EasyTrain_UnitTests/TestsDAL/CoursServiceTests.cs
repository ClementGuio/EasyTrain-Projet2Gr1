using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp()]
    public class CoursServiceTests
    {
        [Fact]
        public void TestGetListCours()
        {
            //Initialisation
            List<Coach> coachs = new List<Coach>(){
                new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Alba",
                        AdresseMail = "albabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    },
                new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Maria",
                        AdresseMail = "mariabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    }
            };
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            List<Cours> cours;
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(coachs);
                ctx.Salles.Add(salle);
                ctx.SaveChanges();
                cours = new List<Cours>() {
                new Cours()
                    {
                        Titre = "Musculation débutant",
                        NbParticipants = 10,
                        Prix = 23.5,
                        Coach = ctx.Coachs.FirstOrDefault(c => c.Prenom == coachs[0].Prenom),
                        Salle = salle
                    },
                new Cours()
                    {
                        Titre = "Musculation expert",
                        NbParticipants = 5,
                        Prix = 30,
                        Coach = ctx.Coachs.FirstOrDefault(c => c.Prenom == coachs[1].Prenom),
                        Salle = salle
                    }
                };
                ctx.Cours.AddRange(cours);
                ctx.SaveChanges();
            }
            //Execution
            List<Cours> coursDb;
            using (IDalCours service = new CoursService())
            {
                coursDb = service.GetCours();
            }
            //Verification
            Assert.NotEmpty(coursDb);
            Assert.Equal(cours.Count, coursDb.Count);
            Assert.NotNull(coursDb[0].Coach);
            Assert.NotNull(coursDb[1].Coach);
            Assert.NotNull(coursDb[0].Salle);
            Assert.NotNull(coursDb[1].Salle);
        }

        [Fact]
        public void GetCours()
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
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            Cours cours;
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.Add(coach);
                ctx.Salles.Add(salle);
                ctx.SaveChanges();

                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = ctx.Coachs.FirstOrDefault(c => c.Prenom == coach.Prenom),
                    Salle = ctx.Salles.FirstOrDefault(s => s.Nom == salle.Nom)

                };
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
            }
            //Execution
            Cours coursDb;
            using (IDalCours service = new CoursService())
            {
                coursDb = service.GetCours(cours.Id);
            }
            //Verification
            Assert.NotNull(coursDb);
            Assert.Equal(cours.Titre, coursDb.Titre);
            Assert.NotNull(coursDb.Coach);
            Assert.Equal(cours.Coach.Id, coursDb.Id);
            Assert.NotNull(coursDb.Salle);
            Assert.Equal(cours.Salle.Id, coursDb.Salle.Id);
        }

        [Fact]
        public void TestCreateCours()
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
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            using(BddContext ctx = new BddContext())
            {
                ctx.Salles.Add(salle);
                ctx.Coachs.Add(coach);
                ctx.SaveChanges();
            }
            //Execution
            Cours cours;
            using (IDalCours service = new CoursService())
            {
                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = coach,
                    Salle = salle
                };
                service.CreateCours(cours);
            }
            //Verification
            Cours coursDb;
            using (BddContext ctx = new BddContext())
            {
                coursDb = ctx.Cours.Include(c => c.Coach).Include(c => c.Salle).Where(c => c.Id == 1).First();
            }
            Assert.NotNull(coursDb);
            Assert.Equal(cours.Titre, coursDb.Titre);
            Assert.Equal(cours.NbParticipants, coursDb.NbParticipants);
            Assert.Equal(cours.Prix, coursDb.Prix);
            Assert.NotNull(coursDb.Coach);
            Assert.Equal(cours.Id, coursDb.Id);
            Assert.NotNull(coursDb.Salle);
            Assert.Equal(cours.Id, coursDb.Id);
        }

        [Fact]
        public void TestUpdateCours()
        {
            //Initialisation
            List<Coach> coachs = new List<Coach>
            {
                new Coach()
                {
                    Nom = "Benani",
                    Prenom = "Alba",
                    AdresseMail = "albabenani@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1995, 2, 13),
                    DateCreationCompte = new DateTime(2023, 5, 9)
                },
                new Coach()
                {
                    Nom = "Benani",
                    Prenom = "Maria",
                    AdresseMail = "mariabenani@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1995, 2, 13),
                    DateCreationCompte = new DateTime(2023, 5, 9)
                }
            };
            List<Salle> salles = new List<Salle>
            {
                new Salle { Nom = "Salle A", Type = "muscu"},
                new Salle { Nom = "Salle B", Type = "squash"}
            };
            Cours cours;
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.AddRange(coachs);
                ctx.Salles.AddRange(salles);
                ctx.SaveChanges();
                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = ctx.Coachs.FirstOrDefault(c => c.Id == coachs[0].Id),
                    Salle = ctx.Salles.FirstOrDefault(s => s.Id == salles[0].Id)
                };
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
            }
            //Execution
            Cours coursModif = new Cours()
            {
                Id = cours.Id,
                Titre = "Musculation avancé",
                NbParticipants = 7,
                Prix = 25,
                Coach = coachs[1],
                Salle = salles[1]
            };
            using (IDalCours service = new CoursService())
            {
                service.UpdateCours(coursModif);
            }
            //Verification
            Cours coursDb;
            using (BddContext ctx = new BddContext())
            {
                coursDb = ctx.Cours.Include(c => c.Salle).Include(c => c.Coach).FirstOrDefault(c => c.Id == coursModif.Id);
            }
            Assert.NotNull(coursDb);
            Assert.Equal(cours.Id, coursDb.Id);
            Assert.Equal(coursModif.Titre, coursDb.Titre);
            Assert.Equal(coursModif.NbParticipants, coursDb.NbParticipants);
            Assert.Equal(coursModif.Prix, coursDb.Prix);
            Assert.NotNull(coursDb.Coach);
            Assert.Equal(coursModif.Coach.Id, coursDb.Coach.Id);
            Assert.NotNull(coursDb.Salle);
            Assert.Equal(coursModif.Salle.Id, coursDb.Salle.Id);
        }

        [Fact]
        public void TestDeleteCours()
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
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            Cours cours;
            using (BddContext ctx = new BddContext())
            {
                ctx.Coachs.Add(coach);
                ctx.Salles.Add(salle);
                ctx.SaveChanges();

                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = ctx.Coachs.FirstOrDefault(c => c.Prenom == coach.Prenom),
                    Salle = ctx.Salles.FirstOrDefault(s => s.Nom == salle.Nom)

                };
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
            }
            //Execution
            using (IDalCours service = new CoursService())
            {
                service.DeleteCours(cours.Id);
            }
            //Verification
            Salle salleDb;
            Coach coachDb;
            Cours coursDb;
            using(BddContext ctx = new BddContext())
            {
                coursDb = ctx.Cours.Find(cours.Id);
                coachDb = ctx.Coachs.Find(coach.Id);
                salleDb = ctx.Salles.Find(salle.Id);
            }
            Assert.Null(coursDb);
            Assert.NotNull(coachDb);
            Assert.NotNull(salleDb);
        }



    }
}
