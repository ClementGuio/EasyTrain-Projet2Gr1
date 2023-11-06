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
    [DbCleanUp]
    public class CoursProgrammeServiceTests
    {
        [Fact]
        public void TestGetCoursProgrammes()
        {
            //Initialisation
            Cours cours;
            List<CoursProgramme> coursProgrammes;
            using (BddContext ctx = new BddContext())
            {
                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Alba",
                        AdresseMail = "albabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    },
                    Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
                };
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
                coursProgrammes = new List<CoursProgramme>()
                {

                    new CoursProgramme()
                    {
                        DateDebut = new DateTime(2023, 11, 9, 10, 30, 0),
                        DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                        Cours = cours,
                        PlacesLibres = cours.NbParticipants
                    },
                    new CoursProgramme()
                    {
                        DateDebut = new DateTime(2023, 11, 8, 16, 0, 0),
                        DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                        Cours = cours,
                        PlacesLibres = cours.NbParticipants
                    }
                };
                ctx.CoursProgrammes.AddRange(coursProgrammes);
                ctx.SaveChanges();
            }
            //Execution
            List<CoursProgramme> coursProgrammesDb;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgrammesDb = service.GetCoursProgrammes();
            }
            //Verification
            Assert.NotEmpty(coursProgrammes);
            Assert.Equal(coursProgrammes.Count, coursProgrammesDb.Count);
            Assert.NotNull(coursProgrammesDb[0].Cours);
            Assert.NotNull(coursProgrammesDb[1].Cours);
        }

        [Fact]
        public void TestGetCoursProgramme()
        {
            //Initialisation
            Cours cours;
            CoursProgramme coursProgramme;
            using (BddContext ctx = new BddContext())
            {
                cours = new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Alba",
                        AdresseMail = "albabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    },
                    Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
                };
                ctx.Cours.Add(cours);
                ctx.SaveChanges();

                coursProgramme = new CoursProgramme()
                {
                    DateDebut = new DateTime(2023, 11, 9, 10, 30, 0),
                    DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                    Cours = cours,
                    PlacesLibres = cours.NbParticipants
                };
                ctx.CoursProgrammes.Add(coursProgramme);
                ctx.SaveChanges();
            }
            //Execution
            CoursProgramme coursProgrammeDb;
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgrammeDb = service.GetCoursProgramme(cours.Id);
            }
            //Verification
            Assert.NotNull(coursProgrammeDb);
            Assert.Equal(coursProgramme.Id, coursProgrammeDb.Id);
            Assert.NotNull(coursProgrammeDb.Cours);
            Assert.Equal(coursProgramme.Cours.Id, coursProgrammeDb.Cours.Id);
        }

        [Fact]
        public void TestCreateCoursProgramme()
        {
            //Initialisation
            Cours cours = new Cours()
            {
                Titre = "Musculation débutant",
                NbParticipants = 10,
                Prix = 23.5,
                Coach = new Coach()
                {
                    Nom = "Benani",
                    Prenom = "Alba",
                    AdresseMail = "albabenani@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1995, 2, 13),
                    DateCreationCompte = new DateTime(2023, 5, 9)
                },
                Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
            }
            CoursProgramme coursProgramme = new CoursProgramme()
            {
                DateDebut = new DateTime(2023, 11, 9, 10, 30, 0),
                DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                Cours = cours,
                PlacesLibres = cours.NbParticipants
            };

            //Execution
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.CreateCoursProgramme(coursProgramme);

            }

            //Verification
            CoursProgramme coursProgrammeDb;
            using (BddContext ctx = new BddContext())
            {
                coursProgrammeDb = ctx.CoursProgrammes
                    .Include(c => c.Cours)
                    .FirstOrDefault(c => c.Id == cours.Id);
            }
            Assert.NotNull(coursProgrammeDb);
            Assert.Equal(coursProgramme.Id, coursProgrammeDb.Id);
            Assert.Equal(coursProgramme.DateDebut, coursProgrammeDb.DateDebut);
            Assert.Equal(coursProgramme.DateFin, coursProgrammeDb.DateFin);
            Assert.NotNull(coursProgrammeDb.Cours);
            Assert.Equal(coursProgramme.Cours.Id, coursProgrammeDb.Cours.Id);
            Assert.Equal(coursProgramme.PlacesLibres, coursProgrammeDb.PlacesLibres);
        }

        [Fact]
        public void TestUpdateCoursProgramme()
        {
            //Initialisation
            List<Cours> cours = new List<Cours>{ 
                new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5,
                    Coach = new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Alba",
                        AdresseMail = "albabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    },
                    Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
                },
                new Cours()
                {
                    Titre = "Musculation avancé",
                    NbParticipants = 25,
                    Prix = 20,
                    Coach = new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Maria",
                        AdresseMail = "mariabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    },
                    Salle = new Salle { Nom = "Salle B", Type = "Muscu" }
                }
            };
            CoursProgramme coursProgramme = new CoursProgramme()
            {
                DateDebut = new DateTime(2023, 11, 9, 10, 30, 0),
                DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                Cours = cours[0],
                PlacesLibres = cours[0].NbParticipants
            }; ;
            using (BddContext ctx = new BddContext())
            {
                ctx.Cours.AddRange(cours);
                ctx.SaveChanges();
                ctx.CoursProgrammes.Add(coursProgramme);
                ctx.SaveChanges();
                
            }
            //Execution
            CoursProgramme coursProgrammeModif = new CoursProgramme()
            {
                Id = coursProgramme.Id,
                DateDebut = new DateTime(2023, 11, 9, 17, 00, 0),
                DateFin = new DateTime(2023, 11, 9, 18, 00, 0),
                Cours = cours[1],
                PlacesLibres = cours[1].NbParticipants
            };
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.UpdateCoursProgramme(coursProgrammeModif);
            }
            //Verification
            CoursProgramme coursProgrammeDb;
            using (BddContext ctx = new BddContext())
            {
                coursProgrammeDb = ctx.CoursProgrammes
                    .Include(c => c.Cours)
                    .FirstOrDefault(c => c.Id == coursProgrammeModif.Id);
            }
            Assert.NotNull(coursProgrammeDb);
            Assert.Equal(coursProgramme.Id, coursProgrammeDb.Id);
            Assert.Equal(coursProgrammeModif.DateDebut, coursProgrammeDb.DateDebut);
            Assert.Equal(coursProgrammeModif.DateFin, coursProgrammeDb.DateFin);
            Assert.NotNull(coursProgrammeDb.Cours);
            Assert.Equal(coursProgrammeModif.Cours.Id, coursProgrammeDb.Cours.Id);
            Assert.Equal(coursProgrammeModif.PlacesLibres, coursProgrammeDb.PlacesLibres);
        }


        [Fact]
        public void TestDeleteCoursProgramme()
        {
            //Initialisation
            Cours cours = new Cours()
            {
                Titre = "Musculation débutant",
                NbParticipants = 10,
                Prix = 23.5,
                Coach = new Coach()
                {
                    Nom = "Benani",
                    Prenom = "Alba",
                    AdresseMail = "albabenani@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1995, 2, 13),
                    DateCreationCompte = new DateTime(2023, 5, 9)
                },
                Salle = new Salle { Nom = "Salle A", Type = "Muscu" }
            };
            CoursProgramme coursProgramme;
            using (BddContext ctx = new BddContext())
            {
                ctx.Cours.Add(cours);
                ctx.SaveChanges();
                coursProgramme = new CoursProgramme()
                {
                    DateDebut = new DateTime(2023, 11, 9, 17, 00, 0),
                    DateFin = new DateTime(2023, 11, 9, 18, 00, 0),
                    PlacesLibres = cours.NbParticipants,
                    Cours = cours
                };
                ctx.CoursProgrammes.Add(coursProgramme);
                ctx.SaveChanges();
            }

            //Execution
            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(1);
            }
            //Verification
            List<CoursProgramme> coursProgrammesDb;
            using (BddContext ctx = new BddContext())
            {
                coursProgrammesDb = ctx.CoursProgrammes.ToList();
            }
            Assert.Empty(coursProgrammesDb);
            Assert.NotNull(coursProgramme.Cours);
        }



    }
}
