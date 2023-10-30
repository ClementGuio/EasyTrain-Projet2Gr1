using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit.Sdk;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp()]
    public class SalleServiceTests
    {

        [Fact]
        public void TestCreateSalle()
        {
            //Initialisation
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"}
                            };
            Salle salle;
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.AddRange(equipements);
                ctx.SaveChanges();
                salle = new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements };
            }

            //Execution
            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(salle);
            }

            //Verification
            Salle salleDb;
            using (BddContext ctx = new BddContext())
            {
                salleDb = ctx.Salles.Include(s => s.Equipements).Where(s => s.Id == 1).FirstOrDefault();
            }
            Assert.Equal(salle.Nom, salleDb.Nom);
            Assert.Equal(salle.Type, salleDb.Type);
            Assert.NotNull(salleDb.Equipements);
            Assert.Equal(salle.Equipements.Count, salleDb.Equipements.Count);
        }


        [Fact]
        public void TestGetSalles()
        {

            //Initialisation
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            };

            List<Salle> salles = new List<Salle>()
            {
                new Salle(){ Nom = "Salle A", Type = "muscu",
                    Equipements = equipements.Where(e => e.Nom.Contains("musculation")).ToList() },
                new Salle(){ Nom = "Salle B", Type = "haltères",
                    Equipements = equipements.Where(e => e.Nom.Contains("haltères")).ToList() },
                new Salle(){ Nom = "Salle C", Type = "vélo",
                    Equipements = equipements.Where(e => e.Nom.Contains("Vélo")).ToList() }
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.AddRange(salles);
                ctx.SaveChanges();
            }

            //Execution
            List<Salle> sallesDb;
            using (IDalSalle service = new SalleService())
            {
                sallesDb = service.GetSalles();
            }

            //Verification
            Assert.NotNull(sallesDb);
            Assert.Equal(salles.Count, sallesDb.Count);
            Assert.NotNull(sallesDb[1].Equipements);
            Assert.Equal(salles[1].Equipements.Count, sallesDb[1].Equipements.Count);
        }

        [Fact]
        public void TestGetSalle()
        {
            //Initialisation
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            };
            Salle salle = new Salle { Nom = "Golgoth", Type = "muscu", Equipements = equipements };
            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.Add(salle);
                ctx.SaveChanges();
            }

            //Execution
            Salle salleDb;
            using (IDalSalle service = new SalleService())
            {
                salleDb = service.GetSalle(1);
            }
            //Verification
            Assert.NotNull(salleDb);
            Assert.Equal(salle.Nom, salleDb.Nom);
            Assert.Equal(salle.Type, salleDb.Type);
            Assert.NotNull(salleDb.Equipements);
            Assert.NotEmpty(salleDb.Equipements);
            Assert.Equal(salle.Equipements.Count, salleDb.Equipements.Count);
        }
        [Fact]
        public void TestUpdateSalle()
        {
            //Initialisation
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            };

            Salle salle = new Salle() { Nom = "Course", Type = "Mix", Equipements = equipements };
            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.Add(salle);
                ctx.SaveChanges();
            }

            //Execution
            Salle salleModif = new Salle { Id = salle.Id, Nom = "Running", Type = "Mixte", Equipements = equipements.Where(e => e.Nom.Contains("Banc")).ToList() };
            using (IDalSalle service = new SalleService())
            {
                service.UpdateSalle(salleModif);
            }

            //Verification
            Salle salleDb;
            using (BddContext ctx = new BddContext())
            {
                salleDb = ctx.Salles.Include(c => c.Equipements).FirstOrDefault(s => s.Id == 1);
            }
            Assert.Equal(salle.Id, salleDb.Id);
            Assert.Equal(salleModif.Nom, salleDb.Nom);
            Assert.Equal(salleModif.Type, salleDb.Type);
            Assert.Equal(salleModif.Equipements.Count, salleDb.Equipements.Count);

        }

        [Fact]
        public void TestDeleteSalle()
        {
            //Initialisation
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"}     
                            };

            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.Add(new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements });
                ctx.SaveChanges();
            }
            //Execution
            using (IDalSalle service = new SalleService())
            {
                service.DeleteSalle(1);
            }
            //Verification
            List<Equipement> equipementsDb;
            List<Salle> sallesDb;
            using (BddContext ctx = new BddContext())
            {
                equipementsDb = ctx.Equipements.ToList();
                sallesDb = ctx.Salles.ToList();
            }

            Assert.Empty(sallesDb);
            Assert.NotEmpty(equipementsDb);
            Assert.Equal(equipements.Count, equipementsDb.Count);

        }
    }
}
