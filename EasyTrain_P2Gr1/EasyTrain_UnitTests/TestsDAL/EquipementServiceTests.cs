using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.DAL.Interfaces;
using EasyTrain_P2Gr1.Models.Services;
using EasyTrain_P2Gr1.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
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
            
           
            using (BddContext ctx = new BddContext())
            {
               
                ctx.Equipements.AddRange(new List<Equipement>()
                {
                    new Equipement() {Nom = "Banc de musculation" },
                    new Equipement() {Nom = "Vélo elliptique" }
                });
                ctx.SaveChanges();
            }

            //Execution de la m�thode � tester
            List<Equipement> equipements;
            using (IDalEquipement service = new EquipementService())
            {
                equipements = service.GetEquipements();
            }

            //Verification du r�sultat
            Assert.NotEmpty(equipements);
            Assert.Equal(2, equipements.Count);
        }


        [Fact]
        public void TestGetEquipement()
        {
            //DeleteCreateDB();
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.AddRange(new List<Equipement>()
                {
                new Equipement() {Nom = "La barre fixe" },
                new Equipement() {Nom = "La cage à squat" }
                });
                ctx.SaveChanges();
            }

            Equipement equipement;
            using (IDalEquipement service = new EquipementService())
            {
                equipement = service.GetEquipement(2);
            }
            Assert.NotNull(equipement);
            Assert.Equal("La cage à squat", equipement.Nom);
        }

       

        [Fact]
        public void TestDeleteEquipement()
        {
        
            using (BddContext ctx = new BddContext())
            {
                ctx.Equipements.AddRange(new List<Equipement>()
                {
                new Equipement() {}
                });
                ctx.SaveChanges();
            }
            List<Equipement> equipements;

            using (IDalEquipement service = new EquipementService())
            {
                service.DeleteEquipement(1);
                equipements = service.GetEquipements();
            }

            Assert.Empty(equipements);

        }

        [Fact]
        public void TestCreateEquipement()
        {

            Equipement equipement = new Equipement() { Nom = "les althères" };


            using (IDalEquipement service = new EquipementService())
            {
                service.CreateEquipement(equipement);

            }
    

            using (BddContext ctx = new BddContext())
            {
                equipement = ctx.Equipements.Find(1);
            }
            Assert.Equal("les althères", equipement.Nom);
        }
        [Fact]
        public void TestUpdateEquipement()
        {
            Equipement equipement = new Equipement() { Nom = "les althères" };


            using (BddContext ctx = new BddContext())
            {
                
                ctx.Equipements.AddRange(new List<Equipement>()
                {
            equipement

                });
                ctx.SaveChanges();
            }
            

            equipement.Nom = "Esaytrain";
           

            using (IDalEquipement service = new EquipementService())
            {
                service.UpdateEquipement(equipement);
                                 
                equipement = service.GetEquipement(1);
            }

            Assert.Equal("Esaytrain", equipement.Nom);


        }

    }
}
