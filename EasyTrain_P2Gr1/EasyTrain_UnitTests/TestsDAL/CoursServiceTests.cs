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
        public void TestGetCours()
        {
            using (BddContext ctx = new BddContext())
            {
                ctx.Cours.AddRange(new List<Cours>() {
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
                    }
            },
                new Cours()
                                {
                    Titre = "Musculation expert",
                    NbParticipants = 5,
                    Prix = 30,
                    Coach = new Coach()
                    {
                        Nom = "Benani",
                        Prenom = "Maria",
                        AdresseMail = "mariabenani@mail.com",
                        MotDePasse = "mdp",
                        DateNaissance = new DateTime(1995, 2, 13),
                        DateCreationCompte = new DateTime(2023, 5, 9)
                    }
                }
                });
                ctx.SaveChanges();
            }

            List<Cours> cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours();
            }
            Assert.NotEmpty(cours);
            Assert.Equal(2, cours.Count);
            Assert.NotNull(cours[0].Coach);
        }
        /***************************************************************************/

        [Fact]
        public void TestCreateCours()
        {
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
                }
        };


            using (IDalCours service = new CoursService())
            {
                service.CreateCours(cours);

            }


            using (BddContext ctx = new BddContext())
            {
                cours = ctx.Cours.Include(c => c.Coach).Where(c => c.Id == 1).First();
            }
            Assert.NotNull(cours);
            Assert.Equal(10, cours.NbParticipants);
            Assert.NotNull(cours.Coach);
        }

        /*****************************************************************************************/


        [Fact]
        public void TestDeleteCours()
        {

            using (BddContext ctx = new BddContext())
            {

                ctx.Cours.Add(
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
                    }
            }
                );
                ctx.SaveChanges();
            }

            Cours cours;
            using (IDalCours service = new CoursService())
            {
                cours = service.GetCours(1);
            }

            using (IDalCours service = new CoursService())
            {
                service.DeleteCours(cours.Id);
                cours = service.GetCours(1);
            }

            Assert.Null(cours);
        }



    }
}
