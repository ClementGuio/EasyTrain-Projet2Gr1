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

namespace EasyTrain_UnitTests.TestsDAL
{
    [DbCleanUp()]
    public class SalleServiceTests
    {

        [Fact]
        public void TestCreateSalle()
        {
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"}
                            };

            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(new Salle { Nom = "Dojo", Type = "interieur", Equipements=equipements });

            }
            Salle salle;
            
            using (BddContext ctx = new BddContext())
            {
                salle = ctx.Salles.Include(s => s.Equipements).Where(s => s.Id == 1).FirstOrDefault();
            }
            Assert.Equal(equipements.Count, salle.Equipements.Count) ;
            Assert.Equal("Dojo", salle.Nom);
        }


        [Fact]
        public void TestGetSalles()
        {

            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"}
                            };

            //DeleteCreateDB();
            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Hand", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Foot", Type = "Exterieur", Equipements = equipements });

            }

            //Execution de la m�thode � tester
            List<Salle> salles;
            using (IDalSalle service = new SalleService())
            {
                salles = service.GetSalles();
            }

            //Verification du r�sultat
            Assert.NotEmpty(salles);
            Assert.Equal(3, salles.Count);
        }
        [Fact]
        public void TestGetSalle()
        {
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"}
                            };

            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Hand", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Foot", Type = "Exterieur", Equipements = equipements });

            }


            //Execution de la m�thode � tester
            Salle salle;
            using (IDalSalle service = new SalleService())
            {
                salle = service.GetSalle(3);
            }
            Assert.NotNull(salle);
            Assert.Equal("Foot", salle.Nom);
        }
        [Fact]
        public void TestUpdateSalle()
        {
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"}
                            };

            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Hand", Type = "interieur", Equipements = equipements });
                service.CreateSalle(new Salle { Nom = "Foot", Type = "Exterieur", Equipements = equipements });

            }

            //Execution de la m�thode � tester
            Salle salle;
            using (IDalSalle service = new SalleService())
            {
                Salle newSalle = new Salle { Id = 3, Nom = "Running", Type = "Mixte", Equipements = equipements };
                service.UpdateSalle(newSalle);
                salle = service.GetSalle(3);
            }

            Assert.Equal("Running", salle.Nom);
            Assert.Equal("Mixte", salle.Type);

        }

        [Fact]
        public void TestDeleteSalle()
        {
            List<Equipement> equipements = new List<Equipement>()
                              {
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Banc de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Cage de musculation"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Set d'haltères"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"},
                            new Equipement(){ Nom = "Vélo elliptique"}
                            };

            using (IDalSalle service = new SalleService())
            {
                service.CreateSalle(new Salle { Nom = "Dojo", Type = "interieur", Equipements = equipements });

            }
            List<Salle> salles;

            using (IDalSalle service = new SalleService())
            {
                service.DeleteSalle(1);
                salles = service.GetSalles();
            }

            Assert.Empty(salles);

        }
    }
}
