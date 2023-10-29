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
    public class CoursProgrammeServiceTests
    {
        [Fact]
        public void TestGetCoursProgrammes()
        {
            using(BddContext ctx = new BddContext())
            {
                ctx.Cours.Add(
                new Cours()
                {
                    Titre = "Musculation débutant",
                    NbParticipants = 10,
                    Prix = 23.5

                });
                ctx.SaveChanges();
                ctx.CoursProgrammes.AddRange(new List<CoursProgramme>()
                {

                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 10, 30, 0), DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                    Cours = ctx.Cours.First(c => c.Titre == "Musculation débutant"),
                    
                    PlacesLibres = ctx.Cours.First(c => c.Titre == "Musculation débutant").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = ctx.Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = ctx.Cours.First(c => c.Titre == "Musculation débutant").NbParticipants}
                });
                ctx.SaveChanges();
            }

             List<CoursProgramme> coursProgrammes;
        using(IDalCoursProgramme service = new CoursProgrammeService())
            {
                coursProgrammes = service.GetCoursProgrammes();
            }
            Assert.NotEmpty(coursProgrammes);
            Assert.Equal(2, coursProgrammes.Count);
            Assert.NotNull(coursProgrammes[0].Cours);
        }
        /***************************************************************************/

        [Fact]
        public void TestCreateCoursProgramme()
        {
            Cours cours = new Cours()
            {
                Titre = "Musculation débutant",
                NbParticipants = 10,
                Prix = 23.5

            };

           
            CoursProgramme coursProgramme= new CoursProgramme()
            {
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now,
                PlacesLibres = 2,
                Cours = cours
            };

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.CreateCoursProgramme(coursProgramme);

            }
            

            using (BddContext ctx = new BddContext())
            {
                coursProgramme = ctx.CoursProgrammes.Include(c => c.Cours).Where(c => c.Id == 1).First();
            }
            Assert.NotNull(coursProgramme);
            Assert.Equal(2, coursProgramme.PlacesLibres);
            Assert.NotNull(coursProgramme.Cours);
        }

        /*****************************************************************************************/


        [Fact]
        public void TestDeleteCoursProgramme() {

            Cours cours = new Cours()
            {
                Titre = "Musculation débutant",
                NbParticipants = 10,
                Prix = 23.5

            };

            CoursProgramme coursProgramme = new CoursProgramme()
            {
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now,
                PlacesLibres = 2,
                Cours = cours
            };

            using (BddContext ctx = new BddContext())
            {
                ctx.CoursProgrammes.AddRange(new List<CoursProgramme>()
                {
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                   // Cours = ctx.Cours.First (c => c.Titre == "Cyclisme"), 
                Cours = cours 
                }

                }); 

                ctx.SaveChanges();
            }

            List<CoursProgramme> coursProgrammes;

            using (IDalCoursProgramme service = new CoursProgrammeService())
            {
                service.DeleteCoursProgramme(1);
                coursProgrammes = service.GetCoursProgrammes();
            }
            
            Assert.Empty(coursProgrammes);
        }


        
    }
}
