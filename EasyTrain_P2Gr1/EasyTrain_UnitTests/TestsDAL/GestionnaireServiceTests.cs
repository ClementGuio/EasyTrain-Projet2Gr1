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
    public class GestionnaireServiceTests
    {

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
            //Execution
            List<Gestionnaire> gestionnaires;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaires = service.GetGestionnaires();
            }
            //Verification
            Assert.NotEmpty(gestionnaires);
            Assert.Equal(2, gestionnaires.Count);
        }

        [Fact]
        public void TestGetGestionnaire()
        {
            //Initialisation
            Gestionnaire gestionnaire = new Gestionnaire()
            {
                Nom = "Malkovich",
                Prenom = "John",
                AdresseMail = "johnmalkovich@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1963, 2, 13),
                DateEmbauche = new DateTime(2023, 5, 9)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.Add(gestionnaire);
                ctx.SaveChanges();
            }
            //Execution
            Gestionnaire gestionnaireDb;
            using (IDalGestionnaire service = new GestionnaireService())
            {
                gestionnaireDb = service.GetGestionnaire(1);
            }
            Assert.NotNull(gestionnaireDb);
            Assert.Equal(gestionnaire.Nom, gestionnaireDb.Nom);
            Assert.Equal(gestionnaire.Prenom, gestionnaireDb.Prenom);
            Assert.Equal(gestionnaire.AdresseMail, gestionnaireDb.AdresseMail);
            Assert.Equal(gestionnaire.MotDePasse, gestionnaireDb.MotDePasse);
            Assert.Equal(gestionnaire.DateNaissance, gestionnaireDb.DateNaissance);
            Assert.Equal(gestionnaire.DateEmbauche, gestionnaireDb.DateEmbauche);
        }

        [Fact]
        public void TestCreateGestionnaire()
        {
            //Initialisation
            Gestionnaire gestionnaire = new Gestionnaire()
            {
                Nom = "Malkovich",
                Prenom = "John",
                AdresseMail = "johnmalkovich@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1963, 2, 13),
                DateEmbauche = new DateTime(2023, 5, 9)
            };
            //Execution
            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.CreateGestionnaire(gestionnaire);

            }
            //Verification
            Gestionnaire gestionnaireDb;
            using (BddContext ctx = new BddContext())
            {
                gestionnaireDb = ctx.Gestionnaires.Find(1);
            }
            Assert.NotNull(gestionnaireDb);
            Assert.Equal(gestionnaire.Nom, gestionnaireDb.Nom);
            Assert.Equal(gestionnaire.Prenom, gestionnaireDb.Prenom);
            Assert.Equal(gestionnaire.AdresseMail, gestionnaireDb.AdresseMail);
            Assert.Equal(gestionnaire.MotDePasse, gestionnaireDb.MotDePasse);
            Assert.Equal(gestionnaire.DateNaissance, gestionnaireDb.DateNaissance);
            Assert.Equal(gestionnaire.DateEmbauche, gestionnaireDb.DateEmbauche);
        }

        [Fact]
        public void TestUpdateGestionnaire()
        {
            //Initialisation
            Gestionnaire gestionnaire = new Gestionnaire()
            {
                 Nom = "Malkovich",
                Prenom = "John",
                AdresseMail = "johnmalkovich@mail.com",
                MotDePasse = "mdp",
                DateNaissance = new DateTime(1963, 2, 13),
                DateEmbauche = new DateTime(2023, 5, 9)
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.Add(gestionnaire);
                ctx.SaveChanges();
            }
            //Execution
            Gestionnaire gestionnaireModif = new Gestionnaire()
            {
                Id = gestionnaire.Id,
                Nom = "SuperMalkovich",
                Prenom = "JohnJohn",
                AdresseMail = "superjohnmalkovich@mail.com",
                MotDePasse = "SUPERmdp",
                DateNaissance = new DateTime(1689, 2, 13),
                DateEmbauche = new DateTime(2022, 5, 9)
            };
            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.UpdateGestionnaire(gestionnaireModif);
            }
            //Verification
            Gestionnaire gestionnaireDb;
            using (BddContext ctx = new BddContext())
            {
                gestionnaireDb = ctx.Gestionnaires.Find(1);
            }
            Assert.NotNull(gestionnaireDb);
            Assert.Equal(gestionnaire.Id, gestionnaireDb.Id);
            Assert.Equal(gestionnaireModif.Nom, gestionnaireDb.Nom);
            Assert.Equal(gestionnaireModif.Prenom, gestionnaireDb.Prenom);
            Assert.Equal(gestionnaireModif.AdresseMail, gestionnaireDb.AdresseMail);
            Assert.Equal(gestionnaireModif.MotDePasse, gestionnaireDb.MotDePasse);
            Assert.Equal(gestionnaireModif.DateNaissance, gestionnaireDb.DateNaissance);
            Assert.Equal(gestionnaireModif.DateEmbauche, gestionnaireDb.DateEmbauche);
        }

        [Fact]
        public void TestDeleteGestionnaire()
        {
            //Initialisation
            using (BddContext ctx = new BddContext())
            {
                ctx.Gestionnaires.Add(new Gestionnaire()
                {
                    Nom = "Malkovich",
                    Prenom = "John",
                    AdresseMail = "johnmalkovich@mail.com",
                    MotDePasse = "mdp",
                    DateNaissance = new DateTime(1963, 2, 13),
                    DateEmbauche = new DateTime(2023, 5, 9)
                });
                ctx.SaveChanges();
            }
            //Execution
            using (IDalGestionnaire service = new GestionnaireService())
            {
                service.DeleteGestionnaire(1);
            }
            //Verification
            List<Gestionnaire> gestionnaires;
            using (BddContext ctx = new BddContext())
            {
                gestionnaires = ctx.Gestionnaires.ToList();
            }
            Assert.Empty(gestionnaires);
        }
    }
}
