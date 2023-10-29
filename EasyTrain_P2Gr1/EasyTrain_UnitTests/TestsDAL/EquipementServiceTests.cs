using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTrain_UnitTests.TestsDAL
{
    [Collection("sequential")]
    [DbCleanUp]
    public class EquipementServiceTests
    {
        [Fact]
        public void TestGetEquipements()
        {
            //Initialisation
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.Add(salle);
                ctx.SaveChanges();
                ctx.Equipements.AddRange(new List<Equipement>()
                {
                    new Equipement() {Nom = "Banc de musculation", Salle = ctx.Salles.Find(salle.Id) },
                    new Equipement() {Nom = "Vélo elliptique", Salle = ctx.Salles.Find(salle.Id) }
                });
                ctx.SaveChanges();
            }

            //Execution
            List<Equipement> equipements;
            using (IDalEquipement service = new EquipementService())
            {
                equipements = service.GetEquipements();
            }

            //Verification
            Assert.NotEmpty(equipements);
            Assert.Equal(2, equipements.Count);
            Assert.NotNull(equipements[0].Salle);
        }

        [Fact]
        public void TestGetEquipement()
        {
            //Initialisation
            Equipement equipement = new Equipement()
            {
                Nom = "La barre fixe",
                Salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" }
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.Add(equipement);
                ctx.SaveChanges();
            }
            //Execution
            Equipement equipementDb;
            using (IDalEquipement service = new EquipementService())
            {
                equipementDb = service.GetEquipement(equipement.Id);
            }
            //Verification
            Assert.NotNull(equipementDb);
            Assert.Equal(equipement.Nom, equipementDb.Nom);
            Assert.NotNull(equipementDb.Salle);
        }

        [Fact]
        public void TestCreateEquipement()
        {
            //Initialisation
            Salle salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" };
            using (BddContext ctx = new BddContext())
            {
                ctx.Salles.AddRange(salle);
                ctx.SaveChanges();
            }
            //Execution
            Equipement equipement = new Equipement() { Nom = "les althères", Salle = salle };
            using (IDalEquipement service = new EquipementService())
            {
                service.CreateEquipement(equipement);
            }
            //Verification
            Equipement equipementDb;
            using (BddContext ctx = new BddContext())
            {
                equipementDb = ctx.Equipements.Find(equipement.Id);
            }
            Assert.NotNull(equipement);
            Assert.Equal(equipement.Nom, equipementDb.Nom);
            Assert.NotNull(equipement.Salle);
        }

        [Fact]
        public void TestUpdateEquipement()
        {
            //Initialisation
            List<Salle> salles = new List<Salle>
            {
                new Salle() { Nom = "Salle A" , Type = "cardio" },
                new Salle() { Nom = "Salle B" , Type = "Muscu"}

            };
            Equipement equipement = new Equipement { Nom = "Corde à sautez", Salle = salles[0] };
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.Add(equipement);
                ctx.SaveChanges();
            }
            //Execution
            Equipement equipementModif = new Equipement
            {
                Id = equipement.Id,
                Nom = "Corde à sauter",
                Salle = salles[1]
            };
            using (IDalEquipement service = new EquipementService())
            {
                service.UpdateEquipement(equipementModif);
            }
            //Verification
            Equipement equipementDb;
            List<Salle> sallesDb;
            using (BddContext ctx = new BddContext())
            {
                equipementDb = ctx.Equipements.Include(c => c.Salle).FirstOrDefault(e => e.Id == equipement.Id);
                sallesDb = ctx.Salles.ToList();
            }
            Assert.Equal(equipement.Id, equipementDb.Id);
            Assert.Equal(equipementModif.Nom, equipementDb.Nom);
            Assert.Equal(equipementModif.Salle.Nom, equipementDb.Salle.Nom);
            Assert.Equal(salles.Count, sallesDb.Count);
        }

        [Fact]
        public void TestDeleteEquipement()
        {
            //Initialisation
            Equipement equipement = new Equipement()
            {
                Nom = "Salle A",
                Salle = new Salle { Nom = "Jean Lasalle", Type = "Débarras" }
            };
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.Add(equipement);
                ctx.SaveChanges();
            }
            //Execution
            using (IDalEquipement service = new EquipementService())
            {
                service.DeleteEquipement(equipement.Id);
            }
            //Verification
            List<Equipement> equipementsDb;
            List<Salle> sallesDb;

            using (BddContext ctx = new BddContext())
            {
                equipementsDb = ctx.Equipements.ToList();
                sallesDb = ctx.Salles.ToList();
            }
            Assert.Empty(equipementsDb);
            Assert.NotEmpty(sallesDb);
        }
    }
}
