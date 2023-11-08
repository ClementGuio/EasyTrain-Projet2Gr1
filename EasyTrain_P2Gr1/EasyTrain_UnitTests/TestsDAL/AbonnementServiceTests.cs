using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp]
    public class AbonnementServiceTests
    {

        [Fact]
        public void TestGetAbonnements()
        {
            //Initialisation
            List<Abonnement> abonnements = new List<Abonnement>
            {
                new Abonnement
                {
                    //Titre = "Basic",
                    Mensualite = 19.99
                },
                new Abonnement
                {
                    //Titre = "Premium",
                    Mensualite = 59.99
                }
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Abonnements.AddRange(abonnements);
                ctx.SaveChanges();
            }
            //Execution
            List<Abonnement> abonnementsDb;
            using (IDalAbonnement service = new AbonnementService())
            {
                abonnementsDb = service.GetAbonnements();
            }
            //Verification
            Assert.NotEmpty(abonnementsDb);
            Assert.Equal(abonnements.Count, abonnementsDb.Count);
        }

        [Fact]
        public void TestGetAbonnement()
        {
            //Initialisation
            Abonnement abonnement = new Abonnement
            {
                NbCours = 3,
                AccesEscalade = true,
                AccesPiscine = true,
                AccompagnementCoach = true,
                DateAbonnement = new DateTime(2023,11,10),
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Abonnements.Add(abonnement);
                ctx.SaveChanges();
            }
            //Execution
            Abonnement abonnementDb;
            using (IDalAbonnement service = new AbonnementService())
            {
                abonnementDb = service.GetAbonnement(abonnement.Id);
            }
            //Verification
            Assert.NotNull(abonnementDb);
            Assert.Equal(abonnement.Id, abonnementDb.Id);
            Assert.Equal(abonnement.NbCours, abonnementDb.NbCours);
            Assert.Equal(abonnement.AccesPiscine, abonnement.AccesPiscine);
            Assert.Equal(abonnement.AccesEscalade, abonnementDb.AccesEscalade);
            Assert.Equal(abonnement.AccompagnementCoach, abonnementDb.AccompagnementCoach);
            Assert.Equal(abonnement.DateAbonnement, abonnementDb.DateAbonnement);
            Assert.Equal(abonnement.Mensualite, abonnementDb.Mensualite);
        }
    }
}
